using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuikSharp;
using System.Threading.Tasks;

namespace WPFTestApp.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region ConnectIP : String - ip

        private string _ConnectIp = "127.0.0.1";

        public string ConnectIP { get => _ConnectIp; }

        #endregion



    }
}
