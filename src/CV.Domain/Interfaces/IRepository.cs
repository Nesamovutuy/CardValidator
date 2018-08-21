namespace CardValidator.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
