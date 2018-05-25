using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apu.Models;
using SQLite;

namespace Apu.Data
{
    public class ApuDataBase
    {
        
       private readonly SQLiteAsyncConnection db;

        public ApuDataBase(string connection )
        {
            db = new SQLiteAsyncConnection(connection);
            db.CreateTableAsync<City>().Wait();
        }

        public async Task<int> SaveAsync(City city)
        {
            if (city.ID!=0)
            {
                return await db.UpdateAsync(city);   
            }
            else
            {
              return await  db.InsertAsync(city);
            }

        }

        public async Task<int> DeleteAsync(City city)
        {

            return await db.DeleteAsync(city);        
        }


        public async Task<List<City>> GetAll()
        {
            return await db.QueryAsync<City>("select * from [City]");
        }


    }
}
