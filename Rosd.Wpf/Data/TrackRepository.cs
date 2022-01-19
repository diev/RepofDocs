using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosd.Wpf.Data;

public class TrackRepository : IRepository<Track>
{
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

    public Track? Get(int id)
    {
        using var db = new ApplicationDbContext();
        return db.Tracks.Find(id);
    }

    public List<Track> GetAll()
    {
        using var db = new ApplicationDbContext();
        return db.Tracks.ToList();
    }

    public void Add(Track t)
    {
        if (t != null)
        {
            using var db = new ApplicationDbContext();
            db.Tracks.Add(t);
            db.SaveChanges();
        }
    }

    public void Add(List<Track> t)
    {
        using var db = new ApplicationDbContext();
        db.Tracks.AddRange(t);
        db.SaveChanges();
    }

    public void Update(Track t)
    {
        var tFind = Get(t.Id);

        if (tFind != null)
        {
            tFind.IDate = t.IDate;
            tFind.INo = t.INo;
            tFind.Via = t.Via;
            tFind.Sender = t.Sender;
            tFind.SendDate = t.SendDate;
            tFind.SendNo = t.SendNo;
            tFind.Attn = t.Attn;
            tFind.Client = t.Client;
            tFind.INN = t.INN;
            tFind.Content = t.Content;
            tFind.Person = t.Person;
            tFind.Notes = t.Notes;
            tFind.JDate = t.JDate;
            tFind.JNo = t.JNo;
            tFind.JSubject = t.JSubject;
            tFind.RDate = t.RDate;
            tFind.ODate = t.ODate;
            tFind.ONo = t.ONo;
            tFind.Receiver = t.Receiver;
            tFind.OSubject = t.OSubject;

            using var db = new ApplicationDbContext();
            db.SaveChanges();
        }
    }

    public void Remove(int id)
    {
        using var db = new ApplicationDbContext();
        var tFind = db.Tracks.Find(id);

        if (tFind != null)
        {
            db.Tracks.Remove(tFind);
            db.SaveChanges();
        }
    }

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
        var data = new List<Track>();
        using var reader = new StreamReader(filename);
        string? line = reader.ReadLine(); // skip headers //TODO: check headers

        while ((line = reader.ReadLine()) != null)
        {
            var items = line.Split('\t');
            int i = 0;

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
        Add(data);
    }
}
