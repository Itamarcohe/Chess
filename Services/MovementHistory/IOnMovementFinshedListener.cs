using Chess_Backend.Models.Movements;

namespace Chess_Backend.Services.MovementHistory
{
    public interface IOnMovementFinshedListener
    {
        public void onMovementFinishedListener(Movement movement);
    }
}
