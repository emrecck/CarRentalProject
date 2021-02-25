using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetRentals();
        IDataResult<Rental> GetRentalById(int id);
        IDataResult<List<Rental>> GetRentalsByCustomerId(int customerid);
        IDataResult<List<Rental>> GetRentalsByRentDate(DateTime date);
        IDataResult<List<Rental>> GetRentalsByReturnDate(DateTime date);

    }
}
