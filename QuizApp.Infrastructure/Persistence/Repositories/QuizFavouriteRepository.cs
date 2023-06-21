using QuizApp.Domain.Entities;
using QuizApp.Domain.IRepository;

namespace QuizApp.Infrastructure.Persistence.Repositories
{
    public class QuizFavouriteRepository : Repository<QuizFavourite>, IQuizFavouriteRepository
    {
        private readonly WiQuizDbContext _context;
        public QuizFavouriteRepository(WiQuizDbContext context) : base(context)
        {
        }
    }
}
