using Newtonsoft.Json.Linq;
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

        private Calendar mCalendar;

        private DateTime mDateTime;

        private DispatcherTimer Timer;

        private AddListWindow mAddListWindow;

        private RemoveListWindow mRemoveListWindow;

        private JsonParser jsonParser;

        private JArray doListArray;

        #endregion

        #region Public Properties



        #endregion

        #region Constructor

        public TodoListWindow()
        {
            InitializeComponent();
            InitTimer();
            InitCalendar();
        }

        ~TodoListWindow()
        {
            Timer = null;
            mAddListWindow = null;
            mRemoveListWindow = null;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// 타이머의 Dispatcher, Tick 할당
        /// </summary>
        private void InitTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        /// <summary>
        /// 캘린더의 초기화 함수
        /// </summary>
        private void InitCalendar()
        {
            mCalendar = ControlCalendar;
            mCalendar.SelectedDate = DateTime.Now;
            mDateTime = mCalendar.SelectedDate.Value;
            ChangeDate();
        }

        /// <summary>
        /// Json Parser 초기화 함수
        /// </summary>
        private void InitJsonParser()
        {
            if(jsonParser == null)
            {
                jsonParser = new JsonParser();
            }
            doListArray = jsonParser.jsonListArray;

            foreach(JObject fElem in doListArray)
            {
                var fDate = fElem["Date"];
                DateTime dt;
                if(fDate != null)
                {
                   dt = DateTime.Parse(fDate.ToString());
                   ControlCalendar.
                }
            }
        }

        /// <summary>
        /// 시계의 타이머
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            LabelTime.Content = String.Format("{0}년 {1}월 {2}일\n{3}", d.Year % 100, d.Month, d.Day, d.ToString("tt\nhh : mm : ss"));
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
                ChangeDate();
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
                date = date.AddDays(-1);
                mDateTime = date;
                ChangeDate();
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
                date = date.AddDays(1);
                mDateTime = date;
                ChangeDate();
            }
        }

        /// <summary>
        /// 현재 날짜에서 한 해 전으로 이동합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (mCalendar.SelectedDate.HasValue)
            {
                DateTime date = mCalendar.SelectedDate.Value;
                date = date.AddYears(-1);
                mDateTime = date;
                ChangeDate();
            }
        }

        /// <summary>
        /// 현재 날짜에서 한 해 후로 이동합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (mCalendar.SelectedDate.HasValue)
            {
                DateTime date = mCalendar.SelectedDate.Value;
                date = date.AddYears(1);
                mDateTime = date;
                ChangeDate();
            }
        }

        /// <summary>
        /// 일정 리스트를 갱신합니다.
        /// </summary>
        private void ChangeTodoList()
        {
            foreach(JObject fElem in doListArray)
            {
                var fDate = fElem["Date"];
                if(fDate != null)
                {
                    var fDesc = fElem["Desc"];


                }
            }
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

        /// <summary>
        /// 날짜 변경시의 UI 변경
        /// </summary>
        private void ChangeDate()
        {
            // 현재 표시되는 월, 년과 선택되어져 있는 월, 년이 다를 경우
            if (mCalendar.SelectedDate.Value.Month != mDateTime.Month || mCalendar.DisplayDate.Month != mDateTime.Month
                ||mCalendar.SelectedDate.Value.Year != mDateTime.Year || mCalendar.DisplayDate.Year != mDateTime.Year)
                mCalendar.DisplayDate = mDateTime;
            mCalendar.SelectedDate = mDateTime;
            TextData.Text = String.Format("{0}년 {1}월 {2}일", mDateTime.Year % 100, mDateTime.Month, mDateTime.Day);
        }

        /// <summary>
        /// 윈도우 창이 닫길때의 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }


        #endregion

    }
}
