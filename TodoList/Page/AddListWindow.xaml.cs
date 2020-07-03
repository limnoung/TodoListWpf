using System;
using System.Windows;
using System.Windows.Controls;

namespace TodoList
{
    /// <summary>
    /// AddListWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddListWindow : Window
    {
        #region Private Properties



        #endregion

        #region Private Member

        private JsonParser jsonParser;

        private DateTime selDate;

        delegate void FHideWindow();

        #endregion

        #region Constructor

        public AddListWindow()
        {
            InitializeComponent();
            selDate = DateTime.Now;
            jsonParser = JsonParser.GetInstance();
        }

        #endregion
        /// <summary>
        /// DatePicker의 Date가 변경되었을때의 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_AddList_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            selDate = datePicker.SelectedDate.Value;
            Calendar_AddList.SelectedDate = selDate;

        }

        /// <summary>
        /// Calendar의 Date가 변경되었을때의 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_AddList_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate != null)
            {
                selDate = calendar.SelectedDate.Value;
                DatePicker_AddList.SelectedDate = selDate;
            }

        }

        /// <summary>
        /// 추가 확인 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var calendar = DatePicker_AddList as DatePicker;
            if (calendar.SelectedDate == null)
            {
                MessageBox.Show("날짜가 비어있습니다.", "에러", MessageBoxButton.OK);
            }
            else if (TextBox_Add.Text.Length == 0)
            {
                MessageBox.Show("내용이 비어있습니다.", "에러", MessageBoxButton.OK);
            }
            else
            {
                jsonParser.AddJson(DatePicker_AddList.DisplayDate, TextBox_Add.Text);
                MessageBox.Show("일정이 추가되었습니다.");
                DatePicker_AddList.DisplayDate = DateTime.Now;
                Calendar_AddList.SelectedDate = DateTime.Now;
                TextBox_Add.Text = "";
                TextBox_Add.UpdateLayout();
            }

        }

        /// <summary>
        /// 취소 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
