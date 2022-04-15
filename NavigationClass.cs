using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pm04
{
    internal class NavigationClass
    {
        private static Frame mainFrame;
        private static UserControl previoslyFrame;

        public static void Navigate(object frame)
        {
            previoslyFrame = mainFrame.Content as UserControl;
            mainFrame.Navigate(frame);
        }

        public static void Back()
        {
            Navigate(previoslyFrame);
        }

        public static void Init(Frame frame)
        {
            mainFrame = frame;
        }

    }
}
