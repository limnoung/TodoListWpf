using System;
using System.Windows.Controls;

namespace TodoList
{
    /// <summary>
    /// AddList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddList : Page
    {
        #region Private Properties

        private DateTime selDate;

        #endregion



        public AddList()
        {
            selDate = DateTime.Now;
            InitializeComponent();
        }

        private void DatePicker_AddList_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calendar_AddList_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
