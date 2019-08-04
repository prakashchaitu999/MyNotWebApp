using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBusinessLibrary
{
    public interface IMyLabelService
    {
        MyLabel GetLabelById(int noteId);
        List<MyLabel> GetAllLabels();
        int CreateLabel(MyLabel mynote);
        int RemoveLabelById(int noteid);
        int UpdateLabelById(MyLabel mynote);
    }
}
