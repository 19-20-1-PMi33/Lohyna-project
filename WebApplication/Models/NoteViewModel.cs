using System.Collections.Generic;

namespace WebApplication.Models
{
    public class NoteViewModel
    {
        public List<Model.Note> notesList{get;set;}
        public List<Model.Group> groupList {get;set;}        
    }
}