using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using nexus.core.text;


namespace Ble.Command
{
    public class AppIDCheck
    {
        string m_address;

        public AppIDCheck(string address)
        {
            m_address = address.ToUpper();
        }

        public byte[] getIdentificationString() {

            //1:获取到蓝牙的地址值(去除地址中间的 ':' 符号).
            //如: 把 D9:AD:DF:09:09:4C 变为 D9ADDF09094C

            List<string> list = m_address.Split(':').ToList();


            //2.然后用 '格力博专属的id' + 上面的蓝牙地址，用 MD5 加密，得到最后的 12 位字符.
            String conflict_id = "GLB specify id";
            StringBuilder optimize_address = new StringBuilder();
            optimize_address.Append(conflict_id);
            foreach (string str in list)
            {
                optimize_address.Append(str);
                //Console.WriteLine("str:" + str);
            }
            string cryptStr = GetMd5Hash(MD5.Create(), optimize_address.ToString());
            string sub12Str = cryptStr.Substring(cryptStr.Length - 12, 12);
            Console.WriteLine("sub12 string:" + sub12Str);

            //3.把 最后 12 位的字符串 分割为六位的 byte[] , sub12Str必须为双数，否则会发生异常.
            var command = sub12Str.DecodeAsBase16();
            Console.WriteLine("六位的 byte[]:(0x)" + BitConverter.ToString(command));

            //4.在命令的前面加上 0x02,0x84 后面加上 0x00,0x0d,0x0a ,组成一个 11 位的命令.

            command = ByteUtils.addByteArrayToFirst(new byte[] { 0x02, 0x84 }, command);
            command = ByteUtils.addByteArrayToLast(command, new byte[] { 0x00, 0x0d, 0x0a });


            Console.WriteLine("11 位的 byte[]:(0x)" + BitConverter.ToString(command));
            // {0x02,0x84, 0x8F,0xA5,0xA5,0xFE,0xBB,0x5F, 0x00,0x0D,0x0A};

            return command;
        }


        // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.7.2
         string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
