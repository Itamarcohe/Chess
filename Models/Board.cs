using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
namespace Chess_Backend.Models
{
    public class Board : IBoard
    {
        public List<Piece> Pieces { get; private set; }
        public Dictionary<Tile, Piece> Positions { get; private set; }
        public Color CurrentTurnColor { get; private set; }

        public Board()
        {
            Pieces = new List<Piece>();
            Positions = new Dictionary<Tile, Piece>();
            MapPiecesToDictionary();

        }

        public Board(List<Piece> pieces, Color currentTurnColor)
        {
            this.Pieces = pieces;
            this.CurrentTurnColor = currentTurnColor;
            Positions = new Dictionary<Tile, Piece>();
            MapPiecesToDictionary();
        }

        private void MapPiecesToDictionary()
        {
            foreach (Piece piece in Pieces)
            {
                Positions[piece.TilePosition] = piece;
            }
        }

        public Piece? GetPieceByTilePosition(Tile tile)
        {
            Positions.TryGetValue(tile, out Piece piece);
            return piece;
        }
        public Piece? GetPieceByTilePosition(int row, int column)
        {
            return GetPieceByTilePosition(new Tile(column, row));
        }

        public bool IsTileOccupied(Tile tile)
        {
            return Positions.ContainsKey(tile);
        }
        public bool IsTileOccupied(int row, int column)
        {
            return Positions.ContainsKey(new Tile(column, row));
        }
    }
}
