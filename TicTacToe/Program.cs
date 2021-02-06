using System;

namespace TicTacToe
{
	class TicTacToe
	{
		private const int BoardSize = 10;
		private char ComputerLetter = ' ';
		private char PlayerLetter = ' ';
		private char[] Board = new char[BoardSize];

		TicTacToe()
		{
			for (int i = 0; i < BoardSize; i++)
				Board[i] = ' ';
			Console.WriteLine("**Game started**");
		}
		public void ShowBoard()
		{
			int BoardIndex = 1;

			Console.WriteLine("");
			for (int i = 1; i <= 3; i++)
			{
				for (int j = 1; j <= 3; j++)
				{
					Console.Write(" " + Board[BoardIndex] + " ");
					BoardIndex++;
					if (j != 3)
						Console.Write("|");
				}
				Console.WriteLine("");

				for (int j = 1; j <= 11 && i != 3; j++)
					Console.Write("-");

				Console.WriteLine("");
			}
			Console.WriteLine("");
		}

		static void Main(string[] args)
		{
			Console.WriteLine("TicTacToe");

			TicTacToe TicTacToeGame = new TicTacToe();
			TicTacToeGame.ShowBoard();


		}
	}
}