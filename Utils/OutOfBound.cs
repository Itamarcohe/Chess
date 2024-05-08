using Chess_Backend.Models.Positions;

namespace Chess_Backend.Utils
{
    public static class BoardUtils
    {
        public static bool IsWithinBoardBounds(Tile tile)
        {
            return IsWithinBoardBounds(tile.Column, tile.Row);
        }

        public static bool IsWithinBoardBounds(int column, int row)
        {
            return column >= 0 && column <= 7 && row >= 0 && row <= 7;
        }
    }
}
