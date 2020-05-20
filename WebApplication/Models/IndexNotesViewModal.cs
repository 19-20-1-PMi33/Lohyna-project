using System;
using System.Collection.Generics;
namespace WebApplication.Models
{
    public class IndexNotesViewModal
    {
        public IEnumerable<Model.Note> Notes {get; set;}
        public SortNotesViewModal SortNotesViewModal{get; set;}
        public NotesPaginationViewModal NotesPaginationViewModal {get; set;}  
    }
}