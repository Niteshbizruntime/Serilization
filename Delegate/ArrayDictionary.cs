using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace DelegatesAndEvent
{
    class ArrayDictionary
    {
       static object[] arr = new object[10]; 
        static void Main(string[] args)
        {
            int l = arr.Length;
            for(int i=0;i<l;i++)
            {
                arr[i] = new Dictionary<int, string>();
            }

            Console.Write("Enter Choice : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Z:
            for(int j=0;j<l;j++)
            {
                if(j==n)
                {
                    Dictionary<int, string> d = (Dictionary<int, string>)arr[j];
                    Console.Write("Active Dictionary"+n);
                }
            }
            Console.Write("\nyou want to delete press 1");
            if (Convert.ToInt32(Console.ReadLine()) == 1 && l>0)
            {
                if (n >= 0)
                    for (int k = n; k < l - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                l--;
                n = n > 0 ? n - 1 : n;
                goto Z;
            }
            else { Console.Write("Bye"); }
            Console.Read();
        }
    }
}
