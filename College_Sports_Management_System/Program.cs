using Microsoft.Data.SqlClient;
namespace College_Sports_Management_System
{
    internal class Program
    {
        public string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=College_Sports_Management_System;Integrated Security=True;Encrypt=False";
        
        static void Main(string[] args)
        {

            Program obj= new Program();
            int opt;
            Console.WriteLine("\n***********************************************\n" +
                " Welcome To College Sport Management System" +
                "\n***********************************************\n" +
                "\n Press 1 to Add Sport" +
                "\n Press 2 to Add Tournament" +
                "\n Press 3 to Add Scoreboard" +
                "\n Press 4 to Remove Sport" +
                "\n Press 5 to Remove Tournament" +
                "\n Press 6 to Edit Scoreboard" +
                "\n Press 7 to Remove Player" +
                "\n Press 8 for Individual Registration " +
                "\n Press 9 for Group Registration" +
                "\n Press 10 for Payment");
            do
            {
                
                Console.WriteLine("\n*************\n");
                opt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n*************\n");

                switch (opt)
                {
                    case 1:
                        obj.addSport();
                        break;
                    case 2:
                        obj.addTournament();
                        break;

                    case 3:
                        obj.addScore();
                        break;

                    case 4:
                        obj.remove("Sports","sport_id");
                        break;

                    case 5:
                        obj.remove("Tournament", "tournament_id");
                        break;

                    default:
                        Console.WriteLine("default");
                        break;
                }
            } while (opt != 0);
        }
        public void addSport()
        {
            Console.WriteLine("Ok.. ENtering Add SPorts Module");
            display_table("Sports");
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow enter details to be added in this table ");
            Console.Write("Enter Sport_Id :");
            int sport_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Sport_Name :");
            string sport_name=Console.ReadLine();

            string query = "insert into Sports(sport_id,sport_name) Values(@sport_id,@sport_name)";
            command.Parameters.AddWithValue("@sport_id",sport_id);
            command.Parameters.AddWithValue("@sport_name", sport_name);
            command.CommandText=query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Inserted Successfully..!!");
            display_table("Sports");
        }
        public void addTournament()
        {
            Console.WriteLine("Ok.. ENtering Add Tournament Module");
            display_table("Tournament");
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow enter details to be added in this table ");
            Console.Write("Enter Tournament_id :");
            int tourn_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Tournament_Name :");
            string tourn_name = Console.ReadLine();
            Console.Write("Enter Sport_Id :");
            int sport_id = Convert.ToInt32(Console.ReadLine());

            string query = "insert into Tournament(tournament_id,tournament_name,sport_id) Values(@tournament_id,@tournament_name,@sport_id)";
            command.Parameters.AddWithValue("@tournament_id", tourn_id);
            command.Parameters.AddWithValue("@tournament_name", tourn_name);
            command.Parameters.AddWithValue("@sport_id", sport_id);
            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Inserted Successfully..!!");
            display_table("Tournament");
        }

        public void addScore()
        {
            Console.WriteLine("Ok.. ENtering Add Scoreboard Module");
            display_table("Tournament");
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow enter details to be added in this table ");
            Console.Write("Enter Tournament_id :");
            int tourn_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Tournament_Name :");
            string tourn_name = Console.ReadLine();
            Console.Write("Enter Sport_Id :");
            int sport_id = Convert.ToInt32(Console.ReadLine());

            string query = "insert into Tournament(tournament_id,tournament_name,sport_id) Values(@tournament_id,@tournament_name,@sport_id)";
            command.Parameters.AddWithValue("@tournament_id", tourn_id);
            command.Parameters.AddWithValue("@tournament_name", tourn_name);
            command.Parameters.AddWithValue("@sport_id", sport_id);
            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Inserted Successfully..!!");
            display_table("Tournament");

        }
        public void remove(string table_name,string column_name)
        {
            Console.WriteLine($"Ok.. ENtering Remove {table_name} Module");
            display_table(table_name);
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine($"\n\nNow enter {column_name} which you want to remove ");
            Console.Write($"Enter {column_name} :");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = $"delete {table_name} where {column_name}={id}";
            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();

            Console.WriteLine($"\n\n{table_name} Removed Successfully..!!");
            display_table(table_name);
        }

        
        public void display_table(string table_name)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            string query = $"SELECT * FROM {table_name}";
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"\nThis is your Current {table_name} Table\n");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            conn.Close();
        }

       
    }
}