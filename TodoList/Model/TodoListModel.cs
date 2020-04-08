using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Mvvm;

namespace TodoList
{
    class TodoListModel : BindableBase
    {
        private int _seq = 0;
        public int Seq
        {
            get
            {
                return _seq;
            }
            set
            {
                _seq = value;
                OnPropertyChanged("Seq");
            }
        }

        private string _desc = string.Empty;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = value;
                OnPropertyChanged("Desc");
            }
        }
    }
}
