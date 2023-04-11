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
                "\n Press 8 for Registration " +
                "\n Press 9 for Payment");
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
                    case 6:
                        obj.editScore();
                        break;
                    case 8:
                        Console.WriteLine("Press G for Group Registration and " +
                            "I for Individual Registration");
                        string option= Console.ReadLine();
                        if (option.Equals("I"))
                        {
                            obj.individual_Registration();
                        }
                        else
                        {
                            obj.group_Registration();
                        }
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
            Console.WriteLine("Ok.. Entering Add Scoreboard Module");
            display_table("Scoreboard");
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow enter details to be added in this table ");
            Console.Write("Enter Scoreboard_id :");
            int scoreboard_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Tournament id :");
            int tourn_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Sport_Id :");
            int sport_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Team 1 Name :");
            string t1_name = Console.ReadLine();
            Console.Write("Enter Team 2 Name :");
            string t2_name = Console.ReadLine();
            Console.Write("Enter Team1 Score :");
            int t1_score = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Team2 Score :");
            int t2_score = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Result :");
            string result = Console.ReadLine();

            string query = "insert into Scoreboard(scoreboard_id,tournament_id,sport_id,t1_name,t2_name,t1_score,t2_score,result) " +
                "Values(@scoreboard_id,@tournament_id,@sport_id,@t1_name,@t2_name,@t1_score,@t2_score,@result)";
            command.Parameters.AddWithValue("@scoreboard_id", scoreboard_id);
            command.Parameters.AddWithValue("@tournament_id", tourn_id);
            command.Parameters.AddWithValue("@sport_id", sport_id);
            command.Parameters.AddWithValue("@t1_name", t1_name);
            command.Parameters.AddWithValue("@t2_name", t1_name);
            command.Parameters.AddWithValue("@t1_score", t1_score);
            command.Parameters.AddWithValue("@t2_score", t2_score);
            command.Parameters.AddWithValue("@result", result);


            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Inserted Successfully..!!");
            display_table("Scoreboard");

        }
        public void editScore()
        {
            Console.WriteLine("Ok.. ENtering Edit Scoreboard Module");
            display_table("Scoreboard");

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow Enter the tournament id to which you have to update score");
            Console.Write("Enter Tournament_id :");
            int tourn_id = Convert.ToInt32(Console.ReadLine());

            string query = $"SELECT * FROM Scoreboard where tournament_id={tourn_id}";
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"\nThe data you are trying to update...\n");
            string team1_name="";
            string team2_name="";

            Console.WriteLine("\n--------------------------------------------------------------------------------------");
            while (reader.Read())
            {
                Console.Write(reader.GetInt32(0) + "\t");
                Console.Write(reader.GetInt32(1) + "\t");
                Console.Write(reader.GetInt32(2) + "\t");
                team1_name = reader.GetString(3);
                Console.Write(team1_name + "\t");
                team2_name = reader.GetString(4);
                Console.Write(team2_name + "\t");
                Console.Write(reader.GetInt32(5) + "\t");
                Console.Write(reader.GetInt32(6) + "\t");
                Console.Write(reader.GetString(7) + "\t");
            }
            reader.Close();
            Console.WriteLine("\n--------------------------------------------------------------------------------------");


            Console.Write($"\nEnter {team1_name} Score:");
            int team1_score = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter {team2_name} Score:");
            int team2_score = Convert.ToInt32(Console.ReadLine());
            string result = "";
            if (team1_score > team2_score)
            {
                result = team1_name;
            }
            else
            {
                result=team2_name;
            }
            
            query = $"update Scoreboard set t1_score={team1_score}, t2_score={team2_score}, result='{result}' where tournament_id={tourn_id}";
            
            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Updated Successfully..!!");
            display_table("Scoreboard");
        }
        public void individual_Registration()
        {
            Console.WriteLine("Ok.. ENtering In Module");
            display_table("Scoreboard");

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand command = conn.CreateCommand();

            Console.WriteLine("\n\nNow Enter the tournament id to which you have to update score");
            Console.Write("Enter Tournament_id :");
            int tourn_id = Convert.ToInt32(Console.ReadLine());

            string query = $"SELECT * FROM Scoreboard where tournament_id={tourn_id}";
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"\nThe data you are trying to update...\n");
            string team1_name = "";
            string team2_name = "";

            Console.WriteLine("\n--------------------------------------------------------------------------------------");
            while (reader.Read())
            {
                Console.Write(reader.GetInt32(0) + "\t");
                Console.Write(reader.GetInt32(1) + "\t");
                Console.Write(reader.GetInt32(2) + "\t");
                team1_name = reader.GetString(3);
                Console.Write(team1_name + "\t");
                team2_name = reader.GetString(4);
                Console.Write(team2_name + "\t");
                Console.Write(reader.GetInt32(5) + "\t");
                Console.Write(reader.GetInt32(6) + "\t");
                Console.Write(reader.GetString(7) + "\t");
            }
            reader.Close();
            Console.WriteLine("\n--------------------------------------------------------------------------------------");


            Console.Write($"\nEnter {team1_name} Score:");
            int team1_score = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter {team2_name} Score:");
            int team2_score = Convert.ToInt32(Console.ReadLine());
            string result = "";
            if (team1_score > team2_score)
            {
                result = team1_name;
            }
            else
            {
                result = team2_name;
            }

            query = $"update Scoreboard set t1_score={team1_score}, t2_score={team2_score}, result='{result}' where tournament_id={tourn_id}";

            command.CommandText = query;
            command.ExecuteReader();

            conn.Close();
            Console.WriteLine("\n\nValues Updated Successfully..!!");
            display_table("Scoreboard");
        }
        public void group_Registration()
        {

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
            Console.WriteLine("\n--------------------------------------------------------------------------------------");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            conn.Close();
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

       
    }
}