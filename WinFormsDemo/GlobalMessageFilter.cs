using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    /// <summary>
    /// 继承IMessageFilter接口，在Application层过滤全局消息，好像只接受PostMessage传过来的消息
    /// 返回false让其他消息处理器处理这条消息
    /// </summary>
    /// <seealso cref="System.Windows.Forms.IMessageFilter" />
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class GlobalMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == MessageHelper.WM_USER_DATASHARE)
            {
                var str = Marshal.PtrToStringAuto(m.LParam);
                MessageBox.Show(str);

                return true;
            }
            return false;
        }
    }
}
