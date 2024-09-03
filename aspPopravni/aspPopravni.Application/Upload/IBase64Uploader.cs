using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.Upload
{
    public interface IBase64Uploader
    {
        bool IsExtensionValid(string base64File);
        string GetExtension(string base64File);
        string Upload(string base64File);
    }
}
