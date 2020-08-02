using QuikBotWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikBotWPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Title

        private string _Title = "Quik Bot2236";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
