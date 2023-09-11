using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class Ext_Text
    {
        public static String t = "";
        public static void P_Text(String docpath,String text)
        {
            String p = "";
            String start = "";
            String end = "";
            String p_start = "";
            String p_end = "";
            t = "";

            if (text.Substring(0, 1) == "P")
            {
                if (Regular_Exp.Single_Paragraph(text) == true) //P[1],P<file://1/2/1.docx>[1]
                {
                    t = " ";
                    p = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1);
                    Console.WriteLine(p);
                    t = Ext_Para.single_paragraph(docpath, int.Parse(p));

                }
                else if (Regular_Exp.Paragraph(text) == true) //P[1-2],P[1-],P[-2]
                {
                    p = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1); //4-10
                    //Console.WriteLine(p);
                    Ext_Para.paragraph(docpath);

                    if (p.Substring(0, 1) == "-") //P[-2]
                    {
                        t = " ";
                        for (int i = 1; i <= int.Parse(p.Substring(p.IndexOf("-") + 1)); i++)
                        {
                            //Console.WriteLine(i + ":" + Ext_Para.text[i]);
                            t += Ext_Para.text[i];
                        }
                    }
                    else if (p.Substring(p.Length - 1, 1) == "-") //P[1-]
                    {
                        t = " ";
                        Console.WriteLine(int.Parse(p.Substring(0, p.Length - 1)));
                        for (int j = int.Parse(p.Substring(0, p.Length - 1)); j <= Ext_Para.i; j++)
                        {
                            Console.WriteLine(j);
                            //Console.WriteLine(j + ":" + Ext_Para.text[j]);
                            t += Ext_Para.text[j];
                        }
                        Console.WriteLine(t);
                    }
                    else //P[4-10]
                    {
                        t = " ";
                        p_start = p.Substring(0, p.IndexOf("-"));
                        //Console.WriteLine(p_start);
                        p_end = p.Substring(p.IndexOf("-") + 1);
                        //Console.WriteLine(p_end);
                        for (int j = int.Parse(p_start); j <= int.Parse(p_end); j++)
                        {
                            //Console.WriteLine(j + ":" + Ext_Para.text[j]);
                            t += Ext_Para.text[j];
                        }
                    }


                }
                else if (Regular_Exp.Text_In_Paragraph(text) == true) //P[1]C[1-2],P[1]C[3],P[1]C[2]-P[3]C[4]
                {
                  
                    Console.WriteLine(text);
                    if (text.Contains("-") == false) //P[1]C[3]
                    {
                        t = " ";
                        p = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1);
                        start = text.Substring(text.IndexOf("C[") + 2, text.Length - text.IndexOf("C[") - 3);
                        Console.WriteLine(p);
                        Console.WriteLine(start);
                        t = Ext_Para.text_in_paragraph(docpath, int.Parse(p), int.Parse(start), int.Parse(start));
                    }
                    else
                    {
                        
                        if (text.Contains("-P") == true) //P[1]C[2]-P[3]C[4]
                        {
                            t = " ";
                            Ext_Para.paragraph(docpath);
                            String text1 = text.Substring(0, text.IndexOf("-"));
                            String text2 = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 1);
                            Console.WriteLine(text1);
                            Console.WriteLine(text2);
                            String p1 = text1.Substring(text1.IndexOf("[") + 1, text1.IndexOf("]") - text1.IndexOf("[") - 1);
                            String start1 = text1.Substring(text1.IndexOf("C[") + 2, text1.Length - text1.IndexOf("C[") - 3);
                            Console.WriteLine(p1);
                            Console.WriteLine(start1);
                            Console.WriteLine(Ext_Para.text[int.Parse(p1)].Substring(int.Parse(start1)));
                            t += Ext_Para.text[int.Parse(p1)].Substring(int.Parse(start1));
                            String p2 = text2.Substring(text2.IndexOf("[") + 1, text2.IndexOf("]") - text2.IndexOf("[") - 1);
                            String end2 = text2.Substring(text2.IndexOf("C[") + 2, text2.Length - text2.IndexOf("C[") - 3);
                            Console.WriteLine(p2);
                            Console.WriteLine(end2);
                            for (int i = int.Parse(p1) + 1; i < int.Parse(p2); i++)
                            {
                                Console.WriteLine(Ext_Para.text[i]);
                                t += Ext_Para.text[i];
                            }
                            if (int.Parse(end2) <= Ext_Para.text[int.Parse(p2)].Length)
                            {
                                Console.WriteLine(Ext_Para.text[int.Parse(p2)].Substring(0, int.Parse(end2)));
                                t += Ext_Para.text[int.Parse(p2)].Substring(0, int.Parse(end2));
                            }
                            else
                            {
                                Console.WriteLine(Ext_Para.text[int.Parse(p2)].Substring(0));
                                t += Ext_Para.text[int.Parse(p2)].Substring(0);
                            }
                        }
                        else //P[1]C[1-2]
                        {
                            t = " ";
                            p = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1);
                            start = text.Substring(text.IndexOf("C[") + 2, text.IndexOf("-") - text.IndexOf("C[") - 2);
                            end = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 2);
                            Console.WriteLine(p);
                            Console.WriteLine(start);
                            Console.WriteLine(end);
                            t = Ext_Para.text_in_paragraph(docpath, int.Parse(p), int.Parse(start), int.Parse(end));
                        }
                    }
                }
                else
                {
                    t =  "error！！！";
                    Console.WriteLine("error！！！");
                }
            }
        }
    }
}
