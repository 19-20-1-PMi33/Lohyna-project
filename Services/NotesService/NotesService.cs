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
        public async Task<List<Model.Note>> LoadNotesAsync()
        {
            return new List<Model.Note>()
            {
                new Model.Note{Name = "PI note",Created = DateTime.Now, Deadline = DateTime.Now, Materials = "Bla-bla-bla", Finished = true, SubjectID = "PI", PersonID = "1234"}
            };
        }
    }
}