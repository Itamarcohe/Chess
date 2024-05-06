using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class PieceFactory : IPieceFactory
    {
        private static readonly Dictionary<char, Func<Color, Tile, Piece>> pieceCreators = new Dictionary<char, Func<Color, Tile, Piece>>
    {
        { 'p', (color, tile) => new Pawn(color, tile) },
        { 'r', (color, tile) => new Rook(color, tile) },
        { 'n', (color, tile) => new Knight(color, tile) },
        { 'b', (color, tile) => new Bishop(color, tile) },
        { 'q', (color, tile) => new Queen(color, tile) },
        { 'k', (color, tile) => new King(color, tile) }
    };

        public Piece CreatePiece(char symbol, Tile tile)
        {
            Color color = char.IsUpper(symbol) ? Color.White : Color.Black;
            return CreatePieceColor(symbol, tile, color);
        }

        public Piece CreatePiece(Piece piece)
        {
            Type type = piece.GetType();

            var constructor = type.GetConstructor(new Type[] { type });

            if (constructor == null)
            {
                throw new InvalidOperationException($"No cloning constructor found for type {type.Name}");
            }

            return (Piece)constructor.Invoke(new object[] { piece });
        }

        public Piece CreatePieceColor(char symbol, Tile tile, Color color)
        {
            symbol = char.ToLower(symbol);
            if (pieceCreators.TryGetValue(symbol, out var createPiece))
            {
                return createPiece(color, tile);
            }
            else
            {
                throw new ArgumentException("Invalid piece type.");
            }
        }


    }
}
