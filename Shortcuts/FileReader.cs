using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Shortcuts
{
    class FileReader
    {
        public List<ShortcutInfo> ReadFile(string fileToOpen)
        {
            List<ShortcutInfo> shortcuts = new List<ShortcutInfo>();
            string shortcutline;

            //Console.WriteLine(shortcuts.Count);

            if (File.Exists(fileToOpen))
            {
                using (StreamReader sr = new StreamReader(fileToOpen))
                {
                    //ShortcutsListbox.Items.Clear();
                    //shortcuts.Clear();

                    while (sr.EndOfStream != true)
                    {
                        shortcutline = sr.ReadLine();
                        if (shortcutline.Trim() != "" && !shortcutline.Trim().StartsWith("#"))
                        {
                            //ShortcutsListbox.Items.Add(shortcutline);
                            ShortcutInfo sc = new ShortcutInfo(shortcutline);
                            shortcuts.Add(sc);
                            //Console.WriteLine(shortcuts.Count);
                        }
                    }
                    sr.Close();
                }

                /*
                foreach (ShortcutInfo sc in shortcuts)
                    Console.WriteLine(sc);
                Console.WriteLine(shortcuts.Count);
                */
            }
            else
            {
                MessageBox.Show("File " + fileToOpen + " not found!", "File not found");
            }
            return shortcuts;
        }
    }
}
