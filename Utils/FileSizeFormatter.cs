using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frp_desktop.Utils
{
    public static class FileSizeFormatter
    {
        /// <summary>
        /// 将文件大小（字节）格式化成带单位的字符串（B、KB、MB、GB）
        /// </summary>
        /// <param name="bytes">文件大小，单位字节</param>
        /// <returns>格式化后的字符串</returns>
        public static string FormatSize(long bytes)
        {
            const double KB = 1024;
            const double MB = KB * 1024;
            const double GB = MB * 1024;

            if (bytes >= GB)
                return (bytes / GB).ToString("F2") + " GB";
            else if (bytes >= MB)
                return (bytes / MB).ToString("F2") + " MB";
            else if (bytes >= KB)
                return (bytes / KB).ToString("F2") + " KB";
            else
                return bytes + " B";
        }
    }

}
