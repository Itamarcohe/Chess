using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.MoveComposite
{
    public class KingCastlingMoveLogic : IMoveLogic
    {
        private readonly IPieceFactory pieceFactory;
        public KingCastlingMoveLogic(IPieceFactory pieceFactory)
        {
            this.pieceFactory = pieceFactory;
        }

        public bool ShouldApplyMove(Movement movement)
        {
            return movement is KingCastlingMovement;
        }
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            return CreateNewBoard(board, movement);
        }

        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {
            var newPieces = board.Pieces
                     .Select(piece => TransformPieceForNewBoard(piece, movement, board))
                     .ToList();
            var newTurnColor = board.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            return new Board(newPieces, newTurnColor);

        }

        private Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                return pieceFactory.CreatePieceColor(piece.GetSymbol(), movement.To, piece.Color);
            }

            if (IsRookOnRightOfKing(piece, movement))
            {
                var newTile = new Tile(piece.TilePosition.Column - 2, piece.TilePosition.Row);
                return pieceFactory.CreatePieceColor(piece.GetSymbol(), newTile, piece.Color);
            }

            return pieceFactory.CreatePiece(piece);
        }

        private bool IsRookOnRightOfKing(Piece piece, Movement movement)
        {
            return piece is Rook &&
                   piece.TilePosition.Row == movement.From.Row &&
                   piece.TilePosition.Column > movement.From.Column;
        }
    }
}
