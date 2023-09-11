using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class PPT_Text
    {
        public static string t = "";
        public static void PPT_T(String pptFilePath, String text)
        {
            
            if (Regular_Exp.Presentation(text) == true)
            {
                t = "";
                //Ext_PPT.Topic(pptFilePath, pptFilePath.Replace(".pptx",""),int.Parse(text.Substring(text.IndexOf("-") + 1,text.IndexOf("]") - text.IndexOf("-") - 1)));
                //提取文本
                if (text.Contains("-") == true) //SL[1-2],SL[1-],SL[-2]
                {
                    t = "";
                    if (text.Substring(text.IndexOf("[") + 1, 1) == "-") //SL[-2]
                    {
                        t = "";
                        for (int i = 1; i <= int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1)); i++)
                        {
                            Ext_PPT.text(pptFilePath, i);
                            t += Ext_PPT.t;
                        }
                        Console.WriteLine(t);

                    }
                    else if (text.Substring(text.IndexOf("]") - 1, 1) == "-") //SL[1-]
                    {
                        t = "";
                        for (int i = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1)); i <= Ext_PPT.Slide_Count(pptFilePath); i++)
                        {
                            //Console.WriteLine(i);
                            //t = Ext_PPT.text(pptFilePath, i);
                            Ext_PPT.text(pptFilePath, i);
                            t += Ext_PPT.t;
                        }
                        Console.WriteLine(t);
                    }
                    else //SL[1-2]
                    {
                        t = "";
                        int s1 = int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("-") - text.IndexOf("[") - 1));
                        int s2 = int.Parse(text.Substring(text.IndexOf("-") + 1, text.IndexOf("]") - text.IndexOf("-") - 1));
                        for (int i = s1; i <= s2; i++)
                        {
                            //t = Ext_PPT.text(pptFilePath, i);
                            Ext_PPT.text(pptFilePath, i);
                            t += Ext_PPT.t;
                        }
                        //Console.WriteLine(t);
                    }
                }
                else //SL[1]
                {
                    t = "";
                    Ext_PPT.text(pptFilePath, int.Parse(text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - 1 - text.IndexOf("["))));
                    t = Ext_PPT.t;
                    //t = Ext_PPT.text(pptFilePath, int.Parse(text.Substring(text.IndexOf("[") + 1, text.Length - 1)));
                    Console.WriteLine(t);
                }

                //Ext_PPT.pic(pptFilePath, pptFilePath.Replace(".pptx", ""));
            }
        }
    }
}
