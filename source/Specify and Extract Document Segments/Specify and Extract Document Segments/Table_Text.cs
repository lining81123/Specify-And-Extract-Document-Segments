using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class Table_Text
    {
        public static string t = "";
        public static void Table_T(String TablePath, String text)
        {
            if (text.Substring(0, 1) == "T")
            {
                t = "";
                if (Regular_Exp.Single_Table(text) == true) //T[1]
                {
                    t = "";
                    Ext_Table.Table(TablePath);
                    string n_table = text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - text.IndexOf("[") - 1);
                    t = Ext_Table.table_c[int.Parse(n_table)];
                    Console.WriteLine(t);
                }
                else if (Regular_Exp.Table(text) == true) //T[1-],T[-3],T[1-2]
                {
                    t = "";
                    Ext_Table.Table(TablePath);
                    if (text.Substring(text.IndexOf("[") + 1, 1) == "-") //T[-3]
                    {
                        if (int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)) < Ext_Table.n_tbl)
                        {
                            Console.WriteLine(int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)));
                            for (int i = 1; i <= int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)); i++)
                            {
                                t += Ext_Table.table_c[i] + "\n";
                            }

                            Console.WriteLine(t);
                        }
                        else
                        {
                            Console.WriteLine("The number of tables exported is incorrect!");
                        }
                    }
                    else if (text.Substring(text.IndexOf("]") - 1, 1) == "-") //T[1-]
                    {
                        if (int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)) < Ext_Table.n_tbl)
                        {
                            Console.WriteLine(int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)));
                            for (int i = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)); i < Ext_Table.n_tbl; i++)
                            {
                                t += Ext_Table.table_c[i] + "\n";
                            }
                            Console.WriteLine(t);
                        }
                        else
                        {
                            Console.WriteLine("The number of tables exported is incorrect!");
                        }
                    }
                    else //T[1-2]
                    {
                        if ((int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)) < int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1))) && (int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)) < Ext_Table.n_tbl))
                        {
                            for (int i = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)); i <= int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)); i++)
                            {
                                t += Ext_Table.table_c[i] + "\n";
                            }
                            Console.WriteLine(t);
                        }
                        else
                        {
                            Console.WriteLine("The number of tables exported is incorrect!");
                        }
                    }
                }
                else if (Regular_Exp.Single_Table_TR(text) == true) //T[1]TR[1-], T[1]TR[-4], T[1]TR[1-3], T[1]TR[1]
                {
                    t = "";
                    if (text.Contains("-"))
                    {
                        if (text.Substring(text.IndexOf("TR[") + 3, 1) == "-") //T[1]TR[-4]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            Console.WriteLine(n_table);
                            //TR[]
                            String n_tr = text.Substring(text.IndexOf("-") + 1, text.Length - 2 - text.IndexOf("-"));
                            Console.WriteLine(n_tr);
                            Ext_Table.Table(TablePath);
                            if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                            {
                                for (int i = 1; i <= int.Parse(n_tr); i++)
                                {
                                    t += Ext_Table.tr[int.Parse(n_table), i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else if (text.Substring(text.Length - 2, 1) == "-") //T[1]TR[1-]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            //Console.WriteLine(n_table);
                            //TR[]
                            String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("-]") - text.IndexOf("TR[") - 3);
                            //Console.WriteLine(n_tr);
                            Ext_Table.Table(TablePath);
                            //Console.WriteLine(Ext_Table.n_tbl);
                            //Console.WriteLine(Ext_Table.table_tr[int.Parse(n_table)]);
                            if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                            {
                                for (int i = int.Parse(n_tr); i <= Ext_Table.table_tr[int.Parse(n_table)]; i++)
                                {
                                    t += Ext_Table.tr[int.Parse(n_table), i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else //T[1]TR[1-3]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            //Console.WriteLine(n_table);
                            //TR[]
                            String n_tr_start = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("-") - text.IndexOf("TR[") - 3);
                            String n_tr_end = text.Substring(text.IndexOf("-") + 1, text.Length - 2 - text.IndexOf("-"));
                            //Console.WriteLine(n_tr_start + "," + n_tr_end);
                            Ext_Table.Table(TablePath);
                            //Console.WriteLine(Ext_Table.table_tr[int.Parse(n_table)]);
                            if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tr_start) < int.Parse(n_tr_end) && int.Parse(n_tr_end) <= Ext_Table.table_tr[int.Parse(n_table)])
                            {
                                for (int i = int.Parse(n_tr_start); i <= int.Parse(n_tr_end); i++)
                                {
                                    t += Ext_Table.tr[int.Parse(n_table), i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                    }
                    else //T[1]TR[1]
                    {
                        //T[1]
                        String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                        Console.WriteLine(n_table);
                        //TR[]
                        String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.Length - 4 - text.IndexOf("TR["));
                        Console.WriteLine(n_tr);
                        Ext_Table.Table(TablePath);
                        if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                        {

                            t += Ext_Table.tr[int.Parse(n_table), int.Parse(n_tr)];

                            Console.WriteLine(t);

                        }
                        else
                        {
                            Console.WriteLine("error!");
                        }
                    }


                }
                else if (Regular_Exp.Single_Table_TC(text) == true) //T[1]TR[1]TC[1-2], T[1]TR[1]TC[-3], T[1]TR[1]TC[1-]
                {
                    t = "";
                    if (text.Substring(text.IndexOf("TC[") + 3, 1) == "-") //T[1]TR[1]TC[-2]
                    {
                        //T[1]
                        String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                        //Console.WriteLine(n_table);
                        //TR[]
                        String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                        //Console.WriteLine(n_tr);
                        //TC[]
                        String n_tc = text.Substring(text.IndexOf("TC[-") + 4, text.Length - text.IndexOf("TC[-") - 5);
                        //Console.WriteLine(n_tc);
                        Ext_Table.Table(TablePath);
                        //Console.WriteLine(Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)]);
                        if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tc) <= Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)] && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                        {
                            for (int i = 1; i <= int.Parse(n_tc); i++)
                            {
                                t += Ext_Table.table_con[int.Parse(n_table), int.Parse(n_tr), i];
                            }
                            Console.WriteLine(t);

                        }
                        else
                        {
                            Console.WriteLine("error!");
                        }
                    }
                    else if (text.Substring(text.Length - 2, 1) == "-") //T[1]TR[1]TC[1-]
                    {
                        //T[1]
                        String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                        //Console.WriteLine(n_table);
                        //TR[]
                        String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                        //Console.WriteLine(n_tr);
                        //TC[]
                        String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("-]") - text.IndexOf("TC[") - 3);
                        //Console.WriteLine(n_tc);
                        Ext_Table.Table(TablePath);
                        //Console.WriteLine(Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)]);
                        if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tc) <= Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)] && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                        {
                            for (int i = int.Parse(n_tc); i <= Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)]; i++)
                            {
                                t += Ext_Table.table_con[int.Parse(n_table), int.Parse(n_tr), i];
                            }
                            Console.WriteLine(t);

                        }
                        else
                        {
                            Console.WriteLine("error!");
                        }
                    }
                    else //T[1]TR[1]TC[1-2]
                    {
                        //T[1]
                        String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                        //Console.WriteLine(n_table);
                        //TR[]
                        String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                        //Console.WriteLine(n_tr);
                        //TC[]
                        String n_tc_start = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("-") - text.IndexOf("TC[") - 3);
                        String n_tc_end = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 2);
                        Console.WriteLine(n_tc_start + "," + n_tc_end);
                        Ext_Table.Table(TablePath);
                        //Console.WriteLine(Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)]);
                        if (int.Parse(n_table) < Ext_Table.n_tbl && int.Parse(n_tc_start) < int.Parse(n_tc_end) && int.Parse(n_tc_end) <= Ext_Table.table_tc[int.Parse(n_table), int.Parse(n_tr)] && int.Parse(n_tr) <= Ext_Table.table_tr[int.Parse(n_table)])
                        {
                            for (int i = int.Parse(n_tc_start); i <= int.Parse(n_tc_end); i++)
                            {
                                t += Ext_Table.table_con[int.Parse(n_table), int.Parse(n_tr), i];
                            }
                            Console.WriteLine(t);

                        }
                        else
                        {
                            Console.WriteLine("error!");
                        }
                    }
                }
                else if (Regular_Exp.Single_P_In_Table(text) == true) //T[1]TR[1]TC[2]P[1]C[1]
                {
                    t = "";
                    //T[1]
                    String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                    //Console.WriteLine(n_table);
                    //TR[]
                    String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                    //Console.WriteLine(n_tr);
                    //TC[]
                    String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("]P") - text.IndexOf("TC[") - 3);
                    //Console.WriteLine(n_tc);
                    //P[]
                    String n_p = text.Substring(text.IndexOf("P[") + 2, text.IndexOf("]C") - text.IndexOf("P[") - 2);
                    //Console.WriteLine(n_p);
                    //C[]
                    String n_c = text.Substring(text.IndexOf("]C[") + 3, text.Length - text.IndexOf("]C[") - 4);
                    //Console.WriteLine(n_c);
                    Ext_Table.Table(TablePath);

                    t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)].Substring(int.Parse(n_c), 1);
                    Console.WriteLine(t);
                }
                else if (Regular_Exp.Single_Text_In_Table(text) == true) //T[1]TR[1]TC[2]P[1]C[1-2],T[1]TR[1]TC[2]P[1]C[2]-P[2]C[3]
                {
                    t = "";
                    if (text.Contains("-P")) //T[3]TR[3]TC[3]P[1]C[0]-P[2]C[1]
                    {
                        //T[1]
                        String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                        //Console.WriteLine(n_table);
                        //TR[]
                        String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                        //Console.WriteLine(n_tr);
                        //TC[]
                        String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("]P") - text.IndexOf("TC[") - 3);
                        //Console.WriteLine(n_tc);
                        //P[]
                        String p_text_1 = text.Substring(text.IndexOf("]P") + 1, text.IndexOf("]-") - text.IndexOf("]P"));
                        //Console.WriteLine(p_text_1);
                        String p_text_2 = text.Substring(text.IndexOf("-P") + 1, text.Length - text.IndexOf("-P") - 1);
                        //Console.WriteLine(p_text_2);
                        String n_p_1 = p_text_1.Substring(p_text_1.IndexOf("P[") + 2, p_text_1.IndexOf("]C") - p_text_1.IndexOf("P[") - 2);
                        //Console.WriteLine(n_p_1);
                        String n_p_2 = p_text_2.Substring(p_text_2.IndexOf("P[") + 2, p_text_2.IndexOf("]C") - p_text_2.IndexOf("P[") - 2);
                        //Console.WriteLine(n_p_2);
                        //C[]
                        String n_c_1 = p_text_1.Substring(p_text_1.IndexOf("C[") + 2, p_text_1.Length - p_text_1.IndexOf("C[") - 3);
                        //Console.WriteLine(n_c_1);
                        String n_c_2 = p_text_2.Substring(p_text_2.IndexOf("C[") + 2, p_text_2.Length - p_text_2.IndexOf("C[") - 3);
                        //Console.WriteLine(n_c_2);

                        Ext_Table.Table(TablePath);

                        if (int.Parse(n_p_1) <= int.Parse(n_p_2) && int.Parse(n_p_2) <= Ext_Table.n && int.Parse(n_c_1) <= Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p_1)].Length && int.Parse(n_c_2) <= Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p_2)].Length)
                        {
                            t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p_1)].Substring(int.Parse(n_c_1));

                            for (int i = int.Parse(n_p_1) + 1; i < int.Parse(n_p_2); i++)
                            {
                                t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), i];
                            }
                            t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p_1)].Substring(0, int.Parse(n_c_2));
                            Console.WriteLine(t);
                        }
                    }
                    else //T[1]TR[1]TC[2]P[1]C[0-1], T[1]TR[1]TC[2]P[1]C[-1], T[1]TR[1]TC[2]P[1]C[0-]
                    {
                        if (text.Contains("[-")) //T[1]TR[1]TC[2]P[1]C[-1]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            //Console.WriteLine(n_table);
                            //TR[]
                            String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                            //Console.WriteLine(n_tr);
                            //TC[]
                            String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("]P") - text.IndexOf("TC[") - 3);
                            //Console.WriteLine(n_tc);
                            //P[]
                            String n_p = text.Substring(text.IndexOf("P[") + 2, text.IndexOf("]C") - text.IndexOf("P[") - 2);
                            //Console.WriteLine(n_p);
                            //C[]
                            String n_c_end = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 2);
                            //Console.WriteLine(n_c_end);

                            Ext_Table.Table(TablePath);

                            if (int.Parse(n_c_end) <= Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)].Length)
                            {

                                t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)];
                                t = t.Substring(0, int.Parse(n_c_end) + 1);

                                Console.WriteLine(t);
                            }

                        }
                        else if (text.Contains("-]")) //T[1]TR[1]TC[2]P[1]C[0-]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            //Console.WriteLine(n_table);
                            //TR[]
                            String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                            //Console.WriteLine(n_tr);
                            //TC[]
                            String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("]P") - text.IndexOf("TC[") - 3);
                            //Console.WriteLine(n_tc);
                            //P[]
                            String n_p = text.Substring(text.IndexOf("P[") + 2, text.IndexOf("]C") - text.IndexOf("P[") - 2);
                            //Console.WriteLine(n_p);
                            //C[]
                            String n_c_start = text.Substring(text.IndexOf("]C[") + 3, text.IndexOf("-") - text.IndexOf("]C[") - 3);
                            //Console.WriteLine(n_c_start);

                            Ext_Table.Table(TablePath);

                            if (int.Parse(n_c_start) <= Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)].Length)
                            {
                                t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)];
                                t = t.Substring(int.Parse(n_c_start));
                                Console.WriteLine(t);
                            }
                        }
                        else //T[1]TR[1]TC[2]P[1]C[0-1]
                        {
                            //T[1]
                            String n_table = text.Substring(text.IndexOf("T[") + 2, text.IndexOf("]") - text.IndexOf("T[") - 2);
                            //Console.WriteLine(n_table);
                            //TR[]
                            String n_tr = text.Substring(text.IndexOf("TR[") + 3, text.IndexOf("]TC") - text.IndexOf("TR[") - 3);
                            //Console.WriteLine(n_tr);
                            //TC[]
                            String n_tc = text.Substring(text.IndexOf("TC[") + 3, text.IndexOf("]P") - text.IndexOf("TC[") - 3);
                            //Console.WriteLine(n_tc);
                            //P[]
                            String n_p = text.Substring(text.IndexOf("P[") + 2, text.IndexOf("]C") - text.IndexOf("P[") - 2);
                            //Console.WriteLine(n_p);
                            //C[]
                            String n_c_start = text.Substring(text.IndexOf("]C[") + 3, text.IndexOf("-") - text.IndexOf("]C[") - 3);
                            //Console.WriteLine(n_c_start);
                            String n_c_end = text.Substring(text.IndexOf("-") + 1, text.Length - text.IndexOf("-") - 2);
                            //Console.WriteLine(n_c_end);

                            Ext_Table.Table(TablePath);

                            if (int.Parse(n_c_end) <= Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)].Length)
                            {
                                t += Ext_Table.table_p[int.Parse(n_table), int.Parse(n_tr), int.Parse(n_tc), int.Parse(n_p)];
                                t = t.Substring(int.Parse(n_c_start), int.Parse(n_c_end) - int.Parse(n_c_start) + 1);
                                Console.WriteLine(t);
                            }
                        }

                    }
                }
            }

        }

    }
}
