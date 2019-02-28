using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Joystick_Test
{
    public class JoystickButtonSwitch : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((int)value & 128) > 0)
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
