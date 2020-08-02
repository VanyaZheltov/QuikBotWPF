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
    class QuikSharp
    {
        public static Quik _quik;

        public void ConnectQuik()
        {
            try
            {
                textBoxLogsWindow.AppendText("Подключаемся к терминалу Quik..." + Environment.NewLine);
                _quik = new Quik(Quik.DefaultPort, new InMemoryStorage(), textBoxHost.Text);    // инициализируем объект Quik с использованием удаленного IP-адреса терминала
                
                //// Отладочный вариант подключения
                //if (checkBoxRemoteHost.Checked) _quik = new Quik(34136, new InMemoryStorage(), textBoxHost.Text);    // инициализируем объект Quik с использованием удаленного IP-адреса терминала
                //else _quik = new Quik(34136, new InMemoryStorage());    // инициализируем объект Quik с использованием локального расположения терминала (по умолчанию)
            }
            catch
            {
                textBoxLogsWindow.AppendText("Ошибка инициализации объекта Quik..." + Environment.NewLine);
            }

            if (_quik != null)
            {
                textBoxLogsWindow.AppendText("Экземпляр Quik создан." + Environment.NewLine);
                try
                {
                    textBoxLogsWindow.AppendText("Получаем статус соединения с сервером...." + Environment.NewLine);
                    isServerConnected = _quik.Service.IsConnected().Result;
                    if (isServerConnected)
                    {
                        textBoxLogsWindow.AppendText("Соединение с сервером установлено." + Environment.NewLine);
                        buttonRun.Enabled = true;
                        buttonStart.Enabled = false;
                    }
                    else
                    {
                        textBoxLogsWindow.AppendText("Соединение с сервером НЕ установлено." + Environment.NewLine);
                        buttonRun.Enabled = false;
                        buttonStart.Enabled = true;
                    }
                    // временный код
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.Listeners.Add(new TextWriterTraceListener(Application.StartupPath + "\\TraceLogging.log"));
                    // временный код
                }
                catch
                {
                    textBoxLogsWindow.AppendText("Неудачная попытка получить статус соединения с сервером." + Environment.NewLine);
                }
            }



    }
}
