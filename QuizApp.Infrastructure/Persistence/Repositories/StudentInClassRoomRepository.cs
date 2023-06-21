using QuizApp.Domain.Entities;
using QuizApp.Domain.IRepository;

namespace QuizApp.Infrastructure.Persistence.Repositories
{
    public class StudentInClassRoomRepository : Repository<StudentInClassRoom>, IStudentInClassRoomRepository
    {
        private readonly WiQuizDbContext _context;
        public StudentInClassRoomRepository(WiQuizDbContext context) : base(context)
        {
        }
    }
}
