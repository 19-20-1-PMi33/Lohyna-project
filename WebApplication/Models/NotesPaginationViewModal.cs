using System;

namespace WebApplication.Models
{
    public class NotesPaginationViewModal
    {
        public int PageNumber {get; private set;}
        public int TotalPages {get; private set;}
        
        public NotesPaginationViewModal(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
 
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}