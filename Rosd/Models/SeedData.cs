using Helpers;

using Microsoft.EntityFrameworkCore;

using Rosd.Data;
using Rosd.Helpers;

namespace Rosd.Models;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        //await context.Database.EnsureDeletedAsync();
        //await context.Database.EnsureCreatedAsync();

        context.Database.Migrate();

        DateTime date = DateTime.UtcNow;
        //string source = Environment.ExpandEnvironmentVariables("%TEMP%");
        //string source = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TEST\"; //debug Windows
        string source = "/root/test/"; //debug Linux
        int baselen = source.Length;
        EnumerationOptions ignoreInaccessible = new();

        if (!context.Incomes.Any())
        {
            await context.Incomes.AddAsync(new()
            {
                Id = Guid.Parse(Uuid.Uuid7(date,0,"001")),
                Date = date,
                Subject = "Test Входящих"
            });
        }

        if (!context.Outcomes.Any())
        {
            await context.Outcomes.AddAsync(new()
            {
                Id = Guid.Parse(Uuid.Uuid7(date, 0, "002")),
                Date = date,
                Subject = "Test Исходящих"
            });
        }

        if (!context.Docs.Any())
        {
            var root = new Doc()
            {
                Id = Guid.Parse(Uuid.Empty), // Guid.Empty fails!
                IsContainer = true,
                Title = Consts.RootName,
                Ext = "."
            };

            await context.Docs.AddAsync(root);

            await ProcessDirAsync(new DirectoryInfo(source), root);
        }

        context.SaveChanges();

        async Task ProcessDirAsync(DirectoryInfo di, Doc parent)
        {
            Guid id = Guid.Parse(Uuid.Uuid5(di)); //debug only!
                                             //Guid id = Guid.NewGuid(); //release

            var folder = new Doc()
            {
                Id = id,
                Title = di.Name,
                //DebugParentId = parent.Id, //debug only!
                IsContainer = true,
                Ext = ".",
                Note = di.FullName[baselen..] //LoadPath = di.FullName
            };

            await context.Docs.AddAsync(folder);

            parent.Docs ??= new List<Doc>();
            parent.Docs.Add(folder);

            Console.WriteLine(di.FullName);

            foreach (var file in di.EnumerateFiles("*", ignoreInaccessible))
            {
                await ProcessFileAsync(file, folder);
            }

            foreach (var dir in di.EnumerateDirectories("*", ignoreInaccessible))
            {
                await ProcessDirAsync(dir, folder);
            }
        }

        async Task ProcessFileAsync(FileInfo fi, Doc parent)
        {
            string ext = fi.Extension;
            int len = fi.Name.Length - ext.Length;
            string name = fi.Name[..len];
            string type = ext[1..].ToLower();
            Guid hash;

            try
            {
                hash = Guid.Parse(Uuid.Uuid5(fi));
            }
            catch
            {
                Console.WriteLine($"Error {fi.FullName}");
                return;
            }

            var doc1 = await context.Docs.FindAsync(hash);
            //var doc1 = context.Docs.FirstOrDefault(d => d.Hash == hash);
            if (doc1 != null)
            {
                //doc1.DebugParentId = parent.Id; //debug only!
                if (doc1.Title != name)
                {
                    doc1.Title = $"{doc1.Title}; {name}";
                }
                doc1.Note = $"{doc1.Note}; {fi.FullName[baselen..]}";

                parent.Docs ??= new List<Doc>();
                parent.Docs.Add(doc1);
                return;
            }

            var doc = new Doc()
            {
                Id = hash,
                Title = name,
                Hash = hash, //? //or restructure to replace records?
                             //DebugParentId = parent.Id, //debug only!
                             //LoadPath = fi.FullName,
                Note = fi.FullName[baselen..],
                Ext = type,
                IsArchive = Consts.archives.Contains(type),
                Date = fi.LastWriteTimeUtc
            };

            parent.Docs ??= new List<Doc>();
            parent.Docs.Add(doc);

            await context.Docs.AddAsync(doc);
            //await context.SaveChangesAsync(); //save Hash for FirstOrDefault to work! not required for Find
        }
    }
}
