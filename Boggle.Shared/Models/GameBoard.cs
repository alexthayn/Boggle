using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Models
{
    public class GameBoard
    {
        private readonly BoggleDie DIE0 = new BoggleDie("R", "I", "F", "O", "B", "X");
        private readonly BoggleDie DIE1 = new BoggleDie("I", "F", "E", "H", "E", "Y");
        private readonly BoggleDie DIE2 = new BoggleDie("D", "E", "N", "O", "W", "S");
        private readonly BoggleDie DIE3 = new BoggleDie("H", "M", "S", "R", "A", "O");
        private readonly BoggleDie DIE4 = new BoggleDie("L", "U", "P", "E", "T", "S");
        private readonly BoggleDie DIE5 = new BoggleDie("A", "C", "I", "T", "O", "A");
        private readonly BoggleDie DIE6 = new BoggleDie("Y", "L", "G", "K", "U", "E");
        private readonly BoggleDie DIE7 = new BoggleDie("Qu", "B", "M", "J", "O", "A");
        private readonly BoggleDie DIE8 = new BoggleDie("E", "H", "I", "S", "P", "N");
        private readonly BoggleDie DIE9 = new BoggleDie("V", "E", "T", "I", "G", "N");
        

    }
}
