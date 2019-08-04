using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface IMyLabelHandler
    {
        MyLabel GetLabelById(int labelId);
        List<MyLabel> GetAllLabels();
        int CreateLabel(MyLabel mylabel);
        int RemoveLabelById(int noteid);
        int UpdateLabelById(MyLabel mylabel);

    }
}
