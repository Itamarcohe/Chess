using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services.MoveComposite
{
    public class NormalMoveLogic : IMoveLogic
    {
        private readonly IPieceFactory pieceFactory;

        public NormalMoveLogic(IPieceFactory pieceFactory)
        {
            this.pieceFactory = pieceFactory;
        }
        public bool ShouldApplyMove(Movement movement)
        {
            return movement is NormalMovement;
        }
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            return CreateNewBoard(board, movement);
        }

        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {
            var newTurnColor = board.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            var newPieces = board.Pieces
                                 .Select(piece => TransformPieceForNewBoard(piece, movement))
                                 .ToList();
            return new Board(newPieces, newTurnColor);
        }
        private Piece TransformPieceForNewBoard(Piece piece, Movement movement)
        {
            if (piece.TilePosition.Equals(movement.From))
            {
                return pieceFactory.CreatePieceColor(piece.GetSymbol(), movement.To, piece.Color);
            }
            return pieceFactory.CreatePiece(piece);
        }


    }
}
