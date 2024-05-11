using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.MoveGenerators;
using System.Linq;

namespace Chess_Backend.Services.Validators
{
    public class MoveInPossibleMovesValidator : IMovementValidator
    {
        private readonly ICompositeTileGenerator compositeMovesGenerator;
        public MoveInPossibleMovesValidator(ICompositeTileGenerator compositeMovesGenerator)
        {
            this.compositeMovesGenerator = compositeMovesGenerator;
        }
        public bool ShouldValidateMove(Movement movement)
        {
            return true;
        }
        public bool IsMovementValid(Movement movement, IBoard board)
        {
            var piece = board.GetPieceByTilePosition(movement.From) ?? throw new Exception("No Piece found in the move from position");
            List<Tile> tiles = compositeMovesGenerator.GetPossibleMoves(piece);
            return tiles.Contains(movement.To);
        }
    }
}
