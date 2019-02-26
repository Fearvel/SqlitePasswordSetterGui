using System;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using de.fearvel.net.SQL.Connector;
namespace de.fearvel.gui.SqlitePasswordSetter
{
    /// <summary>
    /// MainWindow of the Password setter
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// MainWindow Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to select a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPathFinder_OnClick(object sender, RoutedEventArgs e)
        {
            var dia = new OpenFileDialog();
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxPath.Text = dia.FileName;
            }
        }

        /// <summary>
        /// On Click method
        /// Sets Password of an Sqlite file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSet_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxPath.Text.Length == 0)
            {
                MessageBox.Show("Please select a File", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var con = new SqliteConnector(TextBoxPath.Text, TextBoxOldPassword.Text);
                con.SetPassword(TextBoxNewPassword.Text);
                MessageBox.Show("Done", "OK", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show("An Error Occured, the Password couldnt be changed\n" + exception, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
