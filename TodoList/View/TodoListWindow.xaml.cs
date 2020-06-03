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
        #region Private Properties

        /// <summary>
        /// 선택된 년도
        /// </summary>
        private int mYear;

        /// <summary>
        /// 선택된 월
        /// </summary>
        private int mMonth;

        /// <summary>
        /// 선택된 일
        /// </summary>
        private int mDay;
        #endregion

        DispatcherTimer Timer = new DispatcherTimer();
        public TodoListWindow()
        {
            mYear = DateTime.Now.Year;
            mMonth = DateTime.Now.Month;
            mDay = DateTime.Now.Day;

            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            TimeLabel.Content = String.Format("{0}년 {1}월 {2}일\n", mYear%100, mMonth, mDay);
            TimeLabel.Content += String.Format(d.ToString("tt\nhh : mm : ss"));
        }

        private void Calendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                mYear = date.Year;
                mMonth = date.Month;
                mDay = date.Day;
            }
        }
    }
}
