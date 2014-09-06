﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vertise.Core.Abstractions;
using Vertise.Core.Data;

namespace Vertise.Repositories {
    public class EfRepository<T> : IRepository<T> where T: Entity
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _set;
        protected EfRepository(DbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public IQueryable<T> All {
            get { return _set; }
        }

        public void AddOrUpdate(T entity)
        {
            entity.Modified = DateTime.UtcNow;
            if(entity.Id > 0) {
                _db.Entry(entity).State = EntityState.Modified;
            }else
            {
                entity.Created = DateTime.UtcNow;
                _set.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.Deleted = DateTime.UtcNow;
            entity.IsDeleted = true;
            _db.Entry(entity).State=EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}