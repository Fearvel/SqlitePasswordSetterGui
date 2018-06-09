using System;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using de.fearvel.net.SQL.Connector;
namespace de.fearvel.gui.SqlitePaswordSetter
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPathFinder_OnClick(object sender, RoutedEventArgs e)
        {
            var dia = new OpenFileDialog();
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxPath.Text = dia.FileName;
            }
        }

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
