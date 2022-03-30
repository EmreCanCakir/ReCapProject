using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        private ICarService _carService;

        public CarImagesManager(ICarImagesDal carImagesDal,IFileHelper fileHelper,ICarService carService)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
            _carService = carService;
        }

        public IResult Add1(IFormFile file,CarImage entity)
        {
            var resultt = BusinessRules.Run(CheckIfCarImageLimit(entity.CarId));
            var result = _fileHelper.Upload(file, PathConstants.ImagesPath);
            entity.ImagePath = result.Message;
            entity.CreatedDate = DateTime.Now;
            if (!result.Success)
            {
                return result;
            }

            if (!resultt.Success)
            {
                return new ErrorResult(Messages.CarImageOutOfLimit);
            }
            _carImagesDal.Add(entity);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete1(CarImage entity)
        {
            var carImage = _carImagesDal.Get(c => c.Id == entity.Id);
            if (carImage == null)
            {
                return new ErrorResult();
            }

            _fileHelper.Delete(carImage.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IResult Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            GetDefaultImages();
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(),Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.CarId == id));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            GetDefaultImageByCarId(carId);
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(c=>c.CarId==carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c=>c.Id==imageId));
        }

        public IResult Update1(IFormFile file,CarImage entity)
        {
            var image = _carImagesDal.Get(c => c.Id == entity.Id);
            var result = _fileHelper.Update(file,image.ImagePath,PathConstants.ImagesPath);
            if (!result.Success)
            {
                return result;
            }
            image.ImagePath = result.Message;
            _carImagesDal.Update(image);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        private IResult GetDefaultImages()
        {
            var carList = _carService.GetAllByCarId().Data;
            var carIdList = _carImagesDal.GetAllCarId();
            var another = carList.Except(carIdList).ToList();
            for (int i = 0; i < another.Count; i++)
            {
                _carImagesDal.Add(new CarImage{CarId = another[i],CreatedDate = DateTime.Now,ImagePath = "wwwroot\\Uploads\\Images\\DefaultImage\\DefaultImage.jpg".Replace("\\","/") });
            }

            return new SuccessResult();
        }

        private IResult GetDefaultImageByCarId(int carId)
        {
            var carIdList = _carImagesDal.GetAllCarId();
            var isTrue = carIdList.Contains(carId);
            if (isTrue==false)
            {
                _carImagesDal.Add(new CarImage{CarId = carId, CreatedDate = DateTime.Now, ImagePath = "wwwroot\\Uploads\\Images\\DefaultImage\\DefaultImage.jpg".Replace("\\", "/") });
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
