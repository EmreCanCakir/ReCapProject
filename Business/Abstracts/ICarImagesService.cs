using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts
{
    public interface ICarImagesService:IBaseService<CarImage>
    {
        IResult Add1(IFormFile file,CarImage entity);
        IResult Delete1(CarImage entity);
        IResult Update1(IFormFile file,CarImage entity);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetByImageId(int imageId);

    }
}
