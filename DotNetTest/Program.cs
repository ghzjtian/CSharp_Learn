using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

using nexus.core.text;

using Ble.Command;

namespace DotNetTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String Address = "D5:B2:6D:28:B2:15";

            AppIDCheck checker = new AppIDCheck(Address);
            byte[] command = checker.getIdentificationString();

            //byte[] bytes = Encoding.ASCII.GetBytes("123456");
            //Console.WriteLine("BitConverter.ToString bytes:" + BitConverter.ToString(bytes));

            //byte[] bytes2 = "12346".DecodeAsBase16();
            //Console.WriteLine("nexus.core.text bytes:" + BitConverter.ToString(bytes2));

        }

       


       


    }
}
