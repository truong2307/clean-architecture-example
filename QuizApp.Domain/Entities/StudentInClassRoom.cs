using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class StudentInClassRoom : Entity
    {
        private string _studentId;
        private int _classRoomId;

        public StudentInClassRoom(string studentId, int classRoomId)
        {
            _studentId = studentId;
            _classRoomId = classRoomId;
        }
    }
}
