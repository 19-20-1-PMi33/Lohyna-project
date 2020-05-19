using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.DTO;
using Repositories.UnitOfWork;

namespace Services.NotesService
{
    public class NotesService : INotesService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapNotes;

        public NotesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapNotes = mapper;
        }
        public Task<IList<Model.Note>> LoadNotesAsync(string username)
        {
            var notesList = _unitOfWork.Notes.LoadNotesAsync(username);
            return notesList;
        }
    }
}