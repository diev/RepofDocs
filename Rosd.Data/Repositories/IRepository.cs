namespace Rosd.Data.Repositories;

public interface IRepository<T>
{
    T? Get(int id);
    IList<T> GetAll();
    int Create(T t);
    void Create(IList<T> t);
    void Update(T t);
    void Delete(int id);
    void Export(string filename);
    void Import(string filename);
}
