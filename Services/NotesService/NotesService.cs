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

        public async Task CreateNoteAsync(Model.Note note)
        {
            _unitOfWork.Notes.CreateNoteAsync(note);
            await _unitOfWork.CommitAsync();
        }
        
        public void DeleteNoteAsync(Model.Note note)
        {
            _unitOfWork.Notes.DeleteNoteAsync(note);
            _unitOfWork.CommitAsync().Wait();
        }

        public void UpdateNoteAsync(Model.Note note)
        {
            _unitOfWork.Notes.UpdateNoteAsync(note);
            _unitOfWork.CommitAsync().Wait();
        }
        

        public async Task<IList<Model.Subject>> LoadSubjectsAsync()
        {
            return await _unitOfWork.Subjects.LoadSubjectsAsync();
        }
    }
}