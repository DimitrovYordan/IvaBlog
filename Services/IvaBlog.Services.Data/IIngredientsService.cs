﻿namespace IvaBlog.Services.Data
{
    using System.Collections.Generic;

    public interface IIngredientsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
