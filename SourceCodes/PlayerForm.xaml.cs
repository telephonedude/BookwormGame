/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 16/10/2018
 * Time: 2:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Bookworm_Test
{
	/// <summary>
	/// Interaction logic for PlayerForm.xaml
	/// </summary>
	public partial class PlayerForm : Window
	{
		private SQLDatabase database_;
		public int randomID;
		
		public PlayerForm(SQLDatabase database)
		{
			InitializeComponent();
			//set database instance.
			database_ = database;
			
			this.DataContext = new PlayerInfo();
		}
		
		//insert button event
		public void insertData_Click(object sender, RoutedEventArgs e)
		{
			if(playerIDBox.Text == "0" || lastNameBox.Text == "" || firstNameBox.Text == "" || addressBox.Text == "")
			{
				MessageBox.Show("Please fill up all boxes and randomize your Player ID, thank you!","Error");
			return;
			}
			if(database_ != null){
				//pass the databinding object in order to insert our input data from this window.
				var student_info = DataContext as PlayerInfo;
				student_info.Player_id = Convert.ToInt32(playerIDBox.Text);
				var list1 = database_.view_data();
				foreach(var PlayerInfo in list1)
				{
					if (student_info.Username == PlayerInfo.Username)
					{
						MessageBox.Show("Sorry, that username has already been taken, please change it and try again!", "Try Again");
						return;
					}
				}
				database_.insert_data(student_info);
				MessageBox.Show("Successfully added new player, welcome to the game!","Success!");
				MessageBox.Show("Please memorize your player ID, you will need this to login\nPlayer ID: "+student_info.Player_id);
				Close();
			}
		}
		
		//update button event
		public void updateData_Click(object sender, RoutedEventArgs e)
		{
			
			if(database_ != null){
				//pass the databinding object in order to update our input data from this window.
				var student_info = DataContext as PlayerInfo;
				database_.update_data(student_info);
				Close();
			}
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			
			Random randid = new Random();
			randomID = randid.Next(111111, 999999);
			playerIDBox.Text = randomID.ToString();
		}
	}
}