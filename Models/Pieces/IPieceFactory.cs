﻿using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public interface IPieceFactory
    {
        Piece CreatePiece(char symbol, Tile tile);
        Piece CreatePiece(Piece piece);
        Piece CreatePieceColor(char symbol, Tile tile, Color color);
    }
}