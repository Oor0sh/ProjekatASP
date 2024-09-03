using aspPopravni.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases
{
    public abstract class EFUseCase
    {
        private readonly popravniContext _context;
        protected EFUseCase(popravniContext context)
        {
            _context = context;
        }
        protected popravniContext Context => _context;
    }
}
