using Memory_Note.util;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Memory_Note
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Opens the MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If there is no text in noteTextBox, then the program will close.
        /// If there is text if the noteTextBox, then the user will be prompted to save the note.
        /// </summary>
        private void Close_Window(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (noteTextBox.Text.Trim().Equals("")) { return; }
            else
            {
                const string message = "Do you want to save this note?";
                const string caption = "New note";
                MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) { Save_Command(sender, null); }
                else if (result == MessageBoxResult.No) { return; }
            }
        }

        /// <summary>
        /// Clears all text from noteTextBox.
        /// </summary>
        private void New_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (noteTextBox.Text.Trim().Equals("")) { noteTextBox.Text = ""; }
            else
            {
                const string message = "Do you want to save this note?";
                const string caption = "New note";
                MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes) { Save_Command(sender, e); }
                else if (result == MessageBoxResult.Cancel) { return; }
                else { noteTextBox.Text = ""; }
            }
        }

        /// <summary>
        /// Opens a file dialog for the user to select or type a filename.
        /// If the user selects "Open", then the contents of file will be written to the noteTextBox.
        /// </summary>
        private void Open_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open text file",
                Filter = "Text file (*.txt)|*.txt",
                InitialDirectory = Environment.CurrentDirectory
            };
            try
            {
                openFileDialog.ShowDialog();
                noteTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Opens a file dialog for the user to select or type a filename.
        /// If the user selects "Save", then the contents of noteTextBox will be written to the file.
        /// </summary>
        private void Save_Command(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save text file",
                Filter = "Text file (*.txt)|*.txt",
                InitialDirectory = Environment.CurrentDirectory
            };
            try
            {
                saveFileDialog.ShowDialog();
                File.WriteAllText(saveFileDialog.FileName, noteTextBox.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Closes the program.
        /// </summary>
        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens a file dialog for the user to select or type a filename.
        /// If the user selects "Open", then the file will be encrypted.
        /// </summary>
        private void Encrypt_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Encrypt text file",
                Filter = "Text file (*.txt)|*.txt",
                InitialDirectory = Environment.CurrentDirectory
            };
            try
            {
                openFileDialog.ShowDialog();
                MNTools encryptTool = new MNTools();
                encryptTool.EncryptFile(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Opens a file dialog for the user to select or type a filename.
        /// If the user selects "Open", then the file will be decrypted.
        /// </summary>
        private void Decrypt_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Decrypt text file",
                Filter = "Text file (*.txt)|*.txt",
                InitialDirectory = Environment.CurrentDirectory
            };
            try
            {
                openFileDialog.ShowDialog();
                MNTools decryptTool = new MNTools();
                decryptTool.DecryptFile(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Changes the UI into a darker appearance.
        /// </summary>
        private void DarkMode_Checked(object sender, RoutedEventArgs e)
        {
            noteTextBox.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 30, 30));
            noteTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            DarkMode_MenuItemIcons();
        }

        /// <summary>
        /// Changes the UI into a lighter appearance.
        /// </summary>
        private void DarkMode_Unchecked(object sender, RoutedEventArgs e)
        {
            noteTextBox.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            noteTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            Default_MenuItemIcons();
        }

        /// <summary>
        /// The user's spelling will be checked for grammar errors.
        /// </summary>
        private void SpellCheck_Checked(object sender, RoutedEventArgs e)
        {
            noteTextBox.SpellCheck.IsEnabled = true;
        }

        /// <summary>
        /// The user's spelling will not be checked for grammar errors.
        /// </summary>
        private void SpellCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            noteTextBox.SpellCheck.IsEnabled = false;
        }
        
        /// <summary>
        /// Changes the MenuItem icons for higher contrast in Dark mode.
        /// </summary>
        private void DarkMode_MenuItemIcons()
        {
            openMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/open.png", UriKind.Relative)) };
            saveMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/save.png", UriKind.Relative)) };
            cutMenutItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/cut.png", UriKind.Relative)) };
            copyMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/copy.png", UriKind.Relative)) };
            pasteMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/paste.png", UriKind.Relative)) };
            encryptMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/encrypt.png", UriKind.Relative)) };
            decrptMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/contrast/decrypt.png", UriKind.Relative)) };
        }

        /// <summary>
        /// Changes the MenuItem icons to their default state.
        /// </summary>
        private void Default_MenuItemIcons()
        {
            openMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/open.png", UriKind.Relative)) };
            saveMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/save.png", UriKind.Relative)) };
            cutMenutItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/cut.png", UriKind.Relative)) };
            copyMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/copy.png", UriKind.Relative)) };
            pasteMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/paste.png", UriKind.Relative)) };
            encryptMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/encrypt.png", UriKind.Relative)) };
            decrptMenuItem.Icon = new System.Windows.Controls.Image { Source = new BitmapImage(new Uri("/assets/default/decrypt.png", UriKind.Relative)) };
        }

        /// <summary>
        /// Displays a font dialog.
        /// </summary>
        private void Font_Click(object sender, RoutedEventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult dr = fontDialog.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                noteTextBox.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                noteTextBox.FontSize = fontDialog.Font.Size * 96.0 / 72.0;
                noteTextBox.FontWeight = fontDialog.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                noteTextBox.FontStyle = fontDialog.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
            }
        }
    }
}
