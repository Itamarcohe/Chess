using Chess_Backend.Models.Movements;
using System.Collections.Immutable;

namespace Chess_Backend.Services.MovementHistory
{
    public class MovementHistoryService : IMovementHistoryService, IOnMovementFinshedListener
    {

        private ImmutableList<Movement> _movementHistory;
        public MovementHistoryService()
        {
            _movementHistory = ImmutableList<Movement>.Empty;
        }
        public void onMovementFinishedListener(Movement movement)
        {
            if (_movementHistory.Count >= 3)
            {
                _movementHistory = _movementHistory.RemoveAt(0);
            }
            _movementHistory = _movementHistory.Add(movement);
        }
        public Movement getLast()
        {
            return _movementHistory.Last();
        }
        public ImmutableList<Movement> getHistory()
        {
            return _movementHistory;
        }

    }
}
