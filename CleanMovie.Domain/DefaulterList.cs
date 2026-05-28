using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain
{
    public class DefaulterList
    {
        public int DefId { get; set; }
        public string DefType { get; set; } = string.Empty;
        public string DefName { get; set; } = string.Empty;
        public DateOnly DefaultDate { get; set; }
        
    }
}
