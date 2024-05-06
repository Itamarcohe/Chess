using Chess_Backend.Models;

namespace Chess_Backend.Services
{
    public class BoardHolder : IBoardHolder
    {
        private IBoard board;

        public IBoard GetBoard()
        {
            if (board == null)
            {
                throw new Exception("No board ");
            }

            return board;
        }

        public void SetBoard(IBoard board)
        {
            this.board = board;
        }
    }
}
