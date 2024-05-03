using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
namespace Chess_Backend.Models
{
    public class Board : IBoard
    {
        public List<Piece> Pieces { get; private set; }
        public Dictionary<Tile, Piece> Positions { get; private set; }


        public Board()
        {
        }

        public Board(List<Piece> pieces)
        {
            this.Pieces = pieces;
            Positions = new Dictionary<Tile, Piece>();
            MapPiecesToDictionary();
        }

        public void MapPiecesToDictionary()
        {
            Console.WriteLine("Intalized Map to dictiornary entered");
            foreach (Piece piece in Pieces)
            {
                Positions[piece.TilePosition] = piece;
            }

            Console.WriteLine("Positions dictionary after intializzeed: {0}", Positions.Count());

        }

        public Piece? GetPieceByTilePosition(Tile tile)
        {
            Positions.TryGetValue(tile, out Piece piece);
            return piece;
        }
        public Piece? GetPieceByTilePosition(int row, int column)
        {
            return GetPieceByTilePosition(new Tile(row, column));
        }

        public bool IsTileOccupied(Tile tile)
        {
            return Positions.ContainsKey(tile);
        }
        public bool IsTileOccupied(int row, int column)
        {
            return Positions.ContainsKey(new Tile(row, column));
        }
    }
}
