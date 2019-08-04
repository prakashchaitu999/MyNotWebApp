using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyNoteHandler : IMyNoteHandler
    {
        private readonly NoteDbContext Dbobj;

        public MyNoteHandler(NoteDbContext noteDbContext)
        {
            Dbobj = noteDbContext;
        }
        public int CreateNote(MyNote noteId)
        {
            Dbobj.MyNotes.Add(noteId);
            return Dbobj.SaveChanges();
        }

        public MyNote GetNoteById(int UserId)
        {

            return Dbobj.MyNotes.Find(UserId); 
        }

        public List<MyNote> GetAllNotes()
        {
            return Dbobj.MyNotes.ToList();
        }

        public int RemoveNoteById(int removeId)
        {
            var noteGetId = Dbobj.MyNotes.Find(removeId);
            Dbobj.MyNotes.Remove(noteGetId);
            return Dbobj.SaveChanges();
        }

        public int UpdateNoteById(MyNote updateId)
        {
            Dbobj.Entry<MyNote>(updateId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Dbobj.SaveChanges();             
        }
    }
}
