using Chess_Backend.Models;

namespace Chess_Backend.Services.BoardServices
{
    public interface IBoardHolder
    {
        IBoard GetBoard();
        void SetBoard(IBoard board);

    }
}
