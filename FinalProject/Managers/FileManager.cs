using Fruit_Basket.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Fruit_Basket.Managers
{
	/// <summary>
	/// Used for managing the leaderboard file
	/// </summary>
	public static class FileManager
	{
		public static List<LeaderBoardInfo> LeaderBoardInfos = new List<LeaderBoardInfo>();
		private const string FILEPATH = "data/leaderboard.txt";
		
		/// <summary>
		/// Load the <see cref="LeaderBoardInfos"/> via the learderboard.txt file
		/// </summary>
		public static void LoadLeaderBoard()
		{
			LeaderBoardInfos.Clear();
			if (FileExists(FILEPATH))
			{
				foreach(string line in File.ReadAllLines(FILEPATH))
				{
					try
					{
						string[] splitLine = line.Split(';');
						LeaderBoardInfo info = new LeaderBoardInfo();
						info.Name = splitLine[0];
						info.Score = Convert.ToInt32(splitLine[1]);
						info.ScoreDate = Convert.ToDateTime(splitLine[2]);
						info.LevelName = splitLine[3];
						LeaderBoardInfos.Add(info);
					}
					catch
					{
						Debug.WriteLine("No info/ No valid info");
					}
				}
				LeaderBoardInfos = LeaderBoardInfos.OrderByDescending(info => info.Score).ThenBy(info => info.ScoreDate).ToList();
			}
			else
			{
				Directory.CreateDirectory(FILEPATH.Split("/")[0]);
				var file = File.Create(FILEPATH);
				file.Close();
			}
		}

		/// <summary>
		/// Used for saving the current <see cref="LeaderBoardInfos"/> to the leaderboard.txt file
		/// </summary>
		public static void SaveLeaderBoard()
		{
			List<LeaderBoardInfo> orderedInfo = LeaderBoardInfos.OrderByDescending(info => info.Score).ThenBy(info => info.ScoreDate).Take(5).ToList();
			string saveText = "";
			foreach(LeaderBoardInfo info in orderedInfo)
			{
				saveText += $"{info.Name};{info.Score};{info.ScoreDate};{info.LevelName}\n";
			}
			File.WriteAllText(FILEPATH, saveText);
		}

		/// <summary>
		/// Checks if the file exists
		/// </summary>
		/// <param name="path">The path where the file could exist</param>
		/// <returns>Whether the file exists or not</returns>
		private static bool FileExists(string path)
		{
			return File.Exists(path);
		}
	}
}
