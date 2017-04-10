using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Models.ViewModels
{
    public class TumSiparislerVm
    {
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<Sipari> TumSiparisler { get; set; }
    }
}
