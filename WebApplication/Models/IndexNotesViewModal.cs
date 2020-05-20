using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class IndexNotesViewModal
    {
        public List<Model.Note> Notes {get; set;}
        public SortNotesViewModal SortNotesViewModal{get; set;}
        public NotesPaginationViewModal NotesPaginationViewModal {get; set;}  
    }
}