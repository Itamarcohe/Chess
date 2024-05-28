using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.MoveGenerators;
using Chess_Backend.Utils;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : IMovementValidator
    {
        public ICompositeTileGenerator MovesGenerator { get; }
        public IBoardFactory BoardFactory { get; }

        public KingCheckValidator(ICompositeTileGenerator movesGenerator, IBoardFactory boardFactory)
        {
            MovesGenerator = movesGenerator;
            BoardFactory = boardFactory;
        }
        public bool ShouldValidateMove(Movement movement)
        {
            return true;
        }
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            // Checking in this method if the current player move wont get him into being check by simulating
            IBoard newSimulatedBoard = BoardFactory.CreateNewBoard(currentBoard, movement); // Making the move + Changing the turn
            var currentPlayerKingPosition = newSimulatedBoard.FindOpponentKingPosition(); // getting the current moving player king tile from the new board 
            foreach (Piece piece in newSimulatedBoard.Pieces.Where(p => p.Color == newSimulatedBoard.CurrentTurnColor)) 
            {
                var possibleMoves = MovesGenerator.GetPossibleMoves(piece);
                if (possibleMoves.Any(tile => tile.Equals(currentPlayerKingPosition)))
                {
                    // The player would be in check after the move
                    return false;
                }
            }
            return true;
        }

    }
}
