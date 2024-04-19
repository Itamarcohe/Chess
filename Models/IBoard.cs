﻿using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models
{
    public interface Iboard 
    {
        bool IsTileOccupied(int row, int column);

        Piece GetPieceByTilePosition(Tile tile);

    }
}
