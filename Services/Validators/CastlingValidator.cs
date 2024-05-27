using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;

namespace Chess_Backend.Services.Validators
{
    public class CastlingValidator : IMovementValidator
    {
        public CastlingValidator() { }
        public bool ShouldValidateMove(Movement movement)
        {
            return movement is CastlingBaseMovement;
        }

        public bool IsMovementValid(Movement movement, IBoard board)
        {
            if (movement is KingCastlingMovement)
            {
                return ValidateKingCastle((KingCastlingMovement)movement, board);
            }
            if (movement is QueenCastlingMovement)
            {
                return ValidateQueenCastle((QueenCastlingMovement)movement, board);
            }
            return false;
        }

        private bool ValidateQueenCastle(QueenCastlingMovement movement, IBoard board)
        {
            if (movement.KingToMove.HasMoved) 
            {
                return false;
            }
            Piece? piece = board.GetPieceByTilePosition(movement.KingToMove.TilePosition.Column - 4, movement.KingToMove.TilePosition.Row);
            if (piece == null || piece is not Rook || piece.HasMoved)
            {
                return false;
            }

            var kingRow = movement.KingToMove.TilePosition.Row;
            (int, int)[] InBetweenSquares = [(1, kingRow), (2, kingRow), (3, kingRow)];

            if (!IsSquaresBetweenEmpty(InBetweenSquares, board))
            {
                return false;
            }
            return true;

        }
        private bool ValidateKingCastle(KingCastlingMovement movement, IBoard board)
        {
            if (movement.KingToMove.HasMoved)
            {
                return false;
            }
            Piece? piece = board.GetPieceByTilePosition(movement.KingToMove.TilePosition.Column + 3, movement.KingToMove.TilePosition.Row);
            if (piece == null || piece is not Rook || piece.HasMoved)
            {
                return false;
            }
            var kingRow = movement.KingToMove.TilePosition.Row;
            (int, int)[] InBetweenSquares = [(5, kingRow), (6, kingRow)];
            if (!IsSquaresBetweenEmpty(InBetweenSquares, board))
            {
                return false;
            }
            return true;
        }
        private bool IsSquaresBetweenEmpty((int, int)[] Squares, IBoard board)
        {
            foreach (var square in Squares)
            {
                if (board.GetPieceByTilePosition(square.Item1, square.Item2) != null)
                    return false;
            }
            return true;
        }
    }
}
