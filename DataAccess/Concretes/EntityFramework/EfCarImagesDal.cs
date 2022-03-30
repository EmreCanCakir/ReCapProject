using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImage,ReCapProjectContext>,ICarImagesDal
    {
        public List<int> GetAllCarId()
        {
            List<int> carIds = new List<int>();
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var list = context.CarImages.FromSqlRaw("select * from dbo.CarImages").ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    carIds.Add(list[i].CarId);
                }
                return carIds;
            }
        }
    }
}
