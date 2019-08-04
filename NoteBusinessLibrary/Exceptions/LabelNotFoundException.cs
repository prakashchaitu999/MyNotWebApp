using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBusinessLibrary.Exceptions
{
   public class LabelNotFoundException : ApplicationException
    {
        public LabelNotFoundException() { }
        public LabelNotFoundException(string message) : base(message) { }
    }
}
