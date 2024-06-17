using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public interface IPieceFactory
    {
        Piece CreateMovedPiece(Piece piece, Tile newTile);
        Piece CreatePiece(Piece piece);
        Piece CreatePieceColor(char symbol, Tile tile, Color color);
    }
}