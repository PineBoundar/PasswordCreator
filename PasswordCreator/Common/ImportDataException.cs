using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCreator.Models
{
    class ImportDataException : Exception
    {
        public ImportDataException(Exception ex) : base(Properties.Resources.Error_Cannot_Import, ex) {}
    }
}
