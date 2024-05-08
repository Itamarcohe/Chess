using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerator
{
    public abstract class BaseTileGenerator : IMoveToTilesGenerator
    {
        public abstract (int, int)[] MoveVectors { get; }
        public abstract bool AppliesTo(Piece piece);
        public virtual List<Tile> GetPossibleMoves(Piece piece)
        {
            var moves = new List<Tile>();

            foreach (var moveVector in MoveVectors)
            {
                int newX = piece.TilePosition.Column + moveVector.Item1;
                int newY = piece.TilePosition.Row + moveVector.Item2;
                if (BoardUtils.IsWithinBoardBounds(newX, newY))
                {
                    Tile newTile = new Tile(newY, newX);
                    moves.Add(newTile);
                }
            }
            return moves;
        }
    }
}
