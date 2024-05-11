using Chess_Backend.Models;

namespace Chess_Backend.Services.BoardServices
{
    public interface IBoardParserService
    {
        public string BoardToFen(IBoard board);
    }
}
