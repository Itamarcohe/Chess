using System.Data.Common;

namespace Chess_Backend.Models.Positions
{
    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }


        public Tile(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            Tile other = (Tile)obj;
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Row.GetHashCode();
                hash = hash * 23 + Column.GetHashCode();
                return hash;
            }
        }

    }

}
