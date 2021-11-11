using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PInvoke.User32;

namespace CheatSheet_Win.Util
{
    public class WinManager
    {
        //获取窗口标题
        public static string Get_window_name()
        {
            IntPtr hWnd = GetForegroundWindow();
            int length = GetWindowTextLength(hWnd);
            char[] text = new char[length];
            unsafe
            {

                _ = GetWindowText(hWnd, text, length);
            }
            return text.ToString();
        }  
    }
}
