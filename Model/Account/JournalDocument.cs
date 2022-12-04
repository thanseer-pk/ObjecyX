using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Model.Account
{
    internal class JournalDocument
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }
}
