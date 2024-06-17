using Chess_Backend.Models.Movements;
using System.Collections.Immutable;
using System.Linq;

namespace Chess_Backend.Services.MovementHistory
{
    public class MovementHistory
    {
        private ImmutableList<Movement> _movementHistory;
        public MovementHistory()
        {
            _movementHistory = ImmutableList<Movement>.Empty;
        }
        public void Push(Movement movement)
        {
            if (_movementHistory.Count >= 3)
            {
                _movementHistory = _movementHistory.RemoveAt(0); 
            }
            _movementHistory = _movementHistory.Add(movement); 
        }
        public ImmutableList<Movement> GetHistory()
        {
            return _movementHistory;
        }
    }
}
