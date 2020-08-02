using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuikSharp;
using QuikSharp.DataStructures;
using QuikSharp.DataStructures.Transaction;


namespace WPFTestApp.QuikSharp
{
    public class QuikSharpConnect
    {/// <summary>
    /// статус
    /// </summary>
    /// <param name="message"></param>
        public delegate void ConnectHandler();
        public event ConnectHandler ConnectNotify;

        public static Quik _quik;
        bool isServerConnected = false;
        private string _ConnectIp = "127.0.0.1";
        public string ConnectIp { get => _ConnectIp; set => _ConnectIp = value; }
        private string _Status = "----";
        public string ConnectStatus { get =>_Status ;

            set
            {
              _Status = value;
              ConnectNotify?.Invoke();
            }
        }

        public void ConnectQuik()
        {
            try
            {
                _quik = new Quik(Quik.DefaultPort, new InMemoryStorage(), ConnectIp);    // инициализируем объект Quik с использованием удаленного IP-адреса терминала
                ConnectStatus = "Подключаемся к терминалу Quik...";
            }
            catch
            {
                ConnectStatus =  "Подключаемся к терминалу Quik...";
            }

            if (_quik != null)
            {
                ConnectStatus =  "Экземпляр Quik создан.";
                try
                {
                    ConnectStatus = "Получаем статус соединения с сервером....";
                    isServerConnected = _quik.Service.IsConnected().Result;
                    if (isServerConnected)
                    {
                        ConnectStatus = "Соединение с сервером установлено." ;

                    }
                    else
                    {
                        ConnectStatus =  "Соединение с сервером НЕ установлено.";
                    }
                }
                catch
                {
                    ConnectStatus =  "Неудачная попытка получить статус соединения с сервером.";
                }
            }
        }
    }
}

