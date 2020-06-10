using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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

        bool? private_dialog_result;

        private DateTime selDate;

        private String addText;

        delegate void FHideWindow();

        #endregion

        #region Constructor

        public AddListWindow()
        {
            selDate = DateTime.Now;
            addText = "";
            InitializeComponent();
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            private_dialog_result = DialogResult;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FHideWindow(HideThisWindow));
        }

        private void HideThisWindow()
        {
            this.Hide();
            (typeof(Window)).GetField("_isClosing", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, false);
            (typeof(Window)).GetField("_dialogResult", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, private_dialog_result);
            private_dialog_result = null;
        }

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
           

        }

        /// <summary>
        /// 취소 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DatePicker_AddList.DisplayDate = DateTime.Now;
            Calendar_AddList.SelectedDate = DateTime.Now;
            addTextBox.Text = "";
            addTextBox.UpdateLayout();
            Hide();
        }
    }

}
