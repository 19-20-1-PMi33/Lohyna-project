using System;
using Core.DTO;

namespace WebApplication.Models
{
    public class SortNotesViewModal
    {
        public SortState NameSort {get; private set;}
        public SortState CreatedSort {get; private set;}
        public SortState DeadlineSort {get; private set;}
        public SortState Current {get; private set;}

        public SortNotesViewModal(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            CreatedSort = sortOrder == SortState.CreatedAsc ? SortState.CreatedDesc : SortState.CreatedAsc;
            DeadlineSort = sortOrder == SortState.DeadlineAsc ? SortState.DeadlineDesc : SortState.DeadlineAsc;
            Current = sortOrder;
        }
    }
}