/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 10/16/2018
 * Time: 03:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Bookworm_Test
{
	/// <summary>
	/// Description of PlayerInfo.
	/// </summary>
	public class PlayerInfo
	{
		
		public PlayerInfo(){}
		
		public int Player_id{ get; set; }
		public string Last_name{ get; set; }
		public string First_name{ get; set; }
		public string Username{ get; set; }
		public int High_score{get; set;}
		public int Highest_level{ get; set; }
		public int Last_level {get; set; }
		public int Last_score {get; set;}
		public int Music{get; set;}
		public int Games_played{get; set;}
	};
	
}
