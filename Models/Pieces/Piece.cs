using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public abstract class Piece : IPiece
    {
        public Color Color { get; private set; }
        public Tile TilePosition { get; private set; }
        public bool HasMoved { get; set; }
        protected Piece(Piece otherpiece)
        {
            this.Color = otherpiece.Color;
            this.TilePosition = otherpiece.TilePosition;
            this.HasMoved = otherpiece.HasMoved;
        }
        protected Piece(Color color, Tile tilePosition)
        {
            Color = color;
            TilePosition = tilePosition;
        }
        protected Piece(Piece piece, Tile tilePosition)
        {
            Color = piece.Color;
            TilePosition = tilePosition;
            HasMoved = true;
        }
        protected abstract char GetSymbolInternal();
        public char GetSymbol()
        {
            var symbol = GetSymbolInternal();
            return Color.Equals(Color.White) ? Char.ToUpper(symbol) : Char.ToLower(symbol);
        }
        public override string ToString()
        {
            string pieceType = GetType().Name;
            string colorText = Color.ToString();
            string positionText = TilePosition.ToString();
            return $"{pieceType}, {colorText}, {positionText}";
        }
    }
}
