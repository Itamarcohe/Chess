using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.MoveGenerators;
using Chess_Backend.Utils;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Services.MoveComposite;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : IMovementValidator
    {
        private readonly ICompositeTileGenerator _movesGenerator;
        private readonly ICompositeMoveLogic _compositeMoveLogic;

        public KingCheckValidator(ICompositeTileGenerator movesGenerator, ICompositeMoveLogic compositeMoveLogic)
        {
            _movesGenerator = movesGenerator;
            _compositeMoveLogic = compositeMoveLogic;
        }
        public bool ShouldValidateMove(Movement movement) => true;
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            IBoard newSimulatedBoard = _compositeMoveLogic.ApplyMove(movement, currentBoard)!;  // Making the move + Changing the turn
            var currentPlayerKingPosition = newSimulatedBoard.FindOpponentKingPosition(); // getting the current moving player king tile from the new board 
            foreach (Piece piece in newSimulatedBoard.Pieces.Where(p => p.Color == newSimulatedBoard.CurrentTurnColor))
            {
                var possibleMoves = _movesGenerator.GetPossibleMoves(piece, newSimulatedBoard);
                if (possibleMoves.Any(tile => tile.Equals(currentPlayerKingPosition)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}