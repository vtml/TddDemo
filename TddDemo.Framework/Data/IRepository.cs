﻿using System;
using System.Collections.Generic;

namespace TddDemo.Framework.Data
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(Guid id);

    }
}
