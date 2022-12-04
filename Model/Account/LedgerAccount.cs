using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Model.Account
{
    public class LedgerAccount
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; } = 0.0;
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? StaffId { get; set; }
    }
}
