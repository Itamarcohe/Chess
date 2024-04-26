    using Chess_Backend.Models.Positions;

    namespace Chess_Backend.Models.Pieces
    {
        public abstract class Piece : IPiece
        {

            public Color Color { get; private set; }
            public Tile TilePosition { get; private set; }

            protected Piece(Color color, Tile tilePosition)
            {
                Color = color;
                TilePosition = tilePosition;
            }

            protected abstract char GetInternalSymbol();

            public char GetSymbol()
            {
                var symbol = GetInternalSymbol();
                return Color.Equals(Color.White) ? Char.ToUpper(symbol) : Char.ToLower(symbol);
            }

        }
    }
