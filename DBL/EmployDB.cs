using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Models;


namespace DBL
{
    public class EmployDB : BaseDB<Employ>
    {
        protected override string GetTableName()
        {
            return "shishop";
        }

        protected override string GetPrimaryKeyName()
        {
            return "employCode";
        }

        protected override async Task<Employ> CreateModelAsync(object[] row)
        {
            Employ e = new Employ();
            e.Id = int.Parse(row[0].ToString());
            e.Name = row[1].ToString();
            e.Emai l = row[2].ToString();
            e.IsAdmin = bool.Parse(row[4].ToString());
            return c;
        }

    }
}
