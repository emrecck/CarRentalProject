using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        IHostingEnvironment _environment;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, IHostingEnvironment environment)
        {
            _environment = environment;
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CarImage carImage, IFormFile files)
        {
            IResult result = BusinessRules.Run(CheckCountImage(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            string FileName = Guid.NewGuid().ToString();
            var filePath = _fileHelper.Upload(FileName, files);
            carImage.ImagePath = filePath.ToString();
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("product.List,Admin")]
        [CacheAspect(20)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> {
                    new CarImage {
                        CarId = id,
                        Date = DateTime.Now,
                        ImagePath = $@"{Environment.CurrentDirectory}\wwwroot\uploads\default.png"
                        }
                },Messages.ThereisNoImage);
            }
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            string FileName = Guid.NewGuid().ToString();
            carImage.ImagePath = _fileHelper.Update(_carImageDal.Get(c => c.CarId == carImage.CarId).ImagePath, file, FileName);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        #region BusinessRules
        private IResult CheckCountImage(int carid)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carid);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ThisCarHasAlreadyFiveImages);
            }
            return new SuccessResult(Messages.CarImageAdded);
        }
        #endregion
    }
}
