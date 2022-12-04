using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Model.users
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? VendorId { get; set; }
        public int? CustomerId { get; set; }
        public int? StaffId { get; set; }
    }
}
