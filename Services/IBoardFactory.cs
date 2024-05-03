using Chess_Backend.Models;
using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services
{
    public interface IBoardFactory
    {
        public IBoard InitializeNewBoard();
        public IBoard CreateNewBoard(IBoard board, Movement movement);
    }
}
