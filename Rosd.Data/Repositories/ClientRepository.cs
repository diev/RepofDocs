using Rosd.Data.Entities;

using System.Text.RegularExpressions;

namespace Rosd.Data.Repositories;

public class ClientRepository : IRepository<Client>
{
    private readonly string _path;

    public ClientRepository(string path)
    {
        _path = path;
    }

    public Client? Get(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Client> GetAll()
    {
        //const string pattern = @"(.*)\s+\(\s*ИНН\s+(\d*)\s*\)";
        const string pattern = @"(.*)\s\(ИНН\s(\d*)\)";

        var result = new List<Client>();

        if (Directory.Exists(_path))
        {
            int id = 0;
            var dirs = new DirectoryInfo(_path).GetDirectories();

            foreach (var di in dirs)
            {
                var item = di.Name.Trim();
                var match = Regex.Match(item, pattern);

                if (match.Success)
                {
                    result.Add(new Client
                    {
                        Id = ++id,
                        Title = match.Groups[1].Value,
                        INN = match.Groups[2].Value
                    });
                }
                else
                {
                    result.Add(new Client
                    {
                        Id = ++id,
                        Title = item,
                        INN = string.Empty
                    });
                }
            }
        }

        return result;
    }

    public void Update(Client t)
    {
        throw new NotImplementedException();
    }

    public int Create(Client t)
    {
        throw new NotImplementedException();
    }

    public void Create(IList<Client> t)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Export(string filename)
    {
        throw new NotImplementedException();
    }

    public void Import(string filename)
    {
        throw new NotImplementedException();
    }
}
