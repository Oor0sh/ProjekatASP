using aspPopravni.Application.DTO;
using aspPopravni.Application.UseCase;
using aspPopravni.DataAccess;
using aspPopravni.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.Logging
{
    public class EFUseCaseLogger : IUseCaseLogger
    {
        private readonly popravniContext _context;

        public EFUseCaseLogger(popravniContext context)
        {
            _context = context;
        }
        public void Log(UseCaseLogDTO logObj)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                UseCaseData = JsonConvert.SerializeObject(logObj.UseCaseData),
                UseCaseId = logObj.UseCaseId,
                UserId = logObj.UserId != 0 ? logObj.UserId : null
            });
            _context.SaveChanges();
        }
    }
}
