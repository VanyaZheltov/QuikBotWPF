using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuikSharp;
using System.Threading.Tasks;

using WPFTestApp.QuikSharp;

namespace WPFTestApp.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        QuikSharpConnect _QuikSharp = new QuikSharpConnect();
       
        


        #region ConnectIP : String - ip

        private string _ConnectIp = "127.0.0.1";

        public string ConnectIP 
        { 
            get => _ConnectIp; 
            set => Set(ref _ConnectIp, value); 
        }

        #endregion

        #region ConnectStatus : String - статус подключения

        private string _ConnectStatus;

        public string ConnectStatus
        {
            get => _ConnectStatus;
            set => Set(ref _ConnectStatus, value);
        }

        #endregion

        public  MainWindowViewModel()
        {
            _QuikSharp.ConnectIp = ConnectIP;
            _QuikSharp.ConnectNotify += ConnectMessage;
        }
        private void  ConnectMessage(string message)
        {
            ConnectStatus = message;
        }
    }
}
