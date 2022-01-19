using System.Collections.Generic;

namespace Rosd.Wpf.Data;

public interface IRepository<T>
{
    T? Get(int id);
    List<T> GetAll();
    void Add(T t);
    void Add(List<T> t);
    void Update(T t);
    void Remove(int id);
    void Export(string filename);
    void Import(string filename);
}
