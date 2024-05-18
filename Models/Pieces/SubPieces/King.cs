﻿using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces.SubPieces
{
    public class King : Piece
    {
        public King(Color color, Tile tilePosition, bool hasMoved = false) : base(color, tilePosition, hasMoved) { }
        public King(King otherpiece) : base(otherpiece) { }
        protected override char GetInternalSymbol() => 'k';
    }
}
