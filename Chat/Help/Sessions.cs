using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Help
{
    public class Sessions
    {
        /// <summary>
        /// 生成sessionid
        /// </summary>
        /// <returns></returns>
        public static string GenerateSid()
        {
            long i = 1;
            byte[] byteArray = Guid.NewGuid().ToByteArray();
            foreach (byte b in byteArray)
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}