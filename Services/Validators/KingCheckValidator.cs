using Chess_Backend.Models.Movements;
using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.MoveGenerators;
using Chess_Backend.Services.MoveComposite;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : IMovementValidator
    {
        private readonly ICompositeTileGenerator _movesGenerator;
        private readonly ICompositeMoveLogic _compositeMoveLogic;
        private readonly ICompositeValidator _compositeValidator;
        private readonly MovementFactory _movementFactory;

        public KingCheckValidator(ICompositeTileGenerator movesGenerator, ICompositeMoveLogic compositeMoveLogic, ICompositeValidator compositeValidator, MovementFactory movementFactory)
        {
            _movesGenerator = movesGenerator;
            _compositeMoveLogic = compositeMoveLogic;
            _compositeValidator = compositeValidator;
            _movementFactory = movementFactory;
        }
        public bool ShouldValidateMove(Movement movement) => true;
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            IBoard newSimulatedBoard = _compositeMoveLogic.ApplyMove(movement, currentBoard)!; 
            var currentPlayerKingPosition = newSimulatedBoard.FindOpponentKingPosition();  

            foreach (Piece piece in newSimulatedBoard.Pieces.Where(p => p.Color == newSimulatedBoard.CurrentTurnColor))
            {
                var possibleMoves = _movesGenerator.GetPossibleMoves(piece, newSimulatedBoard);

                foreach (var possibleMove in possibleMoves)
                {
                    Movement movementToValidate = _movementFactory.CreateMovement(piece.TilePosition, possibleMove, newSimulatedBoard);
                    if (_compositeValidator.IsMovementValidFilterList(movementToValidate, newSimulatedBoard, new List<Type> { typeof(KingCheckValidator) }))
                    {
                        if (movementToValidate.To.Equals(currentPlayerKingPosition))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
