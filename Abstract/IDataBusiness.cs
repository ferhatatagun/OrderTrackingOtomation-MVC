using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SiparisTakipSistemi.Concrete;


namespace _SiparisTakipSistemi.Abstract
{
   public interface IDataBusiness<T> where T:class
    {
        bool InsertData(T model);
        bool UpdateData(T model);
        bool DeleteData(T model, int Id);
        T SelectData(int id);
        List<T> ListData();

    }
}
