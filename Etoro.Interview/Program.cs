using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etoro.Interview
{
    class Program
    {

        static int[] sorting(int[] arrayToSort)
        {
            int j = arrayToSort.Length - 1;

            for (int i=0; i< arrayToSort.Length;i++)
            {
                if (arrayToSort[i] > arrayToSort[j])
                {
                    var k = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[i];
                    arrayToSort[i] = k;
                    j--;
                }
            }
            return arrayToSort;
        }



        static void Main(string[] args)
        {
            //int[] arr = new int[] { 2, 1, 1, 2, 1, 1, 2, 2, 1, 1, 1 };

            //int[] res = sorting(arr);
            //Console.WriteLine(res);

            SearchIslands.Run();
        }


    }
}
