using System;
using SQLite;

namespace Apu.Models
{
    public class City
    {

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string name { get; set; }

        public int Order { get; set; }


    }
}
