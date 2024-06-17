using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using System.Collections.Immutable;

namespace Chess_Backend.Services.MovementHistory
{
    public interface IMovementHistoryService
    {
        public ImmutableList<Movement> getHistory();
        public Movement getLast();
    }
}
