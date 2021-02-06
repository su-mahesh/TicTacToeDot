using System;

namespace TicTacToe
{
	class TicTacToe
	{
		private const int BoardSize = 10;
		private char[] Board = new char[BoardSize];
		private char PlayerLetter;
		private char ComputerLetter;

		//initialise board
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

		//choose playing letter X or O
		private void ChooseLetter()
		{
			Console.WriteLine("enter your letter (X or O):");
			PlayerLetter = Console.ReadLine().ToUpper()[0];
			ComputerLetter = PlayerLetter == 'X' ? 'O' : 'X';
		}

		//make move on board on desired index
		public void MakeMove() {

            Console.WriteLine("enter your index bewtween 1-9:");
            int InputIndex = Convert.ToInt32(Console.ReadLine());
			if (InputIndex > 0 && InputIndex < 10)
			{
				if (Board[InputIndex] == ' ')
					Board[InputIndex] = PlayerLetter;
				else
					Console.WriteLine("Index is not empty");
			}
			else
				Console.WriteLine("wrong index");
		}
		static void Main(string[] args)
		{
			Console.WriteLine("TicTacToe");
			//Initialise game
			TicTacToe TicTacToeGame = new TicTacToe();

			//choose letter
			TicTacToeGame.ChooseLetter();

			//show blank board
			TicTacToeGame.ShowBoard();

			//make move
			TicTacToeGame.MakeMove();

			TicTacToeGame.ShowBoard();
		}
	}
}