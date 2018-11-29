using Boggle.Shared.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Boggle.Shared.Models
{
    public class BoggleGame : ViewModelBase, IBoggleGame
    {
        public GameBoard GameBoard;
        private Stopwatch Timer;

        public BoggleGame()
        {
            GameBoard = new GameBoard();
            Timer = new Stopwatch();
        }

        //Overall game score updated with each valid word
        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                Set(ref _score, value);
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                Set(ref _username, value);
            }
        }

        public int CalculateWordScore(string Word)
        {
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
            //I can bind the Timer.Elapsed value to a label on my UI to display the elapsed time
            Timer.Start();
            //while(Timer.ElapsedMilliseconds <= 180000)
            //{
            //    //play game
            //}
        }

        public int GetScore()
        {
            return Score;
        }
    }
}
