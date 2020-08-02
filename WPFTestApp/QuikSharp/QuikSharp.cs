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
    public class QuikSharp
    {/// <summary>
    /// статус
    /// </summary>
    /// <param name="message"></param>
        public delegate void ConnectHandler(string message);
        public event ConnectHandler ConnectNotify;

        public static Quik _quik;
        bool isServerConnected = false;
        private string _ConnectIp = "127.0.0.1";
        public string ConnectIp { get => _ConnectIp; set => _ConnectIp = value; }

        public void ConnectQuik()
        {
            try
            {
                _quik = new Quik(Quik.DefaultPort, new InMemoryStorage(), ConnectIp);    // инициализируем объект Quik с использованием удаленного IP-адреса терминала
                ConnectNotify?.Invoke($"Подключаемся к терминалу Quik...");
            }
            catch
            {
                ConnectNotify?.Invoke($"Подключаемся к терминалу Quik...");
            }

            if (_quik != null)
            {
                ConnectNotify?.Invoke("Экземпляр Quik создан.");
                try
                {
                    ConnectNotify?.Invoke("Получаем статус соединения с сервером....");
                    isServerConnected = _quik.Service.IsConnected().Result;
                    if (isServerConnected)
                    {
                        ConnectNotify?.Invoke("Соединение с сервером установлено.");

                    }
                    else
                    {
                        ConnectNotify?.Invoke("Соединение с сервером НЕ установлено.");
                    }
                }
                catch
                {
                    ConnectNotify?.Invoke("Неудачная попытка получить статус соединения с сервером.");
                }
            }
        }
    }
}

