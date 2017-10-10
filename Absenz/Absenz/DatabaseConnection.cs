using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class DatabaseConnection
    {
        private readonly string _serverName;
        private readonly string _databaseName;
        private readonly string _username;
        private readonly string _password;

        public MySqlConnection Con;
        
        public DatabaseConnection(string serverName, string databaseName, string username, string password)
        {
            this._serverName = serverName;
            this._databaseName = databaseName;
            this._username = username;
            this._password = password;     
        }
        public void Connect()
        {
            Con = new MySqlConnection(@"Server=" + _serverName + "; database=" + _databaseName + "; UID=" + _username + "; password=" + _password + ";");
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