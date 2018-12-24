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
            String Address = "d5:b2:6D:28:B2:15";

            AppIDCheck checker = new AppIDCheck(Address);
            byte[] command = checker.getIdentificationString();

         
        }

       


       


    }
}
