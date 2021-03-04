using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelper : IFileHelper
    {
        private readonly IHostingEnvironment _environment;
        string _fileDirectory;
        //string sourcePath = Path.GetTempFileName();
        public FileHelper(IHostingEnvironment environment)
        {
            _environment = environment;
            _fileDirectory = _environment.WebRootPath + "\\uploads\\";
        }
        public string Upload(string fileName, IFormFile file)
        {
            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }
            using (var fileStream = new FileStream(Path.Combine(_fileDirectory, fileName.ToString() + ".png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            using (var fileStream = new FileStream(Path.Combine(Environment.CurrentDirectory+@"\Images\", fileName.ToString() + ".png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return Path.Combine(Environment.CurrentDirectory + @"\Images\", fileName.ToString() + ".png");
        }
        public IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public string Update(string sourcePath, IFormFile file,string name)
        {
            using (var stream = new FileStream(Path.Combine(Environment.CurrentDirectory + @"\Images\", name.ToString() + ".png"), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Delete(sourcePath);
            return Path.Combine(Environment.CurrentDirectory + @"\Images\", name.ToString() + ".png");
        }
    }
}
