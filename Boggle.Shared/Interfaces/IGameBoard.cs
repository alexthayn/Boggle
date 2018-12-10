using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Interfaces
{
    public interface IGameBoard
    {
        string[][] GameGrid { get; set; }
    }
}
