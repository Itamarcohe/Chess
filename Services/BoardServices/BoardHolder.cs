using Chess_Backend.Models;

namespace Chess_Backend.Services.BoardServices
{
    public class BoardHolder : IBoardHolder
    {
        private IBoard? board;
        public IBoard GetBoard()
        {
            if (board == null)
            {
                throw new Exception("The board has not been set. ");
            }
            return board;
        }
        public void SetBoard(IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board), "Cannot set the board to null.");
            }

            this.board = board;
        }
    }
}
