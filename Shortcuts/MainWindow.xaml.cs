using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace Shortcuts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //string fileToOpen = "C:\\Users\\klaus\\Documents\\shortcuts\\shortcuts_findes_ikke.txt";
        string fileToOpen = "C:\\Users\\klaus\\Documents\\shortcuts\\shortcuts.txt";
        List<ShortcutInfo> shortcuts = new List<ShortcutInfo>(); 

        public MainWindow()
        {
            InitializeComponent();
            updateShortcuts();
        }

        private void executeShortcut (string link)
        {
            if (link.StartsWith("http"))
            {
                System.Diagnostics.Process.Start("cmd", "/C start" + " " + link);
            }
            else if (File.Exists(link))
            {
                
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = link
                };
                process.Start();
                

                //cmd /C start www.google.com
                //cmd /c start https://google.com
                //System.Diagnostics.Process.Start("explorer.exe", "http://google.com");

                //process.WaitForExit();
            }
            else if (link == "" || link == null)
            {
                MessageBox.Show("There is no shortcut defined!", "No shortcut defined");
            }
            else
            {
                MessageBox.Show("File " + link + " not found!", "File not found");
            }

        }

        private void openShortcutsFile()
        {
            if (File.Exists(fileToOpen))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = fileToOpen
                };

                process.Start();
                //process.WaitForExit();
            }
            else
            { 
                MessageBox.Show("File " + fileToOpen + " not found!", "File not found");
            }
        }
        private void openShortcutsFileButton_Click(object sender, RoutedEventArgs e)
        {
            openShortcutsFile();
        }


        private void updateShortcuts()
        {
            string shortcutline;

            FileReader fr = new FileReader();

            shortcuts = fr.ReadFile(fileToOpen);
            ShortcutsListbox.Items.Clear();

            foreach (ShortcutInfo sc in shortcuts)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = sc.ShortcutLabel;
                ToolTipService.SetToolTip(itm, sc.ShortcutToolTip);
                ShortcutsListbox.Items.Add(itm);
            }
        }

        private void updateShortcutsButton_Click(object sender, RoutedEventArgs e)
        {
            updateShortcuts();  
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HandleListBoxSelection ()
        {
            ShortcutInfo sc;
            //MessageBox.Show("Valgt: " + ShortcutsListbox.SelectedItem + "Index: " + ShortcutsListbox.SelectedIndex, "Shortcut selected");
            sc = shortcuts[ShortcutsListbox.SelectedIndex];
            if (!sc.ShortcutLabel.StartsWith("\'"))
            {
                executeShortcut(sc.ShortcutLink);
            }
            ShortcutsListbox.UnselectAll();
        }

        private void ShortcutsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((bool)RunAtSelection.IsChecked && ShortcutsListbox.SelectedIndex >= 0)
            {
                HandleListBoxSelection();

                /* ShortcutInfo sc;
                //MessageBox.Show("Valgt: " + ShortcutsListbox.SelectedItem + "Index: " + ShortcutsListbox.SelectedIndex, "Shortcut selected");
                sc = shortcuts[ShortcutsListbox.SelectedIndex];
                executeShortcut(sc.ShortcutLink); */
            }
        }

        
        private void ShortcutsListbox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((bool)RunAtSelection.IsChecked && ShortcutsListbox.SelectedIndex >= 0)
            {
                HandleListBoxSelection();

                /* ShortcutInfo sc;
                //MessageBox.Show("Valgt: " + ShortcutsListbox.SelectedItem + "Index: " + ShortcutsListbox.SelectedIndex, "Shortcut selected");
                sc = shortcuts[ShortcutsListbox.SelectedIndex];
                executeShortcut(sc.ShortcutLink); */
            }
        }

        private void ShortcutsListbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((bool)RunAtDoubleClick.IsChecked && ShortcutsListbox.SelectedIndex >= 0)
            {
                HandleListBoxSelection();

                /* ShortcutInfo sc;
                //MessageBox.Show("MouseDoubleClick: Valgt: " + ShortcutsListbox.SelectedItem + "Index: " + ShortcutsListbox.SelectedIndex, "Shortcut selected");
                sc = shortcuts[ShortcutsListbox.SelectedIndex];
                executeShortcut(sc.ShortcutLink); */
            }
        }

        private void ShortcutsListbox_KeyUp(object sender, KeyEventArgs e)
        {
            if ((bool)RunAtDoubleClick.IsChecked && ShortcutsListbox.SelectedIndex >= 0)
            {
                if (e.Key == Key.Return || e.Key == Key.Space)
                {
                    HandleListBoxSelection();

                    /* ShortcutInfo sc;
                    //MessageBox.Show("KeyUp: Valgt: " + ShortcutsListbox.SelectedItem + "Index: " + ShortcutsListbox.SelectedIndex, "Shortcut selected");
                    sc = shortcuts[ShortcutsListbox.SelectedIndex];
                    executeShortcut(sc.ShortcutLink); */
                }
            }
        }
    }
}
