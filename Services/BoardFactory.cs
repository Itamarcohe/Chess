using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Services
{
    public class BoardFactory : IBoardFactory
    {

        
        private readonly IPieceFactory _pieceFactory;
        public BoardFactory(IPieceFactory pieceFactory)
        {
            _pieceFactory = pieceFactory;
        }

        //Movement 

        //public Tile From { get; private set; }
        //public Tile To { get; private set; }


        public IBoard CreateNewBoard(IBoard board, Movement movement)
        {

            List<Piece> newPieces = new List<Piece>();
            Piece newPiece;
            if (movement.GetType() == typeof(NormalMovement))
            {
                foreach (Piece piece in board.Pieces)
                {
                    if (piece.TilePosition == movement.From)
                    {

                        newPiece = _pieceFactory.CreatePieceColor(piece.GetSymbol(), movement.To, piece.Color);
                        newPieces.Add(newPiece);
                    }
                    else
                    {
                        newPiece = _pieceFactory.CreatePieceColor(piece.GetSymbol(), piece.TilePosition, piece.Color);
                        newPieces.Add(newPiece);
                    }

                }
            }

            Board newBoard = new Board(newPieces);
            return newBoard;
        }


        public IBoard InitializeNewBoard()
        {
            // Set up pieces for white
            List<Piece> pieces = new List<Piece>();

            SetupInitialRow(Color.White, 6, pieces); // Pawns
            SetupBackRow(Color.White, 7, pieces);    // Other pieces
            // Set up pieces for black
            SetupInitialRow(Color.Black, 1, pieces); // Pawns
            SetupBackRow(Color.Black, 0, pieces);    // Other pieces

            IBoard intializedBoard = new Board(pieces);

            intializedBoard.MapPiecesToDictionary();

            Console.WriteLine("Board initialized with {0} pieces.", pieces.Count);
            return intializedBoard;
        }

        private void SetupInitialRow(Color color, int row, List<Piece> pieces)
        {
            for (int col = 0; col < 8; col++)
            {
                var tile = new Tile(row, col);
                var pawn = new Pawn(color, tile);
                pieces.Add(pawn);
            }
        }


        private void SetupBackRow(Color color, int row, List<Piece> pieces)
        {
            pieces.Add(new Rook(color, new Tile(row, 0)));
            pieces.Add(new Knight(color, new Tile(row, 1)));
            pieces.Add(new Bishop(color, new Tile(row, 2)));
            pieces.Add(new Queen(color, new Tile(row, 3)));
            pieces.Add(new King(color, new Tile(row, 4)));
            pieces.Add(new Bishop(color, new Tile(row, 5)));
            pieces.Add(new Knight(color, new Tile(row, 6)));
            pieces.Add(new Rook(color, new Tile(row, 7)));
        }

    }
}
