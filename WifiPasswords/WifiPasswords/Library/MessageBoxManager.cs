using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WifiPasswords.Library
{
    public class MessageBoxManager
    {
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

        private const int WhCallwndprocret = 12;
        private const int WmDestroy = 0x0002;
        private const int WmInitdialog = 0x0110;
        private const int WmTimer = 0x0113;
        private const int WmUser = 0x400;
        private const int DmGetdefid = WmUser + 0;

        private const int Mbok = 1;
        private const int MbCancel = 2;
        private const int MbAbort = 3;
        private const int MbRetry = 4;
        private const int MbIgnore = 5;
        private const int MbYes = 6;
        private const int MbNo = 7;


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        private static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        private static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetClassNameW", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", EntryPoint = "SetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);


        [StructLayout(LayoutKind.Sequential)]
        public struct Cwpretstruct
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        private static HookProc hookProc;
        private static EnumChildProc enumProc;
        [ThreadStatic]
        private static IntPtr _hHook;
        [ThreadStatic]
        private static int _nButton;

        public static string Ok = "&OK";
        public static string Cancel = "&Cancel";
        public static string Abort = "&Abort";
        public static string Retry = "&Retry";
        public static string Ignore = "&Ignore";
        public static string Yes = "&isyan";
        public static string No = "&No";

        static MessageBoxManager()
        {
            hookProc = MessageBoxHookProc;
            enumProc = MessageBoxEnumProc;
            _hHook = IntPtr.Zero;
        }

        public static void Register()
        {
            if (_hHook != IntPtr.Zero)
                throw new NotSupportedException("One hook per thread allowed.");
            _hHook = SetWindowsHookEx(WhCallwndprocret, hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        public static void Unregister()
        {
            if (_hHook == IntPtr.Zero) return;
            UnhookWindowsHookEx(_hHook);
            _hHook = IntPtr.Zero;
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return CallNextHookEx(_hHook, nCode, wParam, lParam);

            var msg = (Cwpretstruct)Marshal.PtrToStructure(lParam, typeof(Cwpretstruct));
            var hook = _hHook;

            if (msg.message == WmInitdialog)
            {
                var className = new StringBuilder(10);
                GetClassName(msg.hwnd, className, className.Capacity);
                if (className.ToString() == "#32770")
                {
                    _nButton = 0;
                    EnumChildWindows(msg.hwnd, enumProc, IntPtr.Zero);
                    if (_nButton == 1)
                    {
                        IntPtr hButton = GetDlgItem(msg.hwnd, MbCancel);
                        if (hButton != IntPtr.Zero)
                            SetWindowText(hButton, Ok);
                    }
                }
            }
            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static bool MessageBoxEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            var className = new StringBuilder(10);
            GetClassName(hWnd, className, className.Capacity);
            if (className.ToString() == "Button")
            {
                var ctlId = GetDlgCtrlID(hWnd);
                switch (ctlId)
                {
                    case Mbok:
                        SetWindowText(hWnd, Ok);
                        break;
                    case MbCancel:
                        SetWindowText(hWnd, Cancel);
                        break;
                    case MbAbort:
                        SetWindowText(hWnd, Abort);
                        break;
                    case MbRetry:
                        SetWindowText(hWnd, Retry);
                        break;
                    case MbIgnore:
                        SetWindowText(hWnd, Ignore);
                        break;
                    case MbYes:
                        SetWindowText(hWnd, Yes);
                        break;
                    case MbNo:
                        SetWindowText(hWnd, No);
                        break;

                }
                _nButton++;
            }
            return true;
        }
    }
}