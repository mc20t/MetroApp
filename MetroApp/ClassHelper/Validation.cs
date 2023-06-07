using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Threading.Tasks;
using MetroApp.Pages.EditPages;
using MetroApp.DB;

namespace MetroApp.ClassHelper
{
    public class Validation
    {
        public static bool IsNameValid(string name)
        {
            if (name.Length < 1)
            {
                return false;
            }
            else if (name.Length > 50)
            {
                return false;
            }

            return true;
        }

        public static bool IsAbbrValid(string abbr)
        {
            if (abbr.Length < 1)
            {
                return false;
            }
            else if (abbr.Length > 7)
            {
                return false;
            }

            return true;
        }

        public static bool IsTintValid(string tint)
        {
            try
            {
                byte p = byte.Parse(tint);
                return p > 0 && p <= 255;
            }
            catch
            {
                return false;
            }
        }
    }
}
