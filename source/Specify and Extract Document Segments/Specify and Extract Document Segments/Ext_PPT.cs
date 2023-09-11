using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using PictureFormat = Microsoft.Office.Interop.PowerPoint.PictureFormat;
using System.Drawing;

namespace Specify_and_Extract_Document_Segments
{

    internal class Ext_PPT
    {
        public static String t;
        
        public static int Slide_Count(string pptPath)
        {
            Application app = new Application();
            Presentation ppt = app.Presentations.Open(pptPath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            int pageCount = ppt.Slides.Count;
            return pageCount;
            ppt.Close();
            app.Quit();
        }
        public static void text(string pptPath, int index)
        {
            t = " ";
            Application app = new Application();
            Presentation ppt = app.Presentations.Open(pptPath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            int pageCount = ppt.Slides.Count;
            Slide slide = ppt.Slides[index];
            foreach (Shape shape in slide.Shapes)
            {
                if (shape.HasTextFrame == MsoTriState.msoTrue && shape.TextFrame.HasText == MsoTriState.msoTrue)
                {
                    t += shape.TextFrame2.TextRange.Text + "\n";
                    //Console.WriteLine(t);
                }
            }

            //return t;
            ppt.Close();
            app.Quit();
            
        }
        
    }
}
