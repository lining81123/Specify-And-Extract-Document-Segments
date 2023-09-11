using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class Ofd_Object
    {
        public static string t;
        public static string ofd(string path, string text)
        {
            //PG[1]
            if (Regular_Exp.Single_Page(text) == true)
            {
                text = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1);
                int page = int.Parse(text);
                Ext_Ofd.parse(path, page);
                t = Ext_Ofd.t;
            }
            else if (Regular_Exp.Page(text) == true) //PG[0-],PG[-1],PG[0-1]
            {
                text = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1); //4-10


                if (text.Substring(0, 1) == "-") //PG[-1]
                {
                    t = " ";
                    for (int i = 0; i <= int.Parse(text.Substring(text.IndexOf("-") + 1)); i++)
                    {
                        Ext_Ofd.parse(path, i);
                        t += Ext_Ofd.t;
                    }
                }
                else if (text.Substring(text.Length - 1, 1) == "-") //PG[0-]
                {
                    t = " ";
                    Console.WriteLine(int.Parse(text.Substring(0, text.Length - 1)));

                    Ext_Ofd.page_num(path);
                    Console.WriteLine(Ext_Ofd.page);
                    for (int j = int.Parse(text.Substring(0, text.Length - 1)); j<= Ext_Ofd.page; j++)
                    {
                        Ext_Ofd.parse(path, j);
                        t += Ext_Ofd.t;
                        Console.WriteLine(t);
                    }
                    Console.WriteLine(t);
                }
                else //P[4-10]
                {
                    t = " ";
                    int text_start = int.Parse(text.Substring(0, text.IndexOf("-")));
                    //Console.WriteLine(p_start);
                    int text_end = int.Parse(text.Substring(text.IndexOf("-") + 1));
                    //Console.WriteLine(p_end);
                    for (int j = text_start; j <= text_end; j++)
                    {
                        Ext_Ofd.parse(path, j);
                        t += Ext_Ofd.t;
                    }
                }
            }
            else if (Regular_Exp.Object_In_Page(text) == true) //PG[1]O[1-2],PG[1]O[3],PG[1]O[2]-PG[3]O[4]
            {

                Console.WriteLine(text);
                if (text.Contains("-") == false) //PG[1]O[3]
                {
                    t = " ";
                    int page = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1));
                    int obj = int.Parse(text.Substring(text.IndexOf("O[") + 2, text.Length - text.IndexOf("O[") - 3));

                    Ext_Ofd.parse(path, page, obj, obj);
                    t += Ext_Ofd.t;
                }
                else
                {

                    if (text.Contains("-P") == true) //PG[1]O[2]-PG[3]O[4]
                    {
                        t = " ";

                        String text1 = text.Substring(0, text.IndexOf("-"));
                        String text2 = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 1);
                        Console.WriteLine(text1);
                        Console.WriteLine(text2);
                        int page1 = int.Parse(text1.Substring(text1.IndexOf("[") + 1, text1.IndexOf("]") - text1.IndexOf("[") - 1));
                        int start1 = int.Parse(text1.Substring(text1.IndexOf("O[") + 2, text1.Length - text1.IndexOf("O[") - 3));
                        Console.WriteLine(page1);
                        Console.WriteLine(start1);
                        Ext_Ofd.parse(path, page1, start1);
                        t += Ext_Ofd.t;
                        Console.WriteLine(t);

                        int page2 = int.Parse(text2.Substring(text2.IndexOf("[") + 1, text2.IndexOf("]") - text2.IndexOf("[") - 1));
                        int end2 = int.Parse(text2.Substring(text2.IndexOf("O[") + 2, text2.Length - text2.IndexOf("O[") - 3));

                        for (int i = page1 + 1; i < page2; i++)
                        {
                            Ext_Ofd.parse(path, i);
                            t += Ext_Ofd.t;
                            Console.WriteLine(t);
                        }

                        Ext_Ofd.parse(path, page2, 0, end2);
                        t += Ext_Ofd.t;
                        Console.WriteLine(t);

                    }
                    else //PG[1]O[1-2]
                    {
                        t = " ";
                        int page = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1));
                        int obj_start = int.Parse(text.Substring(text.IndexOf("O[") + 2, text.IndexOf("-") - text.IndexOf("O[") - 2));
                        int obj_end = int.Parse(text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 2));

                        Ext_Ofd.parse(path, page, obj_start, obj_end);
                        t += Ext_Ofd.t;
                    }
                }
            }

            return t;
        }
    }
}
