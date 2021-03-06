﻿
using System;
using System.Collections.Generic;
using System.Linq;

using Application.Inetrface;
using DAL;

using System.Data.Entity;

namespace Application.Implemintation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class

    {

        #region Properties
        private readonly UsersContext _context;
        private readonly DbSet<T> _dbSet;
        #endregion
        #region ctors
        public GenericRepo()
        {
            _context = new UsersContext();
            _dbSet = _context.Set<T>();
        }
        #endregion
        #region Interface method
        public IEnumerable<T> Get(Func<T, bool> func = null)
        {
            if (func != null)
            {
                return _context.Set<T>().Where(func).ToList();
            }

            return _dbSet.ToList();
        }
        public int Add(T obj)
        {
            _dbSet.Add(obj);
            return Save();
        }
        public int Remove(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }
        public int Update()
        {
            return Save();
        }
        
        private int Save()
        {
            return _context.SaveChanges();
        }

    }

    #endregion


}


