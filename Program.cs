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

        static void Menu()
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

        //makes sure in choos
        static bool IfChoosInMenu(string choos)
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

        static void MenuFunc(string choos , List<int> listi)
        {
           
            switch (choos)
            {
                case "1":
                    ChangeListInt(listi);
                    break;
                case "2":
                    ShowList(listi);
                    break;
                case "3":
                    ShowReverseList(listi);
                    break;
                case "4":
                    SortList(listi);
                    break;
                case "5":
                    Console.WriteLine(MaxList(listi));
                    break;
                case "6":
                    Console.WriteLine(ValuyeMinList(listi));
                    break;
                case "7":
                    Console.WriteLine(AvargeOfNumList(listi));
                    break;
                case "8":
                    Console.WriteLine(NumElements(listi));
                    break;
                case "9":
                    Console.WriteLine(SumList(listi));
                    break;
            }
            
        }

        //change list of int
        static void ChangeListInt(List<int> listi)
        {
            
            listi.Clear();
            ThreeNum(listi);
            
        }

        //show all values
        static void ShowList(List<int> show)
        {
            foreach (int i in show)
            {
                Console.Write(i);
            }
        }

        //printer a revers list
        static void ShowReverseList(List<int> reverse)
        {
            int x = reverse.Count;
            for (int i = 0; i < reverse.Count; i++)
            {
                x--;
                Console.Write(reverse[x]);
            }
        }

        //sorted lists
        static void SortList(List<int> sortlist)
        {
            List<int> list = new List<int>(sortlist);
            for (int i = 0; i < sortlist.Count; i++)
            {  
                bool ifnotsort = true;
                for (int j = 0; j < list.Count - 1; j++)
                {
                    int value = list[j];
                    int value2 = list[j + 1];
                    if (value > value2)
                    {
                        list[j] = value2;
                        list[j + 1] = value;
                        ifnotsort = false;
                    }
                }
                if (ifnotsort)
                {
                    break;
                }
            }
            foreach(int i in list)
            {
                Console.Write(i);
            }
            
            
            
            

        }


        //print num max from list
        static int MaxList(List<int> maxlist)
        {
            int max = 0;
            foreach (int i in maxlist)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        //print num min from list
        static int ValuyeMinList(List<int> minlist)
        {
            int min = minlist[0];
            foreach (int i in minlist)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        static int AvargeOfNumList(List<int> avelist)
        {
            return SumList(avelist) / NumElements(avelist);
        }

        static int NumElements(List<int> numelem)
        {
            return numelem.Count;
        }

        static int SumList(List<int> sumlist)
        {
            int sum = 0;
            foreach(int i in sumlist)
            {
                sum += i;
            }
            return sum;
        }



        //chack if number and converter if string in number
        static int IfNum(string ifnum)
        {
            if (int.TryParse(ifnum, out int x))
            {
                return x;
            }
            return 0;
        }

        //Coverts string to number
        //static int converstrNum(string num)
        //{
        //    int x = int.Parse(num);
        //    return x;

        //}

        //Checks it the number is positive
        static bool IfPositive(int num)
        {
            if (num <= 0)
            {
                return false;
            }
            return true;
        }

        //retures all list is positive
        static bool IfListNuPos(string[] arge)
        {
            bool ifAllNum = true;
            foreach (string str in arge)
            {
                if (!IfPositive(IfNum(str)))
                {
                    ifAllNum = false;
                }

            }
            return ifAllNum;
        }


        //Creates a list at least 3 numbers until the user stoped.
        static List<int> ThreeNum(List<int> listInt)
        {
            int min = 0;
            string stop = "";

            while (min < 3 || stop != "stop")
            {
                Console.WriteLine("pleas enter at least 3 number");
                string input = Console.ReadLine();
                if (IfPositive(IfNum(input)))
                {
                    listInt.Add(IfNum(input));
                    min++;
                }

                if (!IfPositive(IfNum(input)))
                {
                    Console.WriteLine("pleas enter only number and positive");
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
        static List<int> ConverAegsListInt(string[] arge)
        {
            List<int> listInt = new List<int>();
            if (arge.Length < 3)
            {
                listInt = ThreeNum(listInt);
            }
            else if (!IfListNuPos(arge))
            {
                listInt = ThreeNum(listInt);
            }
            else
            {
                foreach (string str in arge)
                {
                    listInt.Add(IfNum(str));
                }
            }
            return listInt;
        }


        static void PlayMenu(List<int> listi)
        {
            string choos = "";
            while (choos != "10")
            {
                Menu();
                choos = Console.ReadLine();
                if (!IfChoosInMenu(choos))
                {
                    Console.WriteLine("plese choos only 1-10");
                    continue;
                }
                MenuFunc(choos , listi);
            }
        }

           
        static void Main(string[] args)
        {
           PlayMenu(ConverAegsListInt(args));
           
        }
    }
}
