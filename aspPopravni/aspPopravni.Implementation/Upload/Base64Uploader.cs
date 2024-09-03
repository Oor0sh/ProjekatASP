using aspPopravni.Application.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.Upload
{
    public class Base64Uploader : IBase64Uploader
    {
        private AllowedExtensions _allowedExt = new AllowedExtensions();
        private List<string> _uploadPath = new List<string> { "wwwroot", "images", "editions" };

        public string Upload(string base64file)
        {
            string extension = GetExtension(base64file);
            if (!IsExtensionValid(extension))
            {
                throw new InvalidOperationException();
            }
            var path = GetPath(extension);
            File.WriteAllBytes(path, Convert.FromBase64String(base64file));
            return path;
        }
        public string GetPath(string ext)
        {
            var path = _uploadPath;

            var fileName = "";

            foreach (var p in path)
            {
                fileName = Path.Combine(fileName, p);
            }
            return Path.Combine(fileName, ext);
        }

        public bool IsExtensionValid(string extension)
        {
            return _allowedExt.Extensions.Contains(extension);
        }

        public string GetExtension(string base64File)
        {
            return StringExtensions.StringExtensions.GetFileExtension(base64File);
        }
    }
}
