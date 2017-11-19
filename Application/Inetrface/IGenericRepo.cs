using System;
using System.Collections.Generic;

namespace Application.Inetrface

{
    public interface IGenericRepo<T> where T: class
    {
        IEnumerable<T> Get(Func<T, bool> func = null);
        int Add(T obj);
        int Remove(T obj);
        int  Update();
        
    }
}