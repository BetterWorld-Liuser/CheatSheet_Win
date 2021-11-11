using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static PInvoke.User32;
using Windows.Storage.Pickers;
using System.Runtime.InteropServices;
using Windows.Storage;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CheatSheet_Win
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [ComImport, Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize([In] IntPtr hwnd);
        }


        //构造函数
        public MainWindow()
        {
            this.InitializeComponent();
            //DisplayImportData();

        }



        //一般方法
        //1.处理按钮
        private async void Import_Csv(object sender, RoutedEventArgs e)
        {

            ToggleHey.IsOpen = true;
            FileOpenPicker open = new FileOpenPicker();
            open.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".csv");

            //莫名的一段修复Bug的代码
            //Url:https://gist.github.com/wbokkers/cc8bcc7bc5a646b82a4d41b337330c69#gistcomment-3649439
            IInitializeWithWindow initializeWithWindowWrapper = open.As<IInitializeWithWindow>();
            IntPtr hwnd = GetActiveWindow();
            initializeWithWindowWrapper.Initialize(hwnd);
            var file = await open.PickSingleFileAsync();
            //return await FileIO.ReadTextAsync(file);


        }

    }
}
