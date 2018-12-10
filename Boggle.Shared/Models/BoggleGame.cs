using Boggle.Shared.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boggle.Shared.Models
{

    public class BoggleGame : ObservableObject, IBoggleGame
    {
        public GameBoard GameBoard;
        private TimeSpan _remainingTime;
        public TimeSpan RemainingTime { get => _remainingTime; set => Set(ref _remainingTime, value); }
        private bool _isGameOver;
        public bool IsGameOver { get => _isGameOver; set => Set(ref _isGameOver, value); }
        public const double GameTime = 3;

        private string[] _row1;
        public string[] Row1 { get => _row1; set => Set(ref _row1, value); }
        private string[] _row2;
        public string[] Row2 { get => _row2; set => Set(ref _row2, value); }
        private string[] _row3;
        public string[] Row3 { get => _row3; set => Set(ref _row3, value); }
        private string[] _row4;
        public string[] Row4 { get => _row4; set => Set(ref _row4, value); }

        //Overall game score updated with each valid word
        private int _score;
        public int Score { get => _score; set => Set(ref _score, value); }

        //Number of correct words guessed
        private int _wordCount;
        public int WordCount { get => _wordCount; set => Set(ref _wordCount, value); }

        private ObservableCollection<PlayerGuess> _listOfGuesses;
        public ObservableCollection<PlayerGuess> ListOfGuesses { get => _listOfGuesses; set => Set(ref _listOfGuesses, value); }

        private List<string> _listOfPossibleAnswers;
        public List<string> ListOfPossibleAnswers { get => _listOfPossibleAnswers; set => Set(ref _listOfPossibleAnswers, value); }

        private string _username;
        public string Username { get => _username; set => Set(ref _username, value); }

        public BoggleGame(string username)
        {
            GameBoard = new GameBoard();
            ListOfGuesses = new ObservableCollection<PlayerGuess>();
            WordCount = 0;
            Score = 0;
            Username = username;
            IsGameOver = false;
            StartGame();
            ListOfPossibleAnswers = new List<string>();
            FindAllPossibleAnswers();            
        }

        public void SubmitGuess(string Word)
        {
           //Check if the user entered a duplicate guess
           foreach(PlayerGuess g in ListOfGuesses)
           {
                if (g.Guess == Word)
                    return;
           }
            //I need to handle characters other than alphabetical ones so they don't count towards the score            
            bool isGuessValid = CheckPlayerGuessIsValidDictionaryWord(Word);
            bool isGuessOnGameGrid = ListOfPossibleAnswers.Contains(Word.ToUpper());
            ListOfGuesses.Add(new PlayerGuess() { Guess = Word, IsValidGuess = isGuessValid });

            
            if (isGuessValid && isGuessOnGameGrid)
            {
                WordCount++;
                int wordLength = Word.Count(w => char.IsLetter(w));
                if (wordLength < 3)
                    return;

                switch (wordLength)
                {
                    case 3: Score += 1;
                        break;
                    case 4: Score += 1;
                        break;
                    case 5: Score += 2;
                        break; 
                    case 6: Score += 3;
                        break;
                    case 7: Score += 4;
                        break;
                    //return a score of 11 points if the length of the word is greater than 8 letters
                    default: Score += 11;
                        break;
                }
            }
        }

        private void StartGame()
        {
            GameBoard.ShakeDice();
            RemainingTime = new TimeSpan();
            StartCountdown(GameTime);
            Row1 = GameBoard.GameGrid[0];
            Row2 = GameBoard.GameGrid[1];
            Row3 = GameBoard.GameGrid[2];
            Row4 = GameBoard.GameGrid[3];            
        }

        //Algorithm to find all possible answers in the game board
        private async void FindAllPossibleAnswers()
        {
            var letters = string.Join("", Row1) + string.Join("", Row2) + string.Join("", Row3) + string.Join("", Row4);
            var url = "http://api.codebox.org.uk/boggle/" + letters;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    result = result.Substring(2, result.Length - 2);
                    List<string> resultsList = result.Split(',').ToList();
                    foreach(string s in resultsList)
                    {
                        var cleanedString = Regex.Replace(s,"[\\\"]",string.Empty);
                        cleanedString = cleanedString.Trim();
                        ListOfPossibleAnswers.Add(cleanedString);
                    }
                }
                else
                {
                    FindAllPossibleAnswers();
                }
            }
        }

        public int GetScore()
        {
            return Score;
        }

        private bool CheckPlayerGuessIsValidDictionaryWord(string guess)
        {
            //Check if word is in dictionary
            NetSpell.SpellChecker.Dictionary.WordDictionary wordDictionary = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            wordDictionary.DictionaryFile = "./Dictionaries/en-US.dic";
            NetSpell.SpellChecker.Spelling spelling = new NetSpell.SpellChecker.Spelling();

            spelling.Dictionary = wordDictionary;
            if (!spelling.TestWord(guess))
            {
                return false;
            }
            //Check if word in on game board
            return true;
        }

        private async void StartCountdown(double gameplayTime)
        {
            DateTime startTime = DateTime.UtcNow, endTime = startTime.AddMinutes(gameplayTime);
            TimeSpan remainingTime = endTime - startTime;
            TimeSpan interval = TimeSpan.FromMilliseconds(100);

            while(remainingTime > TimeSpan.Zero)
            {
                RemainingTime = remainingTime;
                if(RemainingTime < interval)
                {
                    interval = RemainingTime;
                }

                await Task.Delay(interval);
                remainingTime = endTime - DateTime.UtcNow;
            }

            RemainingTime = TimeSpan.Zero;
            IsGameOver = true;
        }
    }
}
