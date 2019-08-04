using Entity;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IMyNoteHandler

    {
        MyNote GetNoteById(int noteId);
        List<MyNote> GetAllNotes(); 
        int CreateNote(MyNote mynote );
        int RemoveNoteById(int noteid);
        int UpdateNoteById(MyNote mynote);

       

    }
}
