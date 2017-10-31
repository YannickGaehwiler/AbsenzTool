using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class DatabaseConnection
    {
        public MySqlConnection Con;
        
        public DatabaseConnection(string serverName, string databaseName, string username, string password)
        {
            Con = new MySqlConnection(@"Server=" + serverName + "; database=" + databaseName + "; UID=" + username + "; password=" + password + ";");
        }
        public void Connect()
        {
            try
            {
                Con.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}