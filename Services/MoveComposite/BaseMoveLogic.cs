using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using System.Linq;

namespace Chess_Backend.Services.MoveComposite
{
    public abstract class BaseMoveLogic : IMoveLogic
    {
        protected readonly IPieceFactory pieceFactory;
        protected BaseMoveLogic(IPieceFactory pieceFactory) { this.pieceFactory = pieceFactory; }
        public abstract bool ShouldApplyMove(Movement movement);
        public IBoard ApplyMove(Movement movement, IBoard board)
        {
            return CreateNewBoard(board, movement);
        }
        protected virtual IBoard CreateNewBoard(IBoard board, Movement movement, params Tile[] excludeTiles)
        {
            var tilesToExclude = excludeTiles.Any() ? excludeTiles : [];
            var newPieces = board.Pieces
                                 .Where(piece => !tilesToExclude.Contains(piece.TilePosition))
                                 .Select(piece => TransformPieceForNewBoard(piece, movement, board))
                                 .ToList();
            var newTurnColor = board.CurrentTurnColor == Color.White ? Color.Black : Color.White;
            return new Board(newPieces, newTurnColor);
        }
        protected abstract Piece TransformPieceForNewBoard(Piece piece, Movement movement, IBoard board);
    }
}
