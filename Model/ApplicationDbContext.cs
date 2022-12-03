using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjecyX.Model
{
    public class ApplicationDbContext
    {
        public String connectionString { get; set; } = "Data Source=DESKTOP-B47LD6V\\SQLEXPRESS; Database=objecyx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            

        public ApplicationDbContext()
        {

        }

    }
}
