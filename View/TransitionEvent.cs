using System;
using System.Windows;

namespace View
{
    class TransitionEventEventArgs : EventArgs
    {
        public UIElement element { get; set; }
    }
}
