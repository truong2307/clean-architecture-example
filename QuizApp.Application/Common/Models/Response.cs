namespace QuizApp.Application.Common.Models
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; } = true;

        public T Result { get; set; }

        public string ErrorMessages { get; set; }
    }
}
