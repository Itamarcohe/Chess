using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Movements
{
        public abstract class Movement
        {
            public Tile From { get; private set; }
            public Tile To { get; private set; }
            protected Movement(Tile from, Tile to)
            {
                From = from;
                To = to;
            }
    }
}
