using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBook.DAL
{
    public interface IOutputProvider
    {
        void WriteLine(string message);
    }
}
