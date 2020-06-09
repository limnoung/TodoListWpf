using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TodoList
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TodoListWindow : Window
    {
        #region Private Member

        private Calendar mCalendar;

        private DateTime mDateTime;

        private DispatcherTimer Timer = new DispatcherTimer();

        private AddListWindow mAddListWindow;

        private RemoveListWindow mRemoveListWindow;

        #endregion

        #region Constructor

        public TodoListWindow()
        {
            InitializeComponent();

            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            mCalendar = ControlCalendar;
            mCalendar.SelectedDate = DateTime.Now;
            mDateTime = mCalendar.SelectedDate.Value;
            TextData.Text = String.Format("{0}년 {1}월 {2}일\n", mDateTime.Year%100, mDateTime.Month, mDateTime.Day);
        }


        ~TodoListWindow()
        {
            Timer = null;
            mAddListWindow = null;
            mRemoveListWindow = null;
            Close();
        }
        #endregion

        /// <summary>
        /// 시계의 타이머
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            LabelTime.Content = String.Format(d.ToString("tt\nhh : mm : ss"));
        }
        /// <summary>
        /// 달력의 날짜가 변경되었을 때의 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                mDateTime = calendar.SelectedDate.Value;
                TextData.Text = String.Format("{0}년 {1}월 {2}일\n", mDateTime.Year % 100, mDateTime.Month, mDateTime.Day);
            }
        }
        /// <summary>
        /// 이전 날짜의 일정으로 이동합니다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (mCalendar.SelectedDate.HasValue)
            {
                DateTime date = mCalendar.SelectedDate.Value;
                date.AddDays(-1);
                mCalendar.SelectedDate = date;
            }
        }
        /// <summary>
        /// 다음 날짜의 일정으로 이동합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (mCalendar.SelectedDate.HasValue)
            {
                DateTime date = mCalendar.SelectedDate.Value;
                date.AddDays(1);
                mCalendar.SelectedDate = date;
            }
        }

        /// <summary>
        /// 일정 리스트를 갱신합니다.
        /// </summary>
        private void ChangeTodoList()
        {

        }

        /// <summary>
        /// 일정 추가 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTodoListButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.mAddListWindow == null)
            {
                mAddListWindow = new AddListWindow();
            }
            mAddListWindow.ShowDialog();
        }

        /// <summary>
        /// 일정 삭제 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTodoListButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.mRemoveListWindow == null)
            {
                mRemoveListWindow = new RemoveListWindow();
            }
            mRemoveListWindow.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
