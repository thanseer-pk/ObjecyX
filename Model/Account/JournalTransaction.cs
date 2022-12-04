using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Model.Account
{
    public class JournalTransaction
    {
        public int Id { get; set; }
        public double DebitAmount { get; set; }
        public double CreditAmount { get; set; }
        public int AccountId { get; set; }
        public int? ComplimentAccountId { get; set; }
        public int? JournalDocumentId { get; set; }
    }
}
