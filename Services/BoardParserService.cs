using Chess_Backend.Models;
using Chess_Backend.Models.Pieces;
using System.Text;

namespace Chess_Backend.Services
{
    public class BoardParserService : IBoardParserService
    {
        public string BoardToFen(Board board)
        {
            var fenStringBuilder = new StringBuilder();
            for (int row = 0; row < 8; row++)
            {
                int emptyCount = 0;
                for (int col = 0; col < 8; col++)
                {
                    Piece? piece = board.GetPieceByTilePosition(row, col);
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
                    fenStringBuilder.Append(emptyCount);
                }
                if (row < 7)
                {
                    fenStringBuilder.Append('/');
                }
            }
            return fenStringBuilder.ToString();
        }
    }
}
