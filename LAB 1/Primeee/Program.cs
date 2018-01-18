using System;

namespace asemsyoucandelete
{
    public class Prime{
        public static bool IsPrime (int a){
            bool asd = true;
            if (a == 1){
                asd =  false;
            }
            if (a == 2 ){
               asd =  true;
            }
            for (int i = 2; i <= Math.Sqrt(a); i++){
                if(a%i == 0){
                    asd = false;
                    break;
                }
            }
            return asd;
        }
    }
    class Program

    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] arr = s.Split(' ');
            for (int i = 0; i < s.Length; i++){
                if(Prime.IsPrime(int.Parse(arr[i])) == true){
                    Console.WriteLine(arr[i] + ' ');
                }
            }

            Console.ReadKey();                 
        }

    }
}
