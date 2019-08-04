using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBusinessLibrary.Exceptions
{
    public class NoteNotFoundException :ApplicationException
    {
        public NoteNotFoundException() { }
        public NoteNotFoundException(string message) :base(message) { }
    }
}
