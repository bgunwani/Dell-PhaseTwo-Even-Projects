using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreCodeFirstRelationshipsApplications.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public float BookPrice { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
