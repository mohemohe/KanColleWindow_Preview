using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanColle
{
    public class arPath
    {
        public static string relativePath(string path1, string path2)
        {
            Uri sPath1 = new Uri(path1 + @"\");
            Uri sPath2 = new Uri(path2);
            Uri sPath3 = sPath1.MakeRelativeUri(sPath2);

            return sPath3.ToString().Replace("/", @"\");
        }

        public static string absolutePath(string path1, string path2)
        {
            Uri sPath1 = new Uri(path1 + @"\");
            Uri sPath2 = new Uri(sPath1, path2);

            string sPath3 = sPath2.ToString().Replace("file:///", "");
            return sPath3.Replace("/", @"\");
        }
    }
}
