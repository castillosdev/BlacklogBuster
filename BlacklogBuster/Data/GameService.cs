using Microsoft.EntityFrameworkCore;
//DB Functions
namespace BlacklogBuster.Data
{
    public class GameService
    {
        private readonly ApplicationDbContext _context;
        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Game>> GetGamesAsync(string userId)
        {
            return await _context.Games.Where(g => g.UserId == userId).ToListAsync();
        }
        public async Task AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}
