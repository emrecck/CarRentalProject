using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        string Upload(string fileName, IFormFile fileList);
        IResult Delete(string path);
        string Update(string sourcePath, IFormFile file, string name);
    }
}
