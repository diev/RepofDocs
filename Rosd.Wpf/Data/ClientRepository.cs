using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rosd.Wpf.Data;

public class ClientRepository : IRepository<Client>
{
    public void Add(Client t)
    {
        throw new NotImplementedException();
    }

    public Client Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Client> GetAll()
    {
        //const string pattern = @"(.*)\s+\(\s*ИНН\s+(\d*)\s*\)";
        const string pattern = @"(.*)\s\(ИНН\s(\d*)\)";

        string clientsPath = App.Configuration[nameof(clientsPath)];
        var result = new List<Client>();

        if (Directory.Exists(clientsPath))
        {
            int id = 0;
            var dirs = new DirectoryInfo(clientsPath).GetDirectories();

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

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Client t)
    {
        throw new NotImplementedException();
    }
}
