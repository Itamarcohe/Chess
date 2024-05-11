﻿using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements.MovementTypes
{
    public class EnPassantMovement : Movement
    {
        public EnPassantMovement(Tile from, Tile to) : base(from, to) { }
    }
}
