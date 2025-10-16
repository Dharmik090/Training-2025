using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckIn.App.IO
{
    internal interface IFileToDataTable
    {
        DataTable ToDataTable(string filePath);
    }
}
