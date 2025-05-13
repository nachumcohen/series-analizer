using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu_numbers
{
    internal class Program
    {
        //static bool comparison(int size1,string comparison ,int size2)
        //{
        //    bool ifSize = false;
        //    switch (comparison)
        //    {
        //        case "<":
        //            ifSize = size1 < size2;
        //            break;
        //        case ">":
        //            ifSize = size2 < size1;
        //            break;
        //        case "<=":
        //            ifSize = size1 <= size2;
        //            break;
        //        case ">=":
        //            ifSize = size1 >= size2;
        //            break;

        //    }
        //    return ifSize;
        //}

        //chack if number and converter if string in number
        static int ifNum(string ifnum)
        {
            if (int.TryParse(ifnum, out _)){
                return converstrNum(ifnum);
            }
            return 0;
        }

        //Coverts string to number
        static int converstrNum(string num)
        {
            int x = int.Parse(num);
            return x;
            
        }

        //Checks it the number is positive
        static bool ifPositive(int num)
        {
            if (num <= 0)
            {
                return false;
            }
            return true;
        }

        //retures all list is positive
        static bool ifListNuPos(string[] arge)
        {   
            bool ifAllNum = true;
            foreach (string str in arge)
            {
                if (!ifPositive(ifNum(str)))
                {
                    ifAllNum = false;
                }
            
            }
            return ifAllNum;
        }

        //Creates a list at least 3 numbers until the user stoped.
        static List<int> threeNum()
        {
            int min = 0;
            string stop = "";
            List<int> listInt = new List<int>();

            while (min < 3 || stop != "stop")
            {
                Console.WriteLine("pleas enter at least 3 number");
                string input = Console.ReadLine();
                if (ifPositive(ifNum(input)))
                {
                    listInt.Add(converstrNum(input));
                    min++;
                }

                if (!ifPositive(ifNum(input)))
                {
                    Console.WriteLine("pleas enter only number");
                }

                if (min >= 3)
                {
                    Console.WriteLine("if you want to stop write 'stop' ");
                    stop = Console.ReadLine();
                }

                

            }
            return listInt;

        }


        /*
         Returns a finish list of numbers
         */
        static List<int> converAegsListInt(string[] arge)
        {
            List<int> listInt = new List<int>();
            if (arge.Length < 3)
            {
                listInt = threeNum();
            }
            else if (!ifListNuPos(arge))
            {
                listInt = threeNum();
            }
            else
            {
                foreach (string str in arge)
                {
                    listInt.Add(converstrNum(str));
                }
            }
            return listInt;
        }

        static void menu()
        {
            Console.WriteLine(@"
            Choose one of the option
            1. input a series
            2. display the series in the order it was entered
            3. display the series in the reversed order it was entered
            4. display the series in sorted order (low to high)
            5. display the max value of the series
            6. display the min value of the series
            7. display the average of the series
            8. display the number of elements in the series
            9. display the sum of series
            10. exit");
        }

        static bool ifChoosInMenu(string choos)
        {   
            bool choosTrue = false;
            switch(choos)
            {
                case "1":
                    choosTrue = true;
                    break;
                case "2":
                    choosTrue = true;
                    break;
                case "3":
                    choosTrue = true;
                    break;
                case "4":
                    choosTrue = true;
                    break;
                case "5":
                    choosTrue = true;
                    break;
                case "6":
                    choosTrue = true;
                    break;
                case "7":
                    choosTrue |= true;
                    break;
                case "8":
                    choosTrue = true;
                    break;
                case "9":
                    choosTrue |= true;
                    break;  
                case "10":
                    choosTrue |= true;
                    break;
            }
            return choosTrue;
        }




        static void menuFunc(string choos , List<int> listi)
        {
           
            switch (choos)
            {
                case "1":
                    changeListInt(listi);
                    break;
                case "2":
                    //display list();
                    break;
                case "3":
                    //display reverse();
                    break;
                case "4":
                    //display sort();
                    break;
                case "5":
                    //display max() ;
                    break;
                case "6":
                    //display min();
                    break;
                case "7":
                    //display average;
                    break;
                case "8":
                    // number element;
                    break;
                case "9":
                    //sum list;
                    break;
            }
            
        }

        static List<int> changeListInt(List<int> listi)
        {
            listi = threeNum();
            return listi;
        }

        static void playMenu(List<int> listi)
                {
                    string choos = "";
                    while (choos != "10")
                    {
                        menu();
                        choos = Console.ReadLine();
                        if (!ifChoosInMenu(choos))
                        {
                            Console.WriteLine("plese choos only 1-10");
                            continue;
                        }
                        menuFunc(choos , listi);



                    }
                }




           
        static void Main(string[] args)
        {

           playMenu(converAegsListInt(args));
           
            
        }
    }
}
