using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreCodeFirstRelationshipsApplications.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public AuthorBiography AuthorBiography { get; set; }

    }
}
