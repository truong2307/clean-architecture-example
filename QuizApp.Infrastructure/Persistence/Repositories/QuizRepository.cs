using QuizApp.Domain.Entities;
using QuizApp.Domain.IRepository;

namespace QuizApp.Infrastructure.Persistence.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private readonly WiQuizDbContext _context;
        public QuizRepository(WiQuizDbContext context) : base(context)
        {
        }
    }
}
