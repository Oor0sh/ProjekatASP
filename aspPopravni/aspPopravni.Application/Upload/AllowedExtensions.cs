using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.Upload
{
    public class AllowedExtensions
    {
        public IEnumerable<string> Extensions => new List<string>
        {
            "jpg", "png"
        };
    }
}
