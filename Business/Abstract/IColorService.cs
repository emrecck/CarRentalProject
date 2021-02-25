﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetColors();
        IDataResult<Color> GetById(int id);
        IDataResult<Color> GetByName(string name);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
