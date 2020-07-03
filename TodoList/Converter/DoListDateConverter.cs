using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoList
{
    public class DoListDate
    {
        public DateTime _date;
        public String _desc;

        public DoListDate(DateTime date, String desc)
        {
            _date = date;
            _desc = desc;
        }

        public DoListDate(object date, object desc)
        {
            _date = Convert.ToDateTime(date);
            _desc = desc as String;
        }
    }

    public class DoListDateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new DoListDate(values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
