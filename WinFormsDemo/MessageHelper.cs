using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WinFormsDemo
{
    /// <summary>
    /// 定义了一个类似于Rpc的操作
    /// 客户端接受到消息后从这里的消息队列中获取具体内容
    /// </summary>
    public static class MessageHelper
    {
        private static ConcurrentDictionary<Int64, object> MessageData = new ConcurrentDictionary<long, object>();

        private static Int64 NextMessageID = 0;

        private static object MessageID_Lock = new object();

        private static JavaScriptSerializer JsonSeriailzer = new JavaScriptSerializer();

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //用户可自定义的消息类型  WM_USER（0x0400） through 0x7FFF  Integer messages for use by private window classes.
        public const int WM_USER_DATASHARE = 0x0401;

        public class MsgInfo
        {
            public Int64 MessageID { get; set; }
            public string MessageType { get; set; }
            public string EventHandle { get; set; }
        }


        static MessageHelper()
        {

        }

        private static Int64 GetNextMessageID()
        {
            lock (MessageID_Lock)
            {
                var ret = NextMessageID;
                Interlocked.Add(ref NextMessageID, 1);
                return ret;
            }
        }

        public static void SendMessage(Form form, string messageType, string eventHandle, object data)
        {
            var messageId = GetNextMessageID();
            MessageData[messageId] = data;

            MsgInfo msginfo = new MsgInfo()
            {
                MessageID = messageId,
                MessageType = "SendMessage",
                EventHandle = eventHandle,
            };

            SendMessage(form.Handle, WM_USER_DATASHARE, 0, JsonSeriailzer.Serialize(msginfo));

            //whl == form.Handle
            //var whl = FindWindow(null, form.Name);
            //SendMessage(whl, WM_USER, 0, JsonSeriailzer.Serialize(msginfo));
        }

        public static void PostMessage(Form form, string messageType, string eventHandle, object data)
        {
            var messageId = GetNextMessageID();
            MessageData[messageId] = data;

            MsgInfo msginfo = new MsgInfo()
            {
                MessageID = messageId,
                MessageType = "PostMessage",
                EventHandle = eventHandle,
            };

            PostMessage(Process.GetCurrentProcess().MainWindowHandle, WM_USER_DATASHARE, 0, JsonSeriailzer.Serialize(msginfo));
        }
    }
}
