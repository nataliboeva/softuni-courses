using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicRecordsApp.Data
{
    public static class DbConfiguration
    {
        public const string ConnectionString =
            @"Server=.;Database=AcademicRecordsDB;Trusted_Connection=True;Encrypt=False;";
    }
}
