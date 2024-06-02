using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models
{
    public interface IBoard 
    {
        bool IsTileOccupied(Tile tile);
        bool IsTileOccupied(int col, int row);
        Piece? GetPieceByTilePosition(Tile tile);
        Piece? GetPieceByTilePosition(int col, int row);
        Color CurrentTurnColor { get; }
        List<Piece> Pieces { get; }
        Tile? FindOpponentKingPosition();
    }
}
