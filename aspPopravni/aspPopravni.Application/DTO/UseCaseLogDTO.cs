using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class UseCaseLogDTO
    {
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public object UseCaseData { get; set; }
        public UseCaseLogDTO(int useCase, int user, object useCaseData)
        {
            UseCaseId = useCase;
            UserId = user;
            UseCaseData = useCaseData;
        }
    }
}
