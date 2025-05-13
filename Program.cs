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
        //open menu
        static void ShowMenu()
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
        static void MenuFunc(string choos , List<float> listi)
        {
           
            switch (choos)
            {
                case "1":
                    ChangeListfloat(listi);
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
                default:
                    Console.WriteLine("error: chooch only 1 - 10");
                    break;
            }
            
        }

        //change list of float
        static void ChangeListfloat(List<float> listi)
        {
            
            listi.Clear();
            ThreeNum(listi);
            
        }

        //show all values
        static void ShowList(List<float> show)
        {
            foreach (float i in show)
            {
                Console.Write(i);
            }
        }

        //prfloater a revers list
        static void ShowReverseList(List<float> reverse)
        {
            
            for (int i = reverse.Count -1; i >= 0; i--)
            {
               
                Console.Write(reverse[i]);
            }
        }

        //sorted lists
        static void SortList(List<float> sortlist)
        {
            List<float> list = new List<float>(sortlist);
            for (float i = 0; i < sortlist.Count; i++)
            {  
                bool ifnotsort = true;
                for (int j = 0; j < list.Count - 1; j++)
                {
                    float value = list[j];
                    float value2 = list[j + 1];
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
            foreach(float i in list)
            {
                Console.Write(i);
            }
        }


        //prfloat num max from list
        static float MaxList(List<float> maxlist)
        {
            float max = 0;
            foreach (float i in maxlist)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        //prfloat num min from list
        static float ValuyeMinList(List<float> minlist)
        {
            float min = minlist[0];
            foreach (float i in minlist)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        //return avarge of list
        static float AvargeOfNumList(List<float> avelist)
        {
            return SumList(avelist) / NumElements(avelist);
        }

        //return number elmemnts of list
        static float NumElements(List<float> numelem)
        {
            return numelem.Count;
        }

        //return sum all elements of list
        static float SumList(List<float> sumlist)
        {
            float sum = 0;
            foreach(float i in sumlist)
            {
                sum += i;
            }
            return sum;
        }

        //chack if number and converter if string in number
        static float IsNum(string isNum)
        {
            if (float.TryParse(isNum, out float x))
            {
                return x;
            }
            return 0;
        }

        static bool IsPositiveNum(float num)
        {
            if (num <= 0)
            {
                return false;
            }
            return true;
        }

        //retures all list is positive
        static bool IsListNumPositive(string[] arge)
        {
            bool ifAllNum = true;
            foreach (string str in arge)
            {
                if (!IsPositiveNum(IsNum(str)))
                {
                    ifAllNum = false;
                }

            }
            return ifAllNum;
        }


        //Creates a list at least 3 numbers until the user stoped.
        static List<float> ThreeNum(List<float> listfloat)
        {
            float min = 0;
            string stop = "";

            while (min < 3 || stop != "stop")
            {
                Console.WriteLine("pleas enter at least 3 number");
                string input = Console.ReadLine();
                if (IsPositiveNum(IsNum(input)))
                {
                    listfloat.Add(IsNum(input));
                    min++;
                }

                if (!IsPositiveNum(IsNum(input)))
                {
                    Console.WriteLine("pleas enter only number and positive");
                }

                if (min >= 3)
                {
                    Console.WriteLine("if you want to stop write 'stop' ");
                    stop = Console.ReadLine();
                }

            }
            return listfloat;

        }
        
        //Returns a finish list of numbers
        static List<float> ConverAegsListfloat(string[] arge)
        {
            List<float> listfloat = new List<float>();
            if (arge.Length < 3)
            {
                listfloat = ThreeNum(listfloat);
            }
            else if (!IsListNumPositive(arge))
            {
                listfloat = ThreeNum(listfloat);
            }
            else
            {
                foreach (string str in arge)
                {
                    listfloat.Add(IsNum(str));
                }
            }
            return listfloat;
        }

        //plying menu
        static void PlayMenu(List<float> listi)
        {
            string choos = "";
            while (choos != "10")
            {
                ShowMenu();
                choos = Console.ReadLine();
                MenuFunc(choos , listi);
            }
        }

           
        static void Main(string[] args)
        {
           PlayMenu(ConverAegsListfloat(args));
        }
    }
}
