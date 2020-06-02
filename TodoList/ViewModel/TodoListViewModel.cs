using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Mvvm;

namespace TodoList
{
    class TodoListViewModel : BindableBase
    {
        #region Private Member

        private string TextDate;

        #endregion

        #region Command

        private ICommand registrationCommand;

        public ICommand RegistrationCommand
        {
            get
            {
                if (registrationCommand == null)
                    registrationCommand = new DelegateCommand<object>(ExcuetRegistration);
                return registrationCommand;
            }
            set { registrationCommand = value; }
        }

        private void ExcuetRegistration(object param)
        {
            SelectedTodoList.Add(new TodoListModel() { Seq = 1, Desc = "희영씨 시작해" });
        }

        #endregion

        /// <summary>
        /// 리스트 
        /// </summary>
        private ObservableCollection<TodoListModel> selectedTodoList;

        public ObservableCollection<TodoListModel> SelectedTodoList
        {
            get
            {
                if (selectedTodoList == null)
                    selectedTodoList = new ObservableCollection<TodoListModel>();

                return selectedTodoList;
            }
            set
            {
                selectedTodoList = value;
                OnPropertyChanged("SelectedTodoList");
            }
        }

        /// <summary>
        /// 리스트 선택된 내역
        /// </summary>
        private TodoListModel selectedTodo;
        public TodoListModel SelectedTodo
        {
            get
            {
                if (selectedTodo == null)
                {
                    selectedTodo = new TodoListModel();
                }

                return selectedTodo;
            }
            set
            {
                selectedTodo = value;
                OnPropertyChanged("SelectedTodo");
            }
        }
    }
}
