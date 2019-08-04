using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyLabelHandler : IMyLabelHandler
    {
        private readonly NoteDbContext Dbobj;
       

        public MyLabelHandler(NoteDbContext noteDbContext)
        {
            Dbobj = noteDbContext;
        }
        public int CreateLabel(MyLabel labelId)
        {
            Dbobj.MyLabels.Add(labelId);
            return Dbobj.SaveChanges();
        }

        public MyLabel GetLabelById(int LId)
        {

            return Dbobj.MyLabels.Find(LId);
        }

        public List<MyLabel> GetAllLabels()
        {
            return Dbobj.MyLabels.ToList();
        }

        public int RemoveLabelById(int removeId)
        {
            var noteGetId = Dbobj.MyLabels.Find(removeId);
            Dbobj.MyLabels.Remove(noteGetId);
            return Dbobj.SaveChanges();
        }

        public int UpdateLabelById(MyLabel updateId)
        {
            Dbobj.Entry<MyLabel>(updateId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Dbobj.SaveChanges();
        }
    }
}
