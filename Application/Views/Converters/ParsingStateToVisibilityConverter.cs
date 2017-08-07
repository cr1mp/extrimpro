using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace xrm.Views.Converters
{
	public class ParsingStateToVisibilityConverter : IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			if ( value is ParsingState && (ParsingState)value == ParsingState.Running )
			{
				return Visibility.Visible;
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
}
