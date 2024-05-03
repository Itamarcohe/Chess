//using Chess_Backend.Models;
//using Chess_Backend.Models.Pieces;
//using Chess_Backend.Models.Positions;

//namespace Chess_Backend.Services
//{
//    public  class GameManager
//    {
//        private Board _board;
//        public string CurrentFen => _board.BoardToFen(); // Dynamically get the FEN from the board

//        public GameManager()
//        {
//            _board = new Board();
//            _board.InitializePieces(); // Set up the board with initial positions
//        }



//        public bool TryMakeMove(string from, string to, out string newFen)
//        {
//            Tile fromTile = PositionToIndex(from);
//            Tile toTile = PositionToIndex(to);

//            // Get the piece at the 'from' position
//            Piece piece = _board.GetPieceByTilePosition(fromTile);

//            // Validate the move based on piece type
//            if (piece != null && ValidateMove(piece, fromTile, toTile))
//            {
//                // Perform the move on the board
//                _board.MovePiece(fromTile, toTile);
//                newFen = CurrentFen;
//                return true;
//            }

//            newFen = CurrentFen;
//            return false; // Return false if not a valid move
//        }

//        private bool ValidateMove(Piece piece, Tile from, Tile to)
//        {
//            // Specific validation based on piece type
//            switch (piece)
//            {
//                case Pawn pawn:
//                    return ValidatePawnMove(pawn, from, to);
//                    // Add cases for other types of pieces
//            }

//            return false;
//        }

//        private bool ValidatePawnMove(Pawn pawn, Tile from, Tile to)
//        {
//            // Implement pawn-specific move validation logic
//            // Placeholder logic for basic forward move
//            int direction = pawn.Color == Color.White ? 1 : -1;
//            int rowDiff = to.Row - from.Row;
//            int colDiff = Math.Abs(to.Column - from.Column);

//            if (colDiff == 0 && rowDiff == direction) // Move forward to an empty square
//            {
//                return !_board.IsTileOccupied(to);
//            }

//            return false;
//        }

//        private Tile PositionToIndex(string position)
//        {
//            int column = position[0] - 'a';
//            int row = 8 - (position[1] - '0'); // Adjusting to 0-based index
//            return new Tile(row, column);
//        }
//    }

//}
