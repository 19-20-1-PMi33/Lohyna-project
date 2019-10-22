using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    interface INavigation
    {
        UIElement curPage { get; set; }
        UIElement lastPage { get; }
        void navigateTo(UIElement where);
        void navigateBack();
        void openWindow(Window wind);
    }
}
