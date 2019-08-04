using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Entity;
using NoteBusinessLibrary.Exceptions;

namespace NoteBusinessLibrary
{
    public class MyLabelService : IMyLabelService
    {
        private readonly IMyLabelHandler repository;
        public MyLabelService(IMyLabelHandler myLabelHandler)
        {
            repository = myLabelHandler;
        }
        public int CreateLabel(MyLabel mylabel)
        {
            var _mynote = repository.GetLabelById(mylabel.LabelId);
            if (_mynote == null)
            {
                return repository.CreateLabel(mylabel);
            }
            else
            {
                throw new LabelAlreadyExistsException($"Note with id :{mylabel.LabelId} already exists");
            }
        }

        public List<MyLabel> GetAllLabels()
        {
            return repository.GetAllLabels();
        }

        public MyLabel GetLabelById(int labelId)
        {
            var _mylabel = repository.GetLabelById(labelId);
            if (_mylabel == null)
            {
                throw new LabelNotFoundException($"Note with id : {labelId} doesn't exists");
            }
            else
            {
                return _mylabel;
            }
        }

        public int RemoveLabelById(int labelId)
        {
            var _mylabel = repository.GetLabelById(labelId);
            if (_mylabel == null)
            {
                throw new LabelNotFoundException($"Note with id : {labelId} doesn't exists");
            }
            else
            {
                return repository.RemoveLabelById(labelId);
            }
        }

        public int UpdateLabelById(MyLabel mylabel)
        {
            var _mylabel = repository.GetLabelById(mylabel.LabelId);
            if (_mylabel == null)
            {
                throw new LabelNotFoundException($"Note with id : {mylabel.LabelId} doesn't exists");
            }
            else
            {
                _mylabel.LabelName = mylabel.LabelName;
                _mylabel.LabelDescription = mylabel.LabelDescription;
                _mylabel.LabelDate = mylabel.LabelDate;
                return repository.UpdateLabelById(_mylabel);
            }
        }
    }
}
