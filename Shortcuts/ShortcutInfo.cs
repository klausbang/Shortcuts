using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortcuts
{
    class ShortcutInfo
    {

        private string label;
        private string link;
        private string tooltip;

        public string ShortcutLabel
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }

        }

        public string ShortcutLink
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }

        }
        public string ShortcutToolTip
        {
            get
            {
                return tooltip;
            }
            set
            {
                tooltip = value;
            }

        }

        public ShortcutInfo(string sc_line)
        {
            string[] sc_content = sc_line.Split(new char[] { '\t' });
            if (sc_content.Length >= 1)
            {
                ShortcutLabel = sc_content[0];
            }
            if (sc_content.Length >= 2)
            {
                ShortcutLink = sc_content[1];
                if (sc_content.Length == 2)
                {
                    ShortcutToolTip = sc_content[1]; // If no tooltip - set the link as the tooltip
                }
            }
            if (sc_content.Length >= 3)
            {
                ShortcutToolTip = sc_content[2] + "\n" + sc_content[1];
            }
        }

        public ShortcutInfo (string sc_label, string sc_link, string sc_tooltip)
        {
            ShortcutLabel = sc_label;
            ShortcutLink = sc_link;
            ShortcutToolTip = sc_tooltip;
        }

        public override string ToString()
        {
            return "ShortcutLabel = " + ShortcutLabel + ", ShortcutLink = " + ShortcutLink + ", ShortcutToolTip = " + ShortcutToolTip;
        }
    }
        
}
