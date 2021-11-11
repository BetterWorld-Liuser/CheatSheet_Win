using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Windowing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CheatSheet_Win.Views;
using static PInvoke.User32;
using Microsoft.UI;
using Windows.Graphics;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CheatSheet_Win
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            
            m_window = new Settings();
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(m_window);
            Center_Window(hwnd,500,800);
            AppWindow appWindow = GetAppWindowForCurrentWindow(m_window);
            appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            var titleBar = appWindow.TitleBar;

            titleBar.ForegroundColor = Colors.Transparent;
            titleBar.BackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = Colors.Transparent;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            appWindow.Show();
        }

        private Window m_window;

        //获取当前窗口的句柄
        private static AppWindow GetAppWindowForCurrentWindow(Window window)
        {
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WindowId myWndId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(myWndId);
        }


        //居中窗口
        private static void Center_Window(IntPtr hwnd,int width,int height)
        {
            //PInvoke.RECT rect = new();
            //_ = GetWindowRect(hwnd, out rect);
            int screenWidth = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int screenHeight = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            SetWindowPos(hwnd, (IntPtr)0, (screenWidth-width)/2, (screenHeight-height)/2, width,height,SetWindowPosFlags.SWP_DEFERERASE);
        }

    }
}
