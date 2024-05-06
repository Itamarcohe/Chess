using Chess_Backend.Models;

namespace Chess_Backend.Services
{
    public interface IBoardHolder
    {
        IBoard GetBoard();
        void SetBoard(IBoard board);

    }
}
