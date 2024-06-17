using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using System.Text;

namespace Chess_Backend.Services.BoardServices
{
    public class BoardParserService : IBoardParserService
    {
        public string BoardToFen(IBoard board)
        {
            StringBuilder fenStringBuilder = new StringBuilder();
            for (int row = 7; row >= 0; row--)
            {
                fenStringBuilder.Append(ProcessRow(board, row));
                if (row > 0)
                {
                    fenStringBuilder.Append('/');
                }
            }
            fenStringBuilder.Append(FormatTurn(board.CurrentTurnColor));
            return fenStringBuilder.ToString();
        }
        private string ProcessRow(IBoard board, int row)
        {
            StringBuilder rowBuilder = new StringBuilder();
            int emptyCount = 0;
            for (int col = 0; col <= 7; col++)
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
                        rowBuilder.Append(emptyCount);
                        emptyCount = 0;
                    }
                    rowBuilder.Append(piece.GetSymbol());
                }
            }
            if (emptyCount != 0)
            {
                rowBuilder.Append(emptyCount);
            }
            return rowBuilder.ToString();
        }
        private string FormatTurn(Color turn) => turn == Color.White ? " W" : " B";

    }
}

