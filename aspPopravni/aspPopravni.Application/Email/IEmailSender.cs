using aspPopravni.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.Email
{
    public interface IEmailSender
    {
        void SendEmail(EmailDTO emailObj);
    }
}
