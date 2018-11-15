﻿
using System.Collections.Generic;

namespace Boggle.Shared.DataModels
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
