using Chess_Backend.Models;

namespace Chess_Backend.Services
{
    public interface IBoardParserService
    {
        public string BoardToFen(Board board);

    }
}
