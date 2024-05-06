using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;

namespace Chess_Backend.Services
{
    public interface IBoardFactory
    {
        public IBoard InitializeNewBoard();
        public IBoard CreateNewBoard(IBoard board, Movement movement, Color oldTurnColor);
    }
}
