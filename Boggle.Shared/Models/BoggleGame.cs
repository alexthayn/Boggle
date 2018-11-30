using Boggle.Shared.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boggle.Shared.Models
{
    public class BoggleGame : ObservableObject, IBoggleGame
    {
        public GameBoard GameBoard;
        private TimeSpan _remainingTime;
        public TimeSpan RemainingTime { get => _remainingTime; set => Set(ref _remainingTime, value); }

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

        private string _username;
        public string Username { get => _username; set => Set(ref _username, value); }

        public BoggleGame()
        {
            GameBoard = new GameBoard();
        }

        public int CalculateWordScore(string Word)
        {
            //I need to handle characters other than alphabetical ones so they don't count towards the score
            if(Word.Length < 3)
                return 0;
            
            switch (Word.Length)
            {
                case 3: return 1;
                case 4: return 1;
                case 5: return 2;
                case 6: return 3;
                case 7: return 4;
                //return a score of 11 points if the length of the word is greater than 8 letters
                default: return 11;
            }            
        }

        public void NewGame(string username)
        {
            Username = username;
            GameBoard.ShakeDice();
            StartCountdown();
            Row1 = GameBoard.GameGrid[0];
            Row2 = GameBoard.GameGrid[1];
            Row3 = GameBoard.GameGrid[2];
            Row4 = GameBoard.GameGrid[3];            
        }

        public int GetScore()
        {
            return Score;
        }

        private async void StartCountdown()
        {
            DateTime startTime = DateTime.UtcNow, endTime = startTime.AddMinutes(3);
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
            
        }
    }
}
