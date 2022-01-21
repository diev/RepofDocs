using Microsoft.EntityFrameworkCore;

using Rosd.Data.Entities;

namespace Rosd.Data.Repositories;

public class TrackRepository : IRepository<Track>
{
    private readonly Func<RosdDbContext> _createDbContext;

    public TrackFilter Filter { get; set; } = TrackFilter.All;

    public TrackRepository(Func<RosdDbContext> dBContextFactory)
    {
        _createDbContext = dBContextFactory;
    }

    public int Create(Track track)
    {
        if (track == null)
        {
            throw new ArgumentNullException(nameof(track), $"{nameof(track)} is null.");
        }

        using var context = _createDbContext();
        context.Tracks.Add(track);
        _ = context.SaveChanges();

        return track.Id;
    }

    public void Create(IList<Track> tracks)
    {
        if (tracks == null)
        {
            throw new ArgumentNullException(nameof(tracks), $"{nameof(tracks)} is null.");
        }

        if (tracks.Count == 0)
        {
            throw new ArgumentException($"{nameof(tracks)} is empty.", nameof(tracks));
        }

        using var context = _createDbContext();
        context.Tracks.AddRange(tracks);
        _ = context.SaveChanges();
    }

    public IList<Track> GetAll()
    {
        using var context = _createDbContext();
        return Filter switch
        {
            TrackFilter.Inc => context.Tracks
                .Where(x => x.INo != 0)
                .OrderBy(a => a.INo)
                .ToList(),

            TrackFilter.Jrl => context.Tracks
                .Where(x => !string.IsNullOrEmpty(x.JNo))
                .OrderBy(a => a.JDate)
                .ThenBy(b => b.JNo)
                .ToList(),

            TrackFilter.Rep => context.Tracks
                .Where(x => !string.IsNullOrEmpty(x.RDate))
                .OrderBy(a => a.RDate)
                .ToList(),

            TrackFilter.Out => context.Tracks
                .Where(x => !string.IsNullOrEmpty(x.ONo))
                .OrderBy(a => a.ODate)
                .ThenBy(b => b.ONo)
                .ToList(),

            _ => context.Tracks.ToList(),
        };
    }

    public Track? Get(int id)
    {
        using var context = _createDbContext();
        return context.Tracks.Find(id);
    }

    public void Update(Track track)
    {
        if (track == null)
        {
            throw new ArgumentNullException(nameof(track), $"{nameof(track)} is null.");
        }

        using var context = _createDbContext();
        context.Entry(track).State = EntityState.Modified;
        _ = context.SaveChanges();
    }

    public void Delete(Track track)
    {
        if (track == null)
        {
            throw new ArgumentNullException(nameof(track), $"{nameof(track)} is null.");
        }

        using var context = _createDbContext();
        context.Entry(track).State = EntityState.Deleted;
        _ = context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = _createDbContext();
        context.Tracks.Remove(new Track { Id = id });
        _ = context.SaveChanges();
    }

    public static readonly string[] Fields =
    {
        "Id",
        "IDate",
        "INo",
        "Via",
        "Sender",
        "SendDate",
        "SendNo",
        "Attn",
        "Client",
        "INN",
        "Content",
        "Person",
        "Notes",
        "JDate",
        "JNo",
        "JSubject",
        "RDate",
        "ODate",
        "ONo",
        "Receiver",
        "OSubject"
    };

    public void Export(string filename)
    {
        var data = GetAll();
        using var writer = new StreamWriter(filename);

        writer.WriteLine(string.Join('\t', Fields)); // headers

        foreach (var t in data)
        {
            writer.WriteLine(string.Join('\t',
                t.Id.ToString(),
                t.IDate,
                t.INo.ToString(),
                t.Via,
                t.Sender,
                t.SendDate,
                t.SendNo,
                t.Attn,
                t.Client,
                t.INN,
                t.Content,
                t.Person,
                t.Notes,
                t.JDate,
                t.JNo,
                t.JSubject,
                t.RDate,
                t.ODate,
                t.ONo,
                t.Receiver,
                t.OSubject
            ));
        }

        writer.Flush();
        writer.Close();
    }

    public void Import(string filename)
    {
        int i;
        var data = new List<Track>();
        using var reader = new StreamReader(filename);
        string? line = reader.ReadLine(); // skip headers //TODO: check headers

        while ((line = reader.ReadLine()) != null)
        {
            var items = line.Split('\t');
            i = 0;

            data.Add(new()
            {
                Id = int.Parse(items[i++]),
                IDate = items[i++],
                INo = int.Parse(items[i++]),
                Via = items[i++],
                Sender = items[i++],
                SendDate = items[i++],
                SendNo = items[i++],
                Attn = items[i++],
                Client = items[i++],
                INN = items[i++],
                Content = items[i++],
                Person = items[i++],
                Notes = items[i++],
                JDate = items[i++],
                JNo = items[i++],
                JSubject = items[i++],
                RDate = items[i++],
                ODate = items[i++],
                ONo = items[i++],
                Receiver = items[i++],
                OSubject = items[i++]
            });
        }

        reader.Close();
        Create(data);
    }
}
