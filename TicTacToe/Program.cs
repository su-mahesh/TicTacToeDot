using System;

namespace TicTacToe
{
	class TicTacToe
	{
		private const int BoardSize = 10;
		private char[] Board = new char[BoardSize];
		private char UserLetter;
		private char ComputerLetter;
		private char CurrentPlayerLetter;
 
		private enum Players { 
		USER, COMPUTER
		}

		private Players CurrentPlayer;

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
			UserLetter = Console.ReadLine().ToUpper()[0];
			ComputerLetter = UserLetter == 'X' ? 'O' : 'X';
		}

		public bool CheckFreeSpace()
        {
			for (int i = 1; i < BoardSize; i++)
				if (Board[i] == ' ')
					return true;
			return false;
		}

		//make move on board on desired index
		public void MakeMove() {
			if (CheckFreeSpace())
            {
				Console.WriteLine("enter your index bewtween 1-9:");
				int InputIndex = Convert.ToInt32(Console.ReadLine());
				if (InputIndex > 0 && InputIndex < 10)
				{
					if (Board[InputIndex] == ' ')
						Board[InputIndex] = UserLetter;
					else
						Console.WriteLine("Index is not empty");
				}
				else
					Console.WriteLine("wrong index");
			}
		}

		public void MakeToss() {
			char[] TossArray = new Char[2] { 'H', 'T' };
			Console.WriteLine("Toss");
			Console.WriteLine("choose H head or T tail");
			char PlayerToss = Console.ReadLine()[0];

			if (TossArray[new Random().Next(0, 2)] == PlayerToss)
			{
				CurrentPlayerLetter = UserLetter;
				CurrentPlayer = Players.USER;
			}
			else
			{
				CurrentPlayerLetter = ComputerLetter;
				CurrentPlayer = Players.COMPUTER;
			}
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

			TicTacToeGame.MakeToss();
			//make move
			TicTacToeGame.MakeMove();
			TicTacToeGame.ShowBoard();

			//make move
			TicTacToeGame.MakeMove();

			TicTacToeGame.ShowBoard();
		}
	}
}