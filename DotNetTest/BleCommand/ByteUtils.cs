using System;
using System.Text;


namespace Ble.Command
{
    public class ByteUtils
    {
        public ByteUtils()
        {
        }


        /**
        * 在 byte[] 前面加上一个 byte
        *         
        */
        public static byte[] addByteToFirst(byte newByte, byte[] bArray)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 1);
            newArray[0] = newByte;
            return newArray;
        }

        /**
        * 在 byte[] 前面加上一个 byte[]
        *         
        */
       public static byte[] addByteArrayToFirst(byte[] newByte, byte[] bArray)
        {
            byte[] newArray = new byte[bArray.Length + newByte.Length];
            newByte.CopyTo(newArray, 0);
            bArray.CopyTo(newArray, newByte.Length);

            return newArray;
        }

        /*
         * 
         * 在 byte[] 后面加上一个 byte
         */
        public static byte[] addByteToLast(byte[] bArray, byte newByte)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 0);
            newArray[bArray.Length] = newByte;
            return newArray;
        }
        /*
       * 
       * 在 byte[] 后面加上一个 byte
       */
      public  static byte[] addByteArrayToLast(byte[] bArray, byte[] newByte)
        {
            byte[] newArray = new byte[bArray.Length + newByte.Length];
            bArray.CopyTo(newArray, 0);
            newByte.CopyTo(newArray, bArray.Length);

            return newArray;
        }

        /**
         * 
         * 打印 byte
         */        
        public static string PrintByteArray(byte[] bytes)
        {
            var sb = new StringBuilder("new byte[] { ");
            foreach (var b in bytes)
            {
                sb.Append(b + ",");
            }
            if (sb.Length >= 2)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("}");
            //Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

    }
}
