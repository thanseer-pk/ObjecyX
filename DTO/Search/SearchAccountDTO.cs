using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.DTO.Search
{
    public class SearchAccountDTO
    {
        public string? SearchKey { get; set; }
        public int TakeCount { get; set; }
        public int SkipCount { get; set; }

    }
}
