using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using System.Text;

namespace Chess_Backend.Services
{
    public class BoardParserService : IBoardParserService
    {
        public string BoardToFen(IBoard board)
        {
            var fenStringBuilder = new StringBuilder();
            for (int row = 7; row >= 0; row--)
            {
                int emptyCount = 0;
                for (int col = 0; col <= 7; col++)  // Corrected loop order for columns
                {
                    Piece? piece = board.GetPieceByTilePosition(col, row);
                    if (piece == null)
                    {
                        emptyCount++;
                    }
                    else
                    {
                        if (emptyCount != 0)
                        {
                            fenStringBuilder.Append(emptyCount);
                            emptyCount = 0;
                        }
                        fenStringBuilder.Append(piece.GetSymbol());
                    }
                }
                if (emptyCount != 0)
                {
                    fenStringBuilder.Append(emptyCount);  // Append remaining empty squares at end of row
                }
                if (row > 0)  // Append '/' to separate rows, except after the last row
                {
                    fenStringBuilder.Append('/');
                }
            }

            // Append the side to move
            fenStringBuilder.Append(board.CurrentTurnColor == Color.White ? " W" : " B");

            return fenStringBuilder.ToString();
        }

    }
}



//using Chess_Backend.Models;
//using Chess_Backend.Models.Pieces;
//using System.Text;

//namespace Chess_Backend.Services
//{
//    public class BoardParserService : IBoardParserService
//    {
//        public string BoardToFen(IBoard board)
//        {
//            var fenStringBuilder = new StringBuilder();
//            for (int row = 0; row < 8; row++)
//            {
//                int emptyCount = 0;
//                for (int col = 0; col < 8; col++)
//                {
//                    Piece? piece = board.GetPieceByTilePosition(col, row);
//                    if (piece == null)
//                    {
//                        emptyCount++;
//                    }
//                    else
//                    {
//                        if (emptyCount != 0)
//                        {
//                            fenStringBuilder.Append(emptyCount);
//                            emptyCount = 0;
//                        }
//                        fenStringBuilder.Append(piece.GetSymbol());
//                    }
//                }
//                if (emptyCount != 0)
//                {
//                    fenStringBuilder.Append(emptyCount);
//                }
//                if (row < 7)
//                {
//                    fenStringBuilder.Append('/');
//                }
//            }

//            if (board.CurrentTurnColor == Color.White)
//            {
//                fenStringBuilder.Append(" W");
//            }
//            else
//            {
//                fenStringBuilder.Append(" B");
//            }

//            return fenStringBuilder.ToString();
//        }
//    }
//}
