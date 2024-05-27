using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models;
using System.ComponentModel.DataAnnotations;
using Chess_Backend.Models.Positions;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.MoveGenerators;

namespace Chess_Backend.Services.Validators
{
    public class KingCheckValidator : IMovementValidator
    {
        public ICompositeTileGenerator MovesGenerator { get; }

        public KingCheckValidator(ICompositeTileGenerator movesGenerator)
        {
            MovesGenerator = movesGenerator;
        }
        public bool ShouldValidateMove(Movement movement)

            // If it was CastlingValidator
            // Doing some check to verify if I need to check for castling 
            // So ill check if The king didn't moved yet at all till now


        {
            return true;
        }
        public bool IsMovementValid(Movement movement, IBoard currentBoard)
        {
            //var kingPosition = currentBoard.FindKingPosition();
            //var otherPlayerColor = currentBoard.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            //var checkList = new List<Tile>();
            //foreach (Piece piece in currentBoard.Pieces.Where(p => p.Color == otherPlayerColor))
            //{
            //    var possibleMoves = MovesGenerator.GetPossibleMoves(piece);
            //    foreach (Tile tile in possibleMoves)
            //                // my king Tile:
            //        if (tile == kingPosition)
            //        {
            //            checkList.Add(tile);

            //            // or just return true when one found
            //        }
            //    }
            //}
            return true;
        }


    }
}
