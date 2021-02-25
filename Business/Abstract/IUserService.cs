using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetUsers();
        IDataResult<User> GetUserById(int id);
        IDataResult<List<User>> GetUsersByFirstName(string firstname);
        IDataResult<List<User>> GetUsersByLastName(string lastname);
        IDataResult<List<User>> GetUsersByEmail(string email);
    }
}
