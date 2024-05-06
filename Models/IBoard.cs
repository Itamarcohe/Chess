using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models
{
    public interface IBoard 
    {
        bool IsTileOccupied(Tile tile);
        bool IsTileOccupied(int row, int column);
        Piece? GetPieceByTilePosition(Tile tile);
        Piece? GetPieceByTilePosition(int row, int column);
        Color currentTurnColor { get; }
        List<Piece> Pieces { get; }
        void MapPiecesToDictionary();
    }
}
