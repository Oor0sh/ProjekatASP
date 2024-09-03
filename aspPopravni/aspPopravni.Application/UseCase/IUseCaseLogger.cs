using aspPopravni.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.UseCase
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLogDTO logObj);
    }
}
