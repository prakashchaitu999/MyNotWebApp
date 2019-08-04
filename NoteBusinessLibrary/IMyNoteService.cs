using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBusinessLibrary
{
   public interface IMyNoteService
    {
        MyNote GetNoteById(int noteId);
        List<MyNote> GetAllNotes();
        int CreateNote(MyNote mynote);
        int RemoveNoteById(int noteid);
        int UpdateNoteById(MyNote mynote);


    }
}
