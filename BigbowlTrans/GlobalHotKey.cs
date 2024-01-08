using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BigbowlTrans
{
    internal class GlobalHotKey
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool ctrlPressed = false;
        private static DateTime lastCPress = DateTime.MinValue;
        public static event Action HotkeyPressed = delegate { };


        private static void OnHotkeyPressed()
        {
            HotkeyPressed?.Invoke();
        }
        // 设置钩子
        public static void SetHook()
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, IntPtr.Zero, 0);
        }

        // 移除钩子
        public static void UnsetHook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        // 钩子的回调函数
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (key == Keys.LControlKey || key == Keys.RControlKey)
                {
                    ctrlPressed = true;
                }
                else if (key == Keys.C && ctrlPressed)
                {
                    if ((DateTime.Now - lastCPress).TotalMilliseconds <= 500) // 500毫秒内按下第二次C
                    {
                        // 执行 Ctrl + C + C 的操作
                        //MessageBox.Show("Ctrl + C + C Detected!");
                        OnHotkeyPressed();
                        lastCPress = DateTime.MinValue; // 重置时间
                    }
                    lastCPress = DateTime.Now;
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (key == Keys.LControlKey || key == Keys.RControlKey)
                {
                    ctrlPressed = false;
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // 以下是与 Windows API 交互的 P/Invoke 函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
