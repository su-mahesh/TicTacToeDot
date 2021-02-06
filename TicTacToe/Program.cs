using System;

namespace TicTacToe
{
    class TicTacToe
    {
		private const int boardSize = 10;
		private char computerLetter = ' ';
		private char palyerLetter = ' ';
		private char[] board = new char[boardSize];

		TicTacToe()
		{
			for (int i = 0; i < boardSize; i++)
				board[i] = ' ';
            Console.WriteLine("**Game started**");
		}
		public void ShowBoard()
		{
			int charIndex = 1;

            Console.WriteLine("");
			for (int i = 1; i <= 3; i++)
			{
				for (int j = 1; j <= 3; j++)
				{
                    Console.Write(" " + board[charIndex] + " ");
					charIndex++;
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
