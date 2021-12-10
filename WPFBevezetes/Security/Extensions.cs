using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WPFBevezetes.Security
{
    public static class Extensions
    {

        public static bool Check(this SecureString src, Predicate<byte[]> callback)
        {
            IntPtr unmanagedBytes = Marshal.SecureStringToGlobalAllocUnicode(src);

            try
            {
                return callback(CreateArray(unmanagedBytes));
            }
            finally
            {
                // This will completely remove the data from memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedBytes);
            } 
        }

        public static bool Confirm(this SecureString src, SecureString other)
        {
            IntPtr unmanagedBytes = Marshal.SecureStringToGlobalAllocUnicode(src);
            IntPtr otherUnmanagedBytes = Marshal.SecureStringToGlobalAllocUnicode(other);

            try
            {
                var arr = CreateArray(unmanagedBytes);
                var arr2 = CreateArray(otherUnmanagedBytes);

                if (arr.Length != arr2.Length)
                    return false;

                for (int i = 0; i < arr.Length; i++)
                    if (arr2[i] != arr[i])
                        return false;

                return true;
            }
            finally
            {
                // This will completely remove the data from memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedBytes);
                Marshal.ZeroFreeGlobalAllocUnicode(otherUnmanagedBytes);
            }
        }

        private static unsafe byte[] CreateArray(IntPtr unmanagedBytes)
        {
            byte[] bValue = null;
            byte* byteArray = (byte*)unmanagedBytes.ToPointer();

            // Length is effectively the difference here (note we're 2 past end) 
            int length = (int)((EndOfString(byteArray) - byteArray) - 2);
            bValue = new byte[length];
            for (int i = 0; i < length; ++i)
            {
                // Work with data in byte array as necessary, via pointers, here
                bValue[i] = *(byteArray + i);
            }

            return bValue;
        }

        private static unsafe byte* EndOfString(byte* byteArray)
        {
            byte* pEnd = byteArray;
            char c = '\0';

            do
            {
                byte b1 = *pEnd++;
                byte b2 = *pEnd++;
                c = '\0';
                c = (char)(b1 << 8);
                c += (char)b2;
            } while (c != '\0');

            return pEnd;
        }

    }
}
