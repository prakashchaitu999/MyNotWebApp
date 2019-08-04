using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBusinessLibrary.Exceptions
{
   public class NoteAlreadyExistsException :ApplicationException
    {
        public NoteAlreadyExistsException() { }
        public NoteAlreadyExistsException(string message) : base(message) { }
    }
}
