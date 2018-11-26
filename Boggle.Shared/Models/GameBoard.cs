using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Models
{
    public class GameBoard
    {
        private const int GRIDSIZE = 4;
        private Random rand = new Random();

        private readonly BoggleDie DIE0 = new BoggleDie("R", "I", "F", "O", "B", "X");
        private readonly BoggleDie DIE1 = new BoggleDie("I", "F", "E", "H", "E", "Y");
        private readonly BoggleDie DIE2 = new BoggleDie("D", "E", "N", "O", "W", "S");
        private readonly BoggleDie DIE3 = new BoggleDie("U", "T", "O", "K", "N", "D");
        private readonly BoggleDie DIE4 = new BoggleDie("H", "M", "S", "R", "A", "O");
        private readonly BoggleDie DIE5 = new BoggleDie("L", "U", "P", "E", "T", "S");
        private readonly BoggleDie DIE6 = new BoggleDie("A", "C", "I", "T", "O", "A");
        private readonly BoggleDie DIE7 = new BoggleDie("Y", "L", "G", "K", "U", "E");
        private readonly BoggleDie DIE8 = new BoggleDie("Qu", "B", "M", "J", "O", "A");
        private readonly BoggleDie DIE9 = new BoggleDie("E", "H", "I", "S", "P", "N");
        private readonly BoggleDie DIE10 = new BoggleDie("V", "E", "T", "I", "G", "N");
        private readonly BoggleDie DIE11 = new BoggleDie("B", "A", "L", "I", "Y", "T");
        private readonly BoggleDie DIE12 = new BoggleDie("E","Z", "A", "V", "N", "D");
        private readonly BoggleDie DIE13 = new BoggleDie("R", "A", "L", "E", "S", "C");
        private readonly BoggleDie DIE14 = new BoggleDie("U", "W", "I", "L", "R", "G");
        private readonly BoggleDie DIE15 = new BoggleDie("P", "A", "C", "E", "M", "D");

        public List<BoggleDie> GameDice;

        public GameBoard()
        {
            GameDice = new List<BoggleDie>() { DIE0, DIE1, DIE2, DIE3, DIE4, DIE5, DIE6, DIE7,
                                              DIE8, DIE9, DIE10, DIE11, DIE12, DIE13, DIE14, DIE15 };
        }

        public string[,] GameGrid = new string[GRIDSIZE, GRIDSIZE];

        public void ShakeDice()
        {
            //Shake the dice
            ShuffleDice(GameDice);

            //Populate the grid
            int dieNum = 0;
            for(int i = 0; i < GRIDSIZE; i++)
            {
                for(int j = 0; j < GRIDSIZE; j++)
                {
                    GameGrid[i, j] = GameDice[dieNum].RollDie();
                    dieNum++;
                }
            }
        }

        //Private function to shuffle the list of dice around
        private void ShuffleDice(List<BoggleDie> list)
        {      
            int n = list.Count;
            while(n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                var tempShuffle = list[k];
                list[k] = list[n];
                list[n] = tempShuffle;
            }
        }
    }
}
