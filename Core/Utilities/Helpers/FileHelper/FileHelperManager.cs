using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager:IFileHelper
    {
        private static string currentDirectory = Environment.CurrentDirectory;
        
        public IResult Upload(IFormFile file, string root)
        {
            var fileExist = CheckFileExists(file);
            if (!fileExist.Success)
            {
                return new ErrorResult(fileExist.Message);
            }

            var type = Path.GetExtension(file.FileName); 
            var typeValid = CheckFileTypeValid(type);
            var guidName = GuidHelper.GuidHelper.CreateGuid();
            var path = guidName + type;
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExists(currentDirectory+root);
            CreateImageFile(root+path,file);
            return new SuccessResult((root + path).Replace("\\", "/"));
        }

        
        public IResult Delete(string filePath)
        {
            var newFilePath = (filePath).Replace("/", "\\");
            if (!File.Exists(newFilePath)) return new ErrorResult();
            File.Delete(newFilePath);
            return new SuccessResult("Car image is deleted.");
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var newFilePath = filePath.Replace("/", "\\");
            if (!File.Exists(newFilePath)) return new ErrorResult();
            File.Delete(newFilePath);
            return new SuccessResult(Upload(file, root).Message);
        }
        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists.");
        }
        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("File type is not valid");
            }
            return new SuccessResult();
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory)) 
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs); 
                fs.Flush();
            }
        }
        
    }
}
