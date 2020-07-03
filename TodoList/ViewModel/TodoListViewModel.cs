using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoList.Mvvm;

namespace TodoList
{
    class TodoListViewModel : BindableBase
    {
        #region Private Member



        #endregion


        #region Public Properties

        /// <summary>
        /// 창의 최소 넓이
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// 창 최소 높이
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 600;

        #endregion

        #region Command
        public class RegisterCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private DateTime _date;
            private String _desc;
            
            public RegisterCommand(DateTime date, String desc)
            {
                _date = date;
                _desc = desc;
            }

            public bool CanExecute(object parameter)
            {
               if(_date == null || _desc == String.Empty)
                {
                    return false;
                }
                return true;
            }

            public void Execute(object parameter)
            {
                SELECTE
            }
        }
        private RegisterCommand registrationCommand;

        public RegisterCommand RegistrationCommand
        {
            get
            {
                if (registrationCommand == null)
                    registrationCommand = new DelegateCommand<object>(ExcuteRegistration);
                return registrationCommand;
            }
            set { registrationCommand = value; }
        }
         
        private void ExcuteRegistration(object param)
        {

            //SelectedTodoList.Add(new TodoListModel() { Seq = 1, Desc = "희영씨 시작해" });

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
