using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SiparisTakipSistemi.Models;

namespace _SiparisTakipSistemi.Models.ViewModels
{
    public class SiparisDurumlarıVm
    {
        public IEnumerable<SP_SiparisDurumları_Result> SiparisDurumlari { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}