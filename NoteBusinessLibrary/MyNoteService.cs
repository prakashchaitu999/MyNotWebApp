using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Entity;
using NoteBusinessLibrary.Exceptions;

namespace NoteBusinessLibrary
{
    public class MyNoteService : IMyNoteService
    {
        private readonly IMyNoteHandler repository;

        public MyNoteService(IMyNoteHandler myNoteHandler)
        {
            repository = myNoteHandler;

        }
        public int CreateNote(MyNote mynote)
        {
            var _mynote = repository.GetNoteById(mynote.NoteId);
            if(_mynote==null)
            {
                return repository.CreateNote(mynote);
            }
            else
            {
                throw new NoteAlreadyExistsException($"Note with id :{mynote.NoteId} already exists");
            }
        }

        public List<MyNote> GetAllNotes()
        {
            return repository.GetAllNotes();

        }

        public MyNote GetNoteById(int noteId)
        {
            var _mynote = repository.GetNoteById(noteId);
            if (_mynote == null)
            {
                throw new NoteNotFoundException($"Note with id : {noteId} doesn't exists");
            }
            else
            {
                return _mynote;
            }
        }

        public int RemoveNoteById(int noteId)
        {
            var _mynote = repository.GetNoteById(noteId);
            if (_mynote == null)
            {
                throw new NoteNotFoundException($"Note with id : {noteId} doesn't exists");
            }
            else
            {
                return repository.RemoveNoteById(noteId);
            }
        }

        public int UpdateNoteById(MyNote mynote)
        {
            var _mynote = repository.GetNoteById(mynote.NoteId);
            if (_mynote == null)
            {
                throw new NoteNotFoundException($"Note with id : {mynote.NoteId} doesn't exists");
            }
            else
            {
                _mynote.NoteName = mynote.NoteName;
                _mynote.Contact = mynote.Contact;
                _mynote.City = mynote.City;
                return repository.UpdateNoteById(_mynote);
            }

        }
    }
}
