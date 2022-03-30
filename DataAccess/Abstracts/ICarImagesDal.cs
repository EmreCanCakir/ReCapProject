using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICarImagesDal:IEntityRepository<CarImage>
    {
        List<int> GetAllCarId();
    }
}
