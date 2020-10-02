/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 16/10/2018
 * Time: 2:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

namespace Bookworm_Test
{
	/// <summary>
	/// Description of SQLDatabase.
	/// </summary>
	public class SQLDatabase
	{
		
		private SQLiteConnection connection_;
		private string database_filename_;
		private bool is_open_;

		public SQLDatabase()
		{
			database_filename_ = string.Empty;
			connection_ = null;
			is_open_ = false;
		}
		
		//this will create the database file in sqlite.
		public void create_database(string filename)
		{
			database_filename_ = filename + ".db";
			
			//check if the database file does not exist.
			if(!File.Exists(database_filename_)){
				//create the database file.
				SQLiteConnection.CreateFile(database_filename_);
			}
		}
		
		//this will connect to the database
		public void connect_database()
		{
			var database_source = "data source=" + database_filename_;
			
			//create swl connection using the database source.
			connection_ = new SQLiteConnection(database_source);
		}
		
		//this will open connection to the database.
		public bool open_connection()
		{
			//this will  check if the connection is available before accepting request.
			try{
				if(connection_ != null){
					//open database connection.
					connection_.Open();
					is_open_ = true;
				}
				else{
					//return false if connection not yet created.
					return false;
				}
				
			}catch{
				//return false if it fails to open.
				return false;
			}
				
			return true;
			
		}
		
		//this will close connection to the database.
		public void close_connection()
		{
			//if connection is opened, we can close the connection.
			if(connection_ != null && is_open_ == true){
				is_open_ = false;
				//close database connection.
				connection_.Close();
			}
		}
		
		//this will create table for the students record.
		public bool create_table()
		{
			if(connection_ != null){
				//if cannot open connection, do not accept request.
				if(open_connection() != true){
					return false;
				}
			}
			
			//create command for SQL.
			using(var command = new SQLiteCommand(connection_))
			{
				//create table query.
				var query = @"CREATE TABLE IF NOT EXISTS [students] (
                               [student_id] INTEGER NOT NULL PRIMARY KEY,
                               [last_name] VARCHAR(50) NOT NULL,
                               [first_name] VARCHAR(50) NOT NULL,
                               [address] VARCHAR(200) NOT NULL,
                               [high_score] INTEGER NOT NULL,
                               [year_level] INTEGER NOT NULL,
                               [last_level] INTEGER NOT NULL,
                               [last_score] INTEGER NOT NULL,
                               [music] INTEGER NOT NULL,
                               [games_played] INTEGER NOT NULL
                               )";
				
				//set the command for the query.
				command.CommandText = query;
				
				//execute command.
				command.ExecuteNonQuery();
			}
			
			//close the connection after use.
			close_connection();
			
			return true;
		}
	
		//this will insert data in the students record table.
		public bool insert_data(PlayerInfo student_info)
		{
			if(connection_ != null){
				//if cannot open connection, do not accept request.
				if(open_connection() != true){
					return false;
				}
			}
			
			//create command for SQL.
			using(var command = new SQLiteCommand(connection_))
			{
				//create insert data into table query.
				
				var query = @"INSERT INTO students (student_id, last_name, first_name, address, high_score, year_level, last_level, last_score, music, games_played) " 
							+ "VALUES(" 
								+ "'" + 	student_info.Player_id 	+ "'," 
								+ "'" + 	student_info.Last_name 		+ "'," 
								+ "'" + 	student_info.First_name 	+ "'," 
								+ "'" + 	student_info.Username 		+ "'," 
								+ "'" + 	student_info.High_score 	+ "'," 
								+ "'" + 	student_info.Highest_level 	+ "'," 
								+ "'" + 	student_info.Last_level 	+ "'," 
								+ "'" + 	student_info.Last_score 	+ "'," 
								+ "'" + 	student_info.Music			+ "'," 
								+ "'" + 	student_info.Games_played		
							+ "')";
				
				//set the command for the query.
				command.CommandText = query;
				//execute command.
				command.ExecuteNonQuery();
			}
			
			//close the connection after use.
			close_connection();
			
			return true;
		}
		
		//this will update data in the students record table.
		public bool update_data(PlayerInfo student_info)
		{
			if(connection_ != null){
				//if cannot open connection, do not accept request.
				if(open_connection() != true){
					return false;
				}
			}
			
			//create command for SQL.
			using(var command = new SQLiteCommand(connection_))
			{
				//create update data into table query.
				var query = @"UPDATE students SET "
								+ "student_id='" + 	student_info.Player_id 		+ "'," 
								+ "last_name='"  + 	student_info.Last_name 			+ "'," 
								+ "first_name='" + 	student_info.First_name 		+ "'," 
								+ "address='"    + 	student_info.Username 			+ "'," 
								+ "high_score='" + 	student_info.High_score 		+ "',"
								+ "year_level='" + 	student_info.Highest_level 		+ "',"
								+ "last_level='" + 	student_info.Last_level			+ "',"
								+ "last_score='" + 	student_info.Last_score			+ "',"
								+ "music='"		 + 	student_info.Music				+ "',"
								+ "games_played='"	+ student_info.Games_played		+ "'"
								+ " WHERE student_id='" + student_info.Player_id 	+ "'";
				
				//set the command for the query.
				command.CommandText = query;
				//execute command.
				command.ExecuteNonQuery();
			}
			
			//close the connection after use.
			close_connection();
			
			return true;
		}
		
		//this will delete the data in the table.
		public bool delete_data(int student_id)
		{
			if(connection_ != null){
				//if cannot open connection, do not accept request.
				if(open_connection() != true){
					return false;
				}
			}
			
			//create command for SQL.
			using(var command = new SQLiteCommand(connection_))
			{
				//create delete data into table query.
				var query = "DELETE FROM students WHERE student_id='" + student_id + "'";
				
				//set the command for the query.
				command.CommandText = query;
				//execute command.
				command.ExecuteNonQuery();
			}
			
			//close the connection after use.
			close_connection();
			
			return true;
		}		
		
		//this will get the data from the database.
		public List<PlayerInfo> view_data()
		{
			if(connection_ != null){
				//if cannot open connection, do not accept request.
				if(open_connection() != true){
					return null;
				}
			}
			
			var student_info_list = new List<PlayerInfo>();
			
			//create command for SQL.
			using(var command = new SQLiteCommand(connection_))
			{

				//create view data into table query.
				var query = "SELECT * FROM students";
				
				//set the command for the query.
				command.CommandText = query;

				//create reader command and execute.
				using(var reader = command.ExecuteReader())
				{
					//read all data from the table.
					while(reader.Read()){
						
						//get each data in the table rows based on the specified column name.
						var student_info = new PlayerInfo();
						student_info.Player_id = Convert.ToInt32(reader["student_id"]);
						student_info.Last_name = Convert.ToString(reader["last_name"]);
						student_info.First_name = Convert.ToString(reader["first_name"]);
						student_info.Username = Convert.ToString(reader["address"]);
						student_info.High_score = Convert.ToInt32(reader["high_score"]);
						student_info.Highest_level = Convert.ToInt32(reader["year_level"]);
						student_info.Last_level = Convert.ToInt32(reader["last_level"]);
						student_info.Last_score = Convert.ToInt32(reader["last_score"]);
						student_info.Music = Convert.ToInt32(reader["music"]);
						student_info.Games_played = Convert.ToInt32(reader["games_played"]);
						//add data in the list.
						student_info_list.Add(student_info);
					}
				}
			}
			
			//close the connection after use.
			close_connection();
		
			return student_info_list;	
		}
		
		
		
		
	}
}
