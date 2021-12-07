using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreViewModelApplication.Models
{
    public class StudentAddressModel
    {
        public Student Student { get; set; }
        public Address Address { get; set; }
        public string Message { get; set; }
    }
}
