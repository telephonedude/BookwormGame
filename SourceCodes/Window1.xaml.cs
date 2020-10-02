/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 14/10/2018
 * Time: 3:44 PM
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
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Bookworm_Test
{
	
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		
		private SQLDatabase database_;
		private MediaPlayer mediaPlayer = new MediaPlayer();
		public class Unit
		{
			public int indexnum {get; set;}
			public string zero0 {get; set;}
			public string zero1 {get; set;}
			public string zero2 {get; set;}
			public string zero3 {get; set;}
			public string zero4 {get; set;}
			
			public string one0 {get; set;}
			public string one1 {get; set;}
			public string one2 {get; set;}
			public string one3 {get; set;}
			public string one4 {get; set;}
			
			public string two0 {get; set;}
			public string two1 {get; set;}
			public string two2 {get; set;}
			public string two3 {get; set;}
			public string two4 {get; set;}
			
			public string three0 {get; set;}
			public string three1 {get; set;}
			public string three2 {get; set;}
			public string three3 {get; set;}
			public string three4 {get; set;}
		
			public string four0 {get; set;}
			public string four1 {get; set;}
			public string four2 {get; set;}
			public string four3 {get; set;}
			public string four4 {get; set;}
			
			public string correctWord1 {get; set;}
			public string correctWord2 {get; set;}
			public string correctWord3 {get; set;}
			public string correctWord4 {get; set;}
			public string correctWord5 {get; set;}
			public string correctWord6 {get; set;}
			public string correctWord7 {get; set;}
		}
		public int about_index;
		public string current_player_name;
		public int current_music;
		public int current_player_id;
		public int score;
		public int level=1;
		public int randomID;
		public int reqwin;
		public int wins=0;
		public int randomnum;
		public string Word;
		public int correctanswer;
		List<Unit> word_list_;
		List<Unit> selected_list_;
		public Window1()
		{
			InitializeComponent();
			database_ = new SQLDatabase();
			database_.create_database("player_database554");
			database_.connect_database();
			database_.create_table();
			guessbox.Text = Word;
			scoreblock.Text = score.ToString();
			levelblock.Text = level.ToString();
			selected_list_ = new List<Unit>();
			word_list_ = new List<Unit>()
			{
				
new Unit() {indexnum = 0, zero0 = "S", zero1 = "A", zero2 = "L", zero3 = "E", zero4 = "L", one0 = "C", one1 = "A", one2 = "T", one3 = "O", one4 = "A", two0 = "A", two1 = "Q", two2 = "I",  two3 = "S",  two4 = "D", three0 = "R", three1 = "O", three2 = "W", three3 = "H", three4 = "Y", four0 = "F", four1 = "M", four2 = "I", four3 = "L", four4 = "K", correctWord1 = "SALE", correctWord2= "SCARF", correctWord3 = "LADY", correctWord4 = "CAT", correctWord5="ROW", correctWord6="MILK", correctWord7 = "LAD"},
new Unit() {indexnum = 1, zero0 = "H", zero1 = "U", zero2 = "N", zero3 = "T", zero4 = "T", one0 = "I", one1 = "K", one2 = "I", one3 = "T", one4 = "E", two0 = "L", two1 = "T", two2 = "A",  two3 = "M",  two4 = "E",  three0 = "L", three1 = "O", three2 = "V", three3 = "E", three4 = "T", four0 = "S", four1 = "T", four2 = "E", four3 = "A", four4 = "L", correctWord1 = "HUNT", correctWord2= "KITE", correctWord3 = "HILLS", correctWord4 = "LOVE", correctWord5="TEST", correctWord6="STEAL", correctWord7 = "TAME"},

new Unit() {indexnum = 2, zero0 = "F", zero1 = "A", zero2 = "N", zero3 = "C", zero4 = "Y", one0 = "I", one1 = "L", one2 = "L", one3 = "X", one4 = "Q", two0 = "T", two1 = "O", two2 = "A",  two3 = "S",  two4 = "T", three0 = "C", three1 = "L", three2 = "A", three3 = "S", three4 = "H", four0 = "S", four1 = "D", four2 = "T", four3 = "A", four4 = "P", correctWord1 = "FANCY", correctWord2= "ILL", correctWord3 = "FIT", correctWord4 = "TOAST", correctWord5="CLASH", correctWord6="TAP"},
new Unit() {indexnum = 3, zero0 = "F", zero1 = "O", zero2 = "O", zero3 = "L", zero4 = "F", one0 = "H", one1 = "E", one2 = "L", one3 = "P", one4 = "A", two0 = "V", two1 = "I", two2 = "N",  two3 = "E",  two4 = "I",  three0 = "E", three1 = "N", three2 = "T", three3 = "E", three4 = "R", four0 = "B", four1 = "S", four2 = "I", four3 = "D", four4 = "E", correctWord1 = "FOOL", correctWord2= "FIVE", correctWord3 = "FAIR", correctWord4 = "VINE", correctWord5="ENTER", correctWord6="SIDE", correctWord7 = "HELP"},

			
new Unit() {indexnum = 4, zero0 = "A", zero1 = "C", zero2 = "O", zero3 = "O", zero4 = "L", one0 = "K", one1 = "C", one2 = "U", one3 = "Z", one4 = "A", two0 = "I", two1 = "G", two2 = "T",  two3 = "H",  two4 = "W", three0 = "S", three1 = "T", three2 = "R", three3 = "A", three4 = "W", four0 = "S", four1 = "M", four2 = "I", four3 = "L", four4 = "E", correctWord1 = "COOL", correctWord2= "LAW", correctWord3 = "OUT", correctWord4 = "KISS", correctWord5="STRAW", correctWord6="SMILE", correctWord7 = "RAW"},
new Unit() {indexnum = 5, zero0 = "C", zero1 = "O", zero2 = "U", zero3 = "N", zero4 = "T", one0 = "R", one1 = "Z", one2 = "H", one3 = "F", one4 = "A", two0 = "O", two1 = "N", two2 = "E",  two3 = "L",  two4 = "L",  three0 = "S", three1 = "I", three2 = "G", three3 = "N", three4 = "K", four0 = "S", four1 = "A", four2 = "I", four3 = "L", four4 = "Q", correctWord1 = "COUNT", correctWord2= "CROSS", correctWord3 = "ONE", correctWord4 = "SIGN", correctWord5="TALK", correctWord6="SAIL"},


new Unit() {indexnum = 6, zero0 = "B", zero1 = "O", zero2 = "A", zero3 = "T", zero4 = "H", one0 = "J", one1 = "U", one2 = "M", one3 = "P", one4 = "C", two0 = "T", two1 = "A", two2 = "L",  two3 = "K",  two4 = "A", three0 = "A", three1 = "W", three2 = "A", three3 = "R", three4 = "N", four0 = "T", four1 = "R", four2 = "A", four3 = "I", four4 = "N", correctWord1 = "BOAT", correctWord2= "BAT", correctWord3 = "TALK", correctWord4 = "WARN", correctWord5="CAN", correctWord6="TRAIN", correctWord7="JUMP"},
new Unit() {indexnum = 7, zero0 = "S", zero1 = "E", zero2 = "T", zero3 = "H", zero4 = "M", one0 = "C", one1 = "O", one2 = "R", one3 = "E", one4 = "E", two0 = "I", two1 = "B", two2 = "E",  two3 = "T",  two4 = "E",  three0 = "D", three1 = "O", three2 = "O", three3 = "R", three4 = "T", four0 = "T", four1 = "R", four2 = "E", four3 = "E", four4 = "O", correctWord1 = "SET", correctWord2= "CORE", correctWord3 = "MEET", correctWord4 = "BET", correctWord5="DOOR", correctWord6="TREE"}

			};
			newboard();
			ViewBtn_Click(null, null);
		}
		
		private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "C:/Users/telephonedude/Desktop/Bookworm Test_BACKUP - Copy - Copy/Songs/The - Witcher.mp3";
			mediaPlayer.Open(new Uri(openFileDialog.FileName));
			mediaPlayer.Play();
		}

		void submit_Click(object sender, RoutedEventArgs e)
		{
			if(guessbox.Text == "")
			{
				MessageBox.Show("Please input something first, thank you!","No input");
				return;
			}
			foreach(Unit Unit in word_list_)
			{
				if(level == 31)
				{
					MessageBox.Show("YOU WON!! CONGRATULATIONS!","Congratulations");
					GameControl.SelectedIndex = 1;
					return;
				}
				if(Word == Unit.correctWord1 || Word == Unit.correctWord2 || Word == Unit.correctWord3 || Word == Unit.correctWord4 || Word == Unit.correctWord5 || Word == Unit.correctWord6 || Word == Unit.correctWord7)
				{
					score= score+100;
					wins++;
					MessageBox.Show("Correct!!", "Correct Answer!");
					correctanswer++;
					Word = "";
					correct();
					updateguessbox();
					resetboard();
					if(wins == reqwin)
					{
						MessageBox.Show("You won the level! You advance to the next level.","Next Level!");
						level++;
						wins=0;
						updateguessbox();
						newboard();
					}
					return;
				}
			}
			MessageBox.Show("Sorry, that isn't an acceptable word, try again!!","Wrong Answer!");
			Word = "";
			updateguessbox();
			resetboard();
		}
		void zerozero_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			zerozero.IsEnabled=true;
			zeroone.IsEnabled=true;
			onezero.IsEnabled=true;
			Word = Word + zerozero.Content;
			updateguessbox();
		}
		void zeroone_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			zerozero.IsEnabled=true;
			zeroone.IsEnabled=true;
			zerotwo.IsEnabled = true;
			oneone.IsEnabled = true;
			Word = Word + zeroone.Content;
			updateguessbox();
		}
		void zerotwo_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			zerotwo.IsEnabled = true;
			zerothree.IsEnabled = true;
			zeroone.IsEnabled = true;
			onetwo.IsEnabled = true;
			Word = Word + zerotwo.Content;
			updateguessbox();
		}
		void zerothree_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			zerothree.IsEnabled = true;
			zerotwo.IsEnabled = true;
			zerofour.IsEnabled = true;
			onethree.IsEnabled = true;
			Word = Word + zerothree.Content;
			updateguessbox();
		}
		void zerofour_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			zerofour.IsEnabled = true;
			zerothree.IsEnabled = true;
			onefour.IsEnabled = true;
			Word = Word + zerofour.Content;
			updateguessbox();
		}
		void onezero_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			onezero.IsEnabled = true;
			zerozero.IsEnabled = true;
			twozero.IsEnabled = true;
			oneone.IsEnabled = true;
			Word = Word + onezero.Content;
			updateguessbox();
		}
		void oneone_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			onezero.IsEnabled = true;
			oneone.IsEnabled = true;
			zeroone.IsEnabled = true;
			onetwo.IsEnabled =true;
			twoone.IsEnabled = true;
			Word = Word + oneone.Content;
			updateguessbox();
		}
		void onetwo_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			oneone.IsEnabled =true;
			onetwo.IsEnabled = true;
			onethree.IsEnabled = true;
			zerotwo.IsEnabled = true;
			twotwo.IsEnabled = true;
			Word = Word + onetwo.Content;
			updateguessbox();
		}
		void onethree_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			onethree.IsEnabled = true;
			onetwo.IsEnabled = true;
			onefour.IsEnabled=true;
			zerothree.IsEnabled= true;
			twothree.IsEnabled= true;
			Word = Word + onethree.Content;
			updateguessbox();
		}
		void onefour_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			onethree.IsEnabled = true;
			zerofour.IsEnabled = true;
			onefour.IsEnabled = true;
			twofour.IsEnabled = true;
			Word = Word + onefour.Content;
			updateguessbox();
		}
		void twozero_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			twozero.IsEnabled = true;
			onezero.IsEnabled = true;
			threezero.IsEnabled = true;
			twoone.IsEnabled = true;
			Word = Word + twozero.Content;
			updateguessbox();
		}
		void twoone_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			twozero.IsEnabled = true;
			twoone.IsEnabled = true;
			oneone.IsEnabled = true;
			twotwo.IsEnabled =true;
			threeone.IsEnabled = true;
			Word = Word + twoone.Content;
			updateguessbox();
		}
		void twotwo_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			twoone.IsEnabled =true;
			twotwo.IsEnabled = true;
			twothree.IsEnabled = true;
			onetwo.IsEnabled = true;
			threetwo.IsEnabled = true;
			Word = Word + twotwo.Content;
			updateguessbox();
		}
		void twothree_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			twothree.IsEnabled = true;
			twotwo.IsEnabled = true;
			twofour.IsEnabled=true;
			onethree.IsEnabled= true;
			threethree.IsEnabled= true;
			Word = Word + twothree.Content;
			updateguessbox();
		}
		void twofour_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			twothree.IsEnabled = true;
			onefour.IsEnabled = true;
			twofour.IsEnabled = true;
			threefour.IsEnabled = true;
			Word = Word + twofour.Content;
			updateguessbox();
		}
		void threezero_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			threezero.IsEnabled = true;
			twozero.IsEnabled = true;
			fourzero.IsEnabled = true;
			threeone.IsEnabled = true;
			Word = Word + threezero.Content;
			updateguessbox();
		}
		void threeone_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			threezero.IsEnabled = true;
			threeone.IsEnabled = true;
			twoone.IsEnabled = true;
			threetwo.IsEnabled =true;
			fourone.IsEnabled = true;
			Word = Word + threeone.Content;
			updateguessbox();
		}
		void threetwo_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			threeone.IsEnabled =true;
			threetwo.IsEnabled = true;
			threethree.IsEnabled = true;
			twotwo.IsEnabled = true;
			fourtwo.IsEnabled = true;
			Word = Word + threetwo.Content;
			updateguessbox();
		}
		void threethree_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			threethree.IsEnabled = true;
			threetwo.IsEnabled = true;
			threefour.IsEnabled=true;
			twothree.IsEnabled= true;
			fourthree.IsEnabled= true;
			Word = Word + threethree.Content;
			updateguessbox();
		}
		void threefour_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			threethree.IsEnabled = true;
			twofour.IsEnabled = true;
			threefour.IsEnabled = true;
			fourfour.IsEnabled = true;
			Word = Word + threefour.Content;
			updateguessbox();
		}
		void fourzero_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			fourzero.IsEnabled = true;
			threezero.IsEnabled = true;
			fourone.IsEnabled = true;
			Word = Word + fourzero.Content;
			updateguessbox();
		}
		void fourone_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			fourzero.IsEnabled = true;
			fourone.IsEnabled = true;
			threeone.IsEnabled = true;
			fourtwo.IsEnabled =true;
			Word = Word + fourone.Content;
			updateguessbox();
		}
		void fourtwo_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			fourone.IsEnabled =true;
			fourtwo.IsEnabled = true;
			fourthree.IsEnabled = true;
			threetwo.IsEnabled = true;
			Word = Word + fourtwo.Content;
			updateguessbox();
		}
		void fourthree_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			fourthree.IsEnabled = true;
			fourtwo.IsEnabled = true;
			fourfour.IsEnabled=true;
			threethree.IsEnabled= true;
			Word = Word + fourthree.Content;
			updateguessbox();
		}
		void fourfour_Click(object sender, RoutedEventArgs e)
		{
			disableall();
			fourthree.IsEnabled = true;
			threefour.IsEnabled = true;
			fourfour.IsEnabled = true;
			Word = Word + fourfour.Content;
			updateguessbox();
		}
		
		void updateguessbox()
		{
			scoreblock.Text = score.ToString();
			levelblock.Text = level.ToString();
			guessbox.Text = Word;
		}
		void disableall()
		{
			zerozero.IsEnabled = false;
			zeroone.IsEnabled = false;
			zerotwo.IsEnabled = false;
			zerothree.IsEnabled = false;
			zerofour.IsEnabled = false;
			onezero.IsEnabled = false;
			oneone.IsEnabled = false;
			onetwo.IsEnabled = false;
			onethree.IsEnabled = false;
			onefour.IsEnabled = false;
			twozero.IsEnabled = false;
			twoone.IsEnabled = false;
			twotwo.IsEnabled = false;
			twothree.IsEnabled = false;
			twofour.IsEnabled = false;
			threezero.IsEnabled = false;
			threeone.IsEnabled = false;
			threetwo.IsEnabled = false;
			threethree.IsEnabled = false;
			threefour.IsEnabled = false;
			fourzero.IsEnabled = false;
			fourone.IsEnabled = false;
			fourtwo.IsEnabled = false;
			fourthree.IsEnabled = false;
			fourfour.IsEnabled = false;
		}
		void resetboard()
		{
			zerozero.IsEnabled = true;
			zeroone.IsEnabled = true;
			zerotwo.IsEnabled = true;
			zerothree.IsEnabled = true;
			zerofour.IsEnabled = true;
			onezero.IsEnabled = true;
			oneone.IsEnabled = true;
			onetwo.IsEnabled = true;
			onethree.IsEnabled = true;
			onefour.IsEnabled = true;
			twozero.IsEnabled = true;
			twoone.IsEnabled = true;
			twotwo.IsEnabled = true;
			twothree.IsEnabled = true;
			twofour.IsEnabled = true;
			threezero.IsEnabled = true;
			threeone.IsEnabled = true;
			threetwo.IsEnabled = true;
			threethree.IsEnabled = true;
			threefour.IsEnabled = true;
			fourzero.IsEnabled = true;
			fourone.IsEnabled = true;
			fourtwo.IsEnabled = true;
			fourthree.IsEnabled = true;
			fourfour.IsEnabled = true;
			
			
			zerozero.IsChecked = false;
			zeroone.IsChecked = false;
			zerotwo.IsChecked = false;
			zerothree.IsChecked = false;
			zerofour.IsChecked = false;
			onezero.IsChecked = false;
			oneone.IsChecked = false;
			onetwo.IsChecked = false;
			onethree.IsChecked = false;
			onefour.IsChecked = false;
			twozero.IsChecked = false;
			twoone.IsChecked = false;
			twotwo.IsChecked = false;
			twothree.IsChecked = false;
			twofour.IsChecked = false;
			threezero.IsChecked = false;
			threeone.IsChecked = false;
			threetwo.IsChecked = false;
			threethree.IsChecked = false;
			threefour.IsChecked = false;
			fourzero.IsChecked = false;
			fourone.IsChecked = false;
			fourtwo.IsChecked = false;
			fourthree.IsChecked = false;
			fourfour.IsChecked = false;
			
		}
		void Reset_Click(object sender, RoutedEventArgs e)
		{
			Word = "";
			updateguessbox();
			resetboard();
		}
		void newboard()
		{
			foreach(Unit Unit in word_list_)
			{
			Random rnd = new Random();
			randomnum = rnd.Next(8);
				if(randomnum == Unit.indexnum)
				{
					zerozero.Content = Unit.zero0;
					zeroone.Content = Unit.zero1;
					zerothree.Content = Unit.zero3;
					zerotwo.Content = Unit.zero2;
					zerofour.Content = Unit.zero4;
					
					onezero.Content = Unit.one0;
					oneone.Content = Unit.one1;
					onetwo.Content = Unit.one2;
					onethree.Content = Unit.one3;
					onefour.Content = Unit.one4;
					
					twozero.Content = Unit.two0;
					twothree.Content = Unit.two3;
					twoone.Content = Unit.two1;
					twotwo.Content = Unit.two2;
					twofour.Content = Unit.two4;
					
					threezero.Content = Unit.three0;
					threetwo.Content = Unit.three2;
					threeone.Content = Unit.three1;
					threethree.Content = Unit.three3;
					threefour.Content = Unit.three4;
					
					fourzero.Content = Unit.four0;
					fourtwo.Content = Unit.four2;
					fourone.Content = Unit.four1;
					fourthree.Content = Unit.four3;
					fourfour.Content = Unit.four4;
					
			Show_board();
				}
			}
		}
		
		void correct()
		{
			if(zerozero.IsChecked == true )
			{
				zerozero.Visibility = Visibility.Hidden;
			}
			if(zeroone.IsChecked == true )
			{
				zeroone.Visibility = Visibility.Hidden;
			}
			if(zerotwo.IsChecked == true )
			{
				zerotwo.Visibility = Visibility.Hidden;
			}
			if(zerothree.IsChecked == true )
			{
				zerothree.Visibility = Visibility.Hidden;
			}
			if(zerofour.IsChecked == true )
			{
				zerofour.Visibility = Visibility.Hidden;
			}
			if(onezero.IsChecked == true )
			{
				onezero.Visibility = Visibility.Hidden;
			}
			if(oneone.IsChecked == true )
			{
				oneone.Visibility = Visibility.Hidden;
			}
			if(onetwo.IsChecked == true )
			{
				onetwo.Visibility = Visibility.Hidden;
			}
			if(onethree.IsChecked == true )
			{
				onethree.Visibility = Visibility.Hidden;
			}
			if(onefour.IsChecked == true )
			{
				onefour.Visibility = Visibility.Hidden;
			}
			if(twozero.IsChecked == true )
			{
				twozero.Visibility = Visibility.Hidden;
			}
			if(twoone.IsChecked == true )
			{
				twoone.Visibility = Visibility.Hidden;
			}
			if(twotwo.IsChecked == true )
			{
				twotwo.Visibility = Visibility.Hidden;
			}
			if(twothree.IsChecked == true )
			{
				twothree.Visibility = Visibility.Hidden;
			}
			if(twofour.IsChecked == true )
			{
				twofour.Visibility = Visibility.Hidden;
			}
			if(threezero.IsChecked == true )
			{
				threezero.Visibility = Visibility.Hidden;
			}
			if(threeone.IsChecked == true )
			{
				threeone.Visibility = Visibility.Hidden;
			}
			if(threetwo.IsChecked == true )
			{
				threetwo.Visibility = Visibility.Hidden;
			}
			if(threethree.IsChecked == true )
			{
				threethree.Visibility = Visibility.Hidden;
			}
			if(threefour.IsChecked == true )
			{
				threefour.Visibility = Visibility.Hidden;
			}
			if(fourzero.IsChecked == true )
			{
				fourzero.Visibility = Visibility.Hidden;
			}
			if(fourone.IsChecked == true )
			{
				fourone.Visibility = Visibility.Hidden;
			}
			if(fourtwo.IsChecked == true )
			{
				fourtwo.Visibility = Visibility.Hidden;
			}
			if(fourthree.IsChecked == true )
			{
				fourthree.Visibility = Visibility.Hidden;
			}
			if(fourfour.IsChecked == true)	
			{
				fourfour.Visibility = Visibility.Hidden;
			}
		}
		
		
		void Show_board()
		{
				zerozero.Visibility = Visibility.Visible;
				zeroone.Visibility = Visibility.Visible;
				zerotwo.Visibility = Visibility.Visible;
				zerothree.Visibility = Visibility.Visible;
				zerofour.Visibility = Visibility.Visible;
				onezero.Visibility = Visibility.Visible;
				oneone.Visibility = Visibility.Visible;
				onetwo.Visibility = Visibility.Visible;
				onethree.Visibility = Visibility.Visible;
				onefour.Visibility = Visibility.Visible;
				twozero.Visibility = Visibility.Visible;
				twoone.Visibility = Visibility.Visible;
				twotwo.Visibility = Visibility.Visible;
				twothree.Visibility = Visibility.Visible;
				twofour.Visibility = Visibility.Visible;
				threezero.Visibility = Visibility.Visible;
				threeone.Visibility = Visibility.Visible;
				threetwo.Visibility = Visibility.Visible;
				threethree.Visibility = Visibility.Visible;
				threefour.Visibility = Visibility.Visible;
				fourzero.Visibility = Visibility.Visible;
				fourone.Visibility = Visibility.Visible;
				fourtwo.Visibility = Visibility.Visible;
				fourthree.Visibility = Visibility.Visible;
				fourfour.Visibility = Visibility.Visible;
			
		}
		//sql stuff
		void InsertBtn_Click(object sender, RoutedEventArgs e)
		{
			//create student_window and pass the database instance.
			var student_window = new PlayerForm(database_);
			
			//setup button parameters and event.
			student_window.editBtn.Content = "Create New Player Data";
			student_window.editBtn.Click += student_window.insertData_Click;
			student_window.ShowDialog();
			
			//this will display the data.
			ViewBtn_Click(null, null);
		}
		
		void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
			//get the list of the data from the database.
			var student_info_list = database_.view_data();
			if(student_info_list != null){
				//set the itemsource to view the data in the list.
				StudentRecord_dataGrid.ItemsSource = student_info_list;
			}
			
			//refresh the datagrid view.
			StudentRecord_dataGrid.Items.Refresh();
		}
		void UpdateBtn_Click(object sender, RoutedEventArgs e)
		{
			//get the selected item from the datagrid.
			var selected_info = StudentRecord_dataGrid.SelectedItem as PlayerInfo;
			
			if(current_player_id != selected_info.Player_id)
			{
				MessageBox.Show("Sorry, you can only change your current account's information!","Error");
				return;
			}
			if(selected_info != null){
				
				//create student_window and pass the database instance.
				var student_window = new PlayerForm(database_);
			
				//set the datacontext of the selected info.
				student_window.DataContext = selected_info;
				
				//setup button parameters and event.
				student_window.button1.Opacity = 0;
				student_window.button1.IsEnabled = false;
				student_window.editBtn.Content = "Update Player Data";
				student_window.editBtn.Click += student_window.updateData_Click;
				student_window.ShowDialog();
				
				//this will display the data.
				ViewBtn_Click(null, null);
			}	
		}
		void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			//get the selected item from the datagrid.
			var selected_info = StudentRecord_dataGrid.SelectedItem as PlayerInfo;
			if(current_player_id != selected_info.Player_id)
			{
				MessageBox.Show("Sorry, you can only delete your current account, thank you!","Error");
				GameControl.SelectedIndex = 0;
				return;
			}
			if(selected_info != null){
				
				//get the selected student id.
				var student_id = selected_info.Player_id;
				
				MessageBoxResult result;
				result = MessageBox.Show("Are you sure you want to delete Student ID: "+ student_id + "?",
			                 "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
				
				//if user selected yes, then delete the record.
				if (result == MessageBoxResult.Yes){
					var is_delete = database_.delete_data(student_id);
					if(is_delete == true){
						MessageBox.Show("Delete Record is successful! ");
					}
				}
				
				//this will display the data.
				ViewBtn_Click(null, null);
			}
		}
		void newgame_btn_Click(object sender, RoutedEventArgs e)
		{
			show_difficulty_button();
			var list1 = database_.view_data();
				foreach(var PlayerInfo in list1)
				{
					if(current_player_id == PlayerInfo.Player_id)
					{
						PlayerInfo.Games_played ++;
						
						database_.update_data(PlayerInfo);
						var list12 = database_.view_data();
						ViewBtn_Click(null, null);
					}
				}
			nameblock.Text = current_player_name;
			wins = 0;
			level = 1;
			score = 0;
			updateguessbox();
		}
		void contgame_btn_Click(object sender, RoutedEventArgs e)
		{
			show_difficulty_button();
			nameblock.Text = current_player_name;
			var list1 = database_.view_data();
				foreach(var PlayerInfo in list1)
				{
					if(current_player_id == PlayerInfo.Player_id)
				{
					if(PlayerInfo.Last_level == 0)
					{
						MessageBox.Show("Sorry, you have no saved games, please create a new game first, thanks!", "No Saved Games");
						return;
					}
					level = PlayerInfo.Last_level;
					score = PlayerInfo.Last_score;
					updateguessbox();
				}
				}
		}
		void settings_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex = 4;
		}
		void stats_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex=3;
		}
		void mechanics_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex = 5;
		}
		void about_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex = 6;
		}
		
		
		void login_btn_Click(object sender, RoutedEventArgs e)
		{
				var list1 = database_.view_data();
				foreach(var PlayerInfo in list1)
				{
					if (namebox.Text == PlayerInfo.Player_id.ToString())
					{
						btnOpenAudioFile_Click(null, null);
						current_player_id = PlayerInfo.Player_id;
						current_player_name = PlayerInfo.Username;
						current_music = PlayerInfo.Music;
						if(current_music == 0)
						{
							music_on_Click(null,null);
						}
						if(current_music == 1)
						{
							music_off_Click(null,null);
						}
						MessageBox.Show("Successfully Logged In!, welcome to the game "+current_player_name, "Welcome");
						GameControl.SelectedIndex=1;
						return;
					}
				}
				MessageBox.Show("Sorry, that player ID does not exist, if you do not have account, please sign up, thank you!","No Player ID");
		}
		void logout_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex=0;
		}
		void quit_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex = 1;
			update_current_stats();
		}
		void update_current_stats()
		{
			var list123 = database_.view_data();
			foreach(var PlayerInfo in list123)
			{
				if(current_player_id == PlayerInfo.Player_id)
				{
					if(score > PlayerInfo.High_score)
					{
					PlayerInfo.High_score = score;
					}
					if(level > PlayerInfo.Highest_level)
					{
					PlayerInfo.Highest_level = level;
					}
					PlayerInfo.Last_level = level;
					PlayerInfo.Last_score = score;
				database_.update_data(PlayerInfo);
				var list1 = database_.view_data();
				ViewBtn_Click(null, null);
				}
			}
		}
		void easy_btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("You will need to find 3 words per level to advance to the next level, good luck!","Good Luck");
			reqwin = 3;
			GameControl.SelectedIndex=2;
			newboard();
			hide_difficulty_button();
		}
		void medium_btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("You will need to find 4 words per level to advance to the next level, good luck!","Good Luck");
			reqwin = 4;
			GameControl.SelectedIndex=2;
			newboard();
			hide_difficulty_button();
		}
		void hard_btn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("You will need to find 5 words per level to advance to the next level, good luck!","Good Luck");
			reqwin = 5;
			GameControl.SelectedIndex=2;
			newboard();
			hide_difficulty_button();
		}
		void hide_difficulty_button()
		{
			easy_btn.Visibility = Visibility.Hidden;
			medium_btn.Visibility = Visibility.Hidden;
			hard_btn.Visibility = Visibility.Hidden;
		}
		void show_difficulty_button()
		{
			easy_btn.Visibility = Visibility.Visible;
			medium_btn.Visibility = Visibility.Visible;
			hard_btn.Visibility = Visibility.Visible;
		}
		void main_menu_btn_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex=1;
		}
		void about_prev_btn_Click(object sender, RoutedEventArgs e)
		{
			about_next_btn.IsEnabled = true;
			about_index--;
			if(about_index == 0)
			{
				about_prev_btn.IsEnabled = false;
			}
			show_about();
		}
		void about_next_btn_Click(object sender, RoutedEventArgs e)
		{
			about_prev_btn.IsEnabled = true;
			about_index++;
			if(about_index == 6)
			{
				about_next_btn.IsEnabled = false;
			}
			show_about();
		}
		void show_about()
		{
			if(about_index==0)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/yaboi.jpeg"));
				aboutnamebox.Content = "Aaron Brent Abundo";
			}
			if(about_index==1)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/jane.jpg"));
				aboutnamebox.Content = "Jane Arcilla";
			}
			if(about_index==2)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/jheia.jpg"));
				aboutnamebox.Content = "Jheia Codoy";
			}
			if(about_index==3)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/nikka.jpg"));
				aboutnamebox.Content = "Lucille Estocapio";
			}
			if(about_index==4)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/adi.jpg"));
				aboutnamebox.Content = "Adrian Millor";
			}
			if(about_index==5)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/jopet.jpg"));
				aboutnamebox.Content = "Jopet Louie Montero";
			}
			if(about_index==6)
			{
				aboutimage.Source = new BitmapImage(new Uri("pack://application:,,,/Bookworm Test;component/Pictures/hazel.jpg"));
				aboutnamebox.Content = "Hazel Papas";
			}
		}
		void music_on_Click(object sender, RoutedEventArgs e)
		{
			var list123 = database_.view_data();
			foreach(var PlayerInfo in list123)
			{
				if(current_player_id == PlayerInfo.Player_id)
				{
				PlayerInfo.Music = 0;
				database_.update_data(PlayerInfo);
				var list1 = database_.view_data();
				ViewBtn_Click(null, null);
				}
			}
			mediaPlayer.Play();
			music_on.IsEnabled = false;
			music_off.IsEnabled = true;
		}
		void music_off_Click(object sender, RoutedEventArgs e)
		{
			var list123 = database_.view_data();
			foreach(var PlayerInfo in list123)
			{
				if(current_player_id == PlayerInfo.Player_id)
				{
				PlayerInfo.Music = 1;
				database_.update_data(PlayerInfo);
				var list1 = database_.view_data();
				ViewBtn_Click(null, null);
				}
			}
			mediaPlayer.Pause();
			music_off.IsEnabled = false;
			music_on.IsEnabled = true;
		}
		void reset_stats_Click(object sender, RoutedEventArgs e)
		{
			var list123 = database_.view_data();
			foreach(var PlayerInfo in list123)
			{
				if(current_player_id == PlayerInfo.Player_id)
				{
					PlayerInfo.High_score = 0;
					PlayerInfo.Highest_level = 0;
					PlayerInfo.Last_level = 0;
					PlayerInfo.Last_score = 0;
					PlayerInfo.Music = 0;
				database_.update_data(PlayerInfo);
				var list1 = database_.view_data();
				ViewBtn_Click(null, null);
				}
			}
		}
		void reset_game_Click(object sender, RoutedEventArgs e)
		{
			GameControl.SelectedIndex = 0;
		}
		}
		
		//sql stuff
	}
