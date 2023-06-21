using QuizApp.Domain.Entities;
using QuizApp.Domain.IRepository;

namespace QuizApp.Infrastructure.Persistence.Repositories
{
    public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        private readonly WiQuizDbContext _context;
        public ClassRoomRepository(WiQuizDbContext context) : base(context)
        {
        }
    }
}
