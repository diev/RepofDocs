using System.Collections.Generic;
using System.Linq;

namespace Rosd.Wpf.Data;

public class TrackRepository : IRepository<Track>
{
    public Track Get(int id)
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
}
