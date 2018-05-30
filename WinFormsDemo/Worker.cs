using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormsDemo
{
    public class Worker
    {
        private static Random random = new Random();

        public class Result
        {
            public string Key { get; set; }
            public string RandomValue { get; set; }
        }

        public static string DoSth(string key)
        {
            Thread.Sleep(random.Next(2000) + 1000);
            return random.Next(100).ToString();
        }
    }
}
