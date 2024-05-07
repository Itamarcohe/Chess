using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.Validators
{
    public interface IPieceMovementValidator
    {
        bool AppliesTo(Piece piece);
        bool IsMoveValid(Piece piece, Tile to, IBoard board);
        List<Tile> GetPossibleMoves(Piece piece, IBoard board);
    }
}
