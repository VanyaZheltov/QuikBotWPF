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

        #region SecCode : String - Код Акции

        private string _SecCode;

        public string SecCode { get => _SecCode; set => Set(ref _SecCode, value); }


        #endregion

        #region ClientCode : String - Код Клиента

        private string _ClientCode;

        public string ClientCode { get => _ClientCode; set => Set(ref _ClientCode, value); }


        #endregion

        #region LastPrice : String - Последняя цена

        private string _LastPrice;

        public string LastPrice { get => _LastPrice; set => Set(ref _LastPrice, value); }


        #endregion

        public MainWindowViewModel()
        {
            _QuikSharp.ConnectNotify += ConnectMessage;
            _QuikSharp.ConnectIp = ConnectIP;
            _QuikSharp.ConnectQuik();
           
        }
        private void  ConnectMessage()
        {
            ConnectStatus = _QuikSharp.ConnectStatus;
        }
    }
}
