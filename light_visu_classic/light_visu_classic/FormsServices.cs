using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace light_visu_classic
{
    public static class FormsServices
    {
        public static int GetIndexOfControl( Control.ControlCollection controls, string name )
        {
            int index = 0;
            return  index = controls.IndexOfKey( name );
        }

    }
}
