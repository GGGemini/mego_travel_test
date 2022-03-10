namespace MegoTravelTest.Repositories.Base;

public interface IBaseRepository<T>
{
    IEnumerable<T> GetAll();

    IEnumerable<T> Find(Func<T, bool> func);

    void Create(IEnumerable<T> entities);
}