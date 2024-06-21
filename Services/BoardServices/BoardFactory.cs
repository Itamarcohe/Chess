using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Movements.MovementTypes;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services.BoardServices
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IPieceFactory pieceFactory;
        public BoardFactory(IPieceFactory pieceFactory)
        {
            this.pieceFactory = pieceFactory;
        }
        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {
            var newTurnColor = ToggleColor(board.CurrentTurnColor);
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
        private static Color ToggleColor(Color currentColor) => currentColor == Color.White ? Color.Black : Color.White;
        public IBoard InitializeNewBoard()
        {
            List<Piece> pieces = [];
            SetupInitialRow(Color.White, 1, pieces);
            SetupBackRow(Color.White, 0, pieces);
            SetupInitialRow(Color.Black, 6, pieces);
            SetupBackRow(Color.Black, 7, pieces);
            return new Board(pieces, Color.White); ;
        }

        private void SetupInitialRow(Color color, int row, List<Piece> pieces)
        {
            for (int col = 0; col < 8; col++)
            {
                var tile = new Tile(col, row);
                var pawn = new Pawn(color, tile);
                pieces.Add(pawn);
            }
        }
        private void SetupBackRow(Color color, int row, List<Piece> pieces)
        {
            pieces.Add(new Rook(color, new Tile(0, row)));
            pieces.Add(new Knight(color, new Tile(1, row)));
            pieces.Add(new Bishop(color, new Tile(2, row)));
            pieces.Add(new Queen(color, new Tile(3, row)));
            pieces.Add(new King(color, new Tile(4, row)));
            pieces.Add(new Bishop(color, new Tile(5, row)));
            pieces.Add(new Knight(color, new Tile(6, row)));
            pieces.Add(new Rook(color, new Tile(7, row)));
        }

    }
}
