using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Push
{
    class bridge
    {
        static public int currentscreen = 1;
        static public int currentlevel;
        static public bool turnonfirstscreen = true;
        static public bool isfirst2=true;
        static public bool[] passed = { false, false, false, false, false, false, false, false, false, false, false, false };
        public static bool getPass(int l)
        {
            return passed[l];
        }
        public static void setPass(int l)
        {
            passed[l] = true;
        }
        public static int levelcounter()
        {
            int retcount = 0;
            for (int i =0;i<passed.Length;i++)
            { if(passed[i]){ retcount++; } }
            return retcount;
        }
    }
}
