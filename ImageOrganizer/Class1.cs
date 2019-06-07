using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    class GuiHelper
    {

        public static ToolTip help(Control control, Button helpButton, string message)
        {

            ToolTip toolTip = new ToolTip();

            toolTip.ToolTipTitle = "Help";
                        
            toolTip.UseFading = true;

            toolTip.UseAnimation = true;

            toolTip.IsBalloon = true;

            toolTip.ToolTipIcon = ToolTipIcon.Info;

            toolTip.ShowAlways = true;

            toolTip.SetToolTip(control, "Help");

            helpButton.Click += (x,y) => { toolTip.Show(message, control); };

            return toolTip;

        }

    }
}
