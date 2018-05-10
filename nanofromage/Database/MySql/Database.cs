﻿using MySql.Data.Entity;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Database<T> : DbContext where T : ModelBase
    {

        public Database(String connectionString = null) :
            base(connectionString == null ?
                "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd="
                : connectionString)
        {
        }
        public Database(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Character>();
            modelBuilder.Entity<Clan>();
            modelBuilder.Entity<User>();   
        }
        public DbSet<T> DbSetT { get; set; }

        public async Task<T> Insert(T item)
        {
            this.DbSetT.Add(item);
            await this.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<T>> Insert(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.DbSetT.Add(item);
            }
            await this.SaveChangesAsync();
            return items;
        }

        public async Task<T> Update(T item)
        {
            await Task.Factory.StartNew(() =>
            {
                this.Entry<T>(item).State = EntityState.Modified;
            });
            await this.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<T>> Update(IEnumerable<T> items)
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (var item in items)
                {
                    this.Entry<T>(item).State = EntityState.Modified;
                }
            });
            await this.SaveChangesAsync();
            return items;
        }

        public async Task<T> Get(Int32 id)
        {
            return await this.DbSetT.FindAsync(id) as T;
        }

        public async Task<IEnumerable<T>> Get()
        {
            DbSet<T> temp = default(DbSet<T>);
            List<T> result = new List<T>();
            await Task.Factory.StartNew(() =>
            {
                temp = base.Set<T>();
            });
            result.AddRange(temp);
            return result;
        }

        public async Task<Int32> Delete(T item)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach(item);
                this.DbSetT.Remove(item);
            });
            return await this.SaveChangesAsync();
        }

        public async Task<Int32> Delete(IEnumerable<T> items)
        {
            await Task.Factory.StartNew(() =>
            {
                this.DbSetT.Attach((items as List<T>)[0]);
                this.DbSetT.RemoveRange(items);
            });
            var res = await this.SaveChangesAsync();
            return res;
        }

        
    }
}
