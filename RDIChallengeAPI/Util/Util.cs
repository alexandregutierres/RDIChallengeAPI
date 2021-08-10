using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDIChallengeAPI.Util
{
    public static class Util
    {
        public static void RigthRotate(char[] arr, int r)
        {
            char x = arr[(arr.Length - 1)];
            for (int i = (arr.Length - 1); i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = x;

            if (r > 1)
                RigthRotate(arr, r - 1);
            else
                return;
        }

    }
}
