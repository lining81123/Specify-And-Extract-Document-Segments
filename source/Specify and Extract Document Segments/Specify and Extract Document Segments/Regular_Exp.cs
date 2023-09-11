using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class Regular_Exp
    {
        public static bool Single_Paragraph(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(P(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\])$");

        }
        //P[1-],P[1-2],P[-2]
        public static bool Paragraph(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(P(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?(\[[0-9]+\]|\[[0-9]+-[0-9]+\]|\[[0-9]+-\]|\[-[0-9]+\]))$");

        }
        //P[1]C[1-2],P[1]C[2],P[1]C[2]-P[3]C[4]
        public static bool Text_In_Paragraph(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(P(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\](C\[[0-9]+\](-P\[[0-9]+\]C\[[0-9]+\])?|C(\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\])))$");

        }
        public static bool Table(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?(\[[0-9]+\]|\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\]))$");

        }
        public static bool Single_Table(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\])$");

        }
        public static bool Single_Table_TR(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]TR(\[[0-9]+\]|\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\]))$");

        }
        public static bool Single_Table_TC(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]TR\[[0-9]+\]TC(\[[0-9]+\]|\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\]))$");

        }
        public static bool Single_Text_In_Table(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]TR\[[0-9]+\]TC\[[0-9]+\]((<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?(P\[[0-9]+\]C\[[0-9]+\](-P\[[0-9]+\]C\[[0-9]+\])?)|(P\[[0-9]+\]C(\[[0-9]+\]|\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\]))))$");

        }
        public static bool Single_P_In_Table(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]TR\[[0-9]+\]TC\[[0-9]+\]P\[[0-9]+\]C\[[0-9]+\])$");

        }
        public static bool Text_In_Table(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]TR\[[0-9]+\]TC\[[0-9]+\]P(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]C\[[0-9]+\](-(T(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\])?(TR\[[0-9]+\])?(TC\[[0-9]+\])?P(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\]C\[[0-9]+\])?");

        }
        public static bool Spreadsheet(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"S(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?"+'"' + "[A -Za-z0-9]+" + '"' + "!([A-Z]+[0-9]+)(:[A-Z]+[0-9]+)?");

        }
        public static bool Presentation(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"SL(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?([[0-9]+-[0-9]+]|[[0-9]+]|[[0-9]+-]|[-[0-9]+])");

        }
        //PG[1]
        public static bool Single_Page(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(PG(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\])$");

        }
        //PG[1-],PG[-2],PG[1-5]
        public static bool Page(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(PG(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?(\[[0-9]+\]|\[[0-9]+-[0-9]+\]|\[[0-9]+-\]|\[-[0-9]+\]))$");

        }
        //PG[1]O[1-2],PG[1]O[2],PG[1]O[2]-PG[3]O[4]
        public static bool Object_In_Page(string StrSource)
        {

            return Regex.IsMatch(StrSource, @"^(PG(<(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]>)?\[[0-9]+\](O\[[0-9]+\](-PG\[[0-9]+\]O\[[0-9]+\])?|O(\[([0-9]+-|-[0-9]+|[0-9]+-[0-9]+)\])))$");

        }

    }
}
