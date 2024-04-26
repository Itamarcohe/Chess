using Chess_Backend.Models.Positions;

namespace Chess_Backend.Utils
{
    public static class ChessNotationConverter
    {
        public static Tile ConvertToTile(string position)
        {
            if (position.Length != 2)
            {
                throw new ArgumentException("Invalid chess position.");
            }

            int column = position[0] - 'a'; // Convert 'a' to 'h' into 0 to 7
            int row = position[1] - '1'; // Convert '1' to '8' into 0 to 7

            if (column < 0 || column > 7 || row < 0 || row > 7)
            {
                throw new ArgumentException("Chess position out of board range.");
            }

            return new Tile(row, column);
        }

    }
}
