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
            // if its queen side so Rook is at - //  0
            if (movement.KingToMove.HasMoved) 
            {
                return false;
            }
            Piece? piece = board.GetPieceByTilePosition(movement.KingToMove.TilePosition.Column - 4, movement.KingToMove.TilePosition.Row);
            if (piece == null || piece is not Rook || piece.HasMoved)
            {
                return false;
            }
            (int, int)[] InBetweenSquares = GetSquaresToCheck(movement);
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
            (int, int)[] InBetweenSquares = GetSquaresToCheck(movement);
            if (!IsSquaresBetweenEmpty(InBetweenSquares, board))
            {
                return false;
            }
            // implement moving logic ? 
            return true;
        }
        private (int, int)[] GetSquaresToCheck(Movement movement)
        {
            (int, int)[]? squares = null;

            if (movement is CastlingBaseMovement castlingMovement)
            {
                int kingRow = castlingMovement.KingToMove.TilePosition.Row;
                int kingColumn = castlingMovement.KingToMove.TilePosition.Column;

                if (movement is KingCastlingMovement)
                {
                    squares = new (int, int)[2];
                    for (int i = 0; i < 2; i++)
                    {
                        squares[i] = (kingColumn + i + 1, kingRow);
                    }
                }
                else if (movement is QueenCastlingMovement)
                {
                    squares = new (int, int)[3];
                    for (int i = 0; i < 3; i++)
                    {
                        squares[i] = (kingColumn - (i + 1), kingRow);
                    }
                }
            }
            return squares!;
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
