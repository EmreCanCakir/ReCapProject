using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    internal class Class1
    {
        /*public IResult Upload(IFormFile file, string root)
        {
            if (file.Length!> 0)
            {
                return new ErrorResult(null);
            }

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string extension = Path.GetExtension(file.FileName);
            string guid = GuidHelper.GuidHelper.CreateGuid();
            string path = guid + extension;
            using (FileStream fileStream = File.Create(root+path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return new SuccessResult(path);
            }
        }

        public IResult Delete(string filePath)
        {
            if (!File.Exists(filePath)) return new ErrorResult();
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            if (!File.Exists(filePath))
            {
                return new ErrorResult();
            } 
            File.Delete(filePath);
            return Upload(file, root);
        }*/
    }
}
