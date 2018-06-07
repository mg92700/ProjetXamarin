using Apu.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Apu.Data
{
    public class ApuDataBase
    {
        private readonly SQLiteAsyncConnection db;

        public ApuDataBase(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<City>();
        }

        public async Task<int> SaveAsync(City city)
        {
            if (city.ID != 0)
            {
                return await db.UpdateAsync(city);
            }
            else
            {
                return await db.InsertAsync(city);
            }
        }

        public async Task<int> DeleteAsync(City city)
        {
            return await db.DeleteAsync(city);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await db.QueryAsync<City>("SELECT * FROM [City]");
        }
    }
}
