namespace QuizApp.Domain.Entities
{
    public class QuizClassRoom
    {
        private int _quizId;
        private int _classRoomId;

        public QuizClassRoom(int quizId, int classRoomId)
        {
            _quizId = quizId;
            _classRoomId = classRoomId;
        }
    }
}
