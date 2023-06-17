namespace QuizApp.Domain.SeedWork
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
