using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
           
            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<Car> Delete(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            _carDal.Delete(result);
            return new SuccessDataResult<Car>(result,Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {

            if (true)
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
            }
            
        }

        public IDataResult<Car> Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessDataResult<Car>(Messages.CarUpdated);
        }
    }
}
