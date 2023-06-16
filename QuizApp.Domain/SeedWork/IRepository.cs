namespace QuizApp.Domain.SeedWork
{
    internal interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
