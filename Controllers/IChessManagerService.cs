using Chess_Backend.Models.Movements;

namespace Chess_Backend.Controllers
{
    public interface IChessManagerService
    {
        string GetInitialFen();
        (bool success, string? fen, string? errorMessage) ProcessMove(MoveRequest request);
    }
}
