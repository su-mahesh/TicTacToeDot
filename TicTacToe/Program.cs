using System;
using System.Collections.Generic;

namespace TicTacToe
{
	class TicTacToe
	{
		private const int BoardSize = 10;
		private char[] Board = new char[BoardSize];
		private char UserLetter;
		private char ComputerLetter;
		private char CurrentPlayerLetter;
		private char IdlePlayerLetter;
		List<int> EmptyCells = new List<int>(); 

		private enum Players { 
		USER, COMPUTER
		}

		private Players CurrentPlayer;
		private Players IdlePlayer;

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
        {	bool flag = false;
			EmptyCells.Clear();
			for (int i = 1; i < BoardSize; i++)
				if (Board[i] == ' ')
                {					
					EmptyCells.Add(i);
					flag = true;
				}
			return flag;
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
                Console.WriteLine("you won the toss");
				CurrentPlayerLetter = UserLetter;
				IdlePlayerLetter = ComputerLetter;
				CurrentPlayer = Players.USER;
				IdlePlayer = Players.COMPUTER;
			}
			else
            {
                Console.WriteLine("computer won the toss");
				CurrentPlayerLetter = ComputerLetter;
				IdlePlayerLetter = UserLetter;
				CurrentPlayer = Players.COMPUTER;
				IdlePlayer = Players.USER;
			}
		}

		bool CheckGameStatus() {
			if (CheckRowWise(CurrentPlayerLetter) || CheckColumnWise(CurrentPlayerLetter) || CheckDiagonalWise(CurrentPlayerLetter))
            {
				Console.WriteLine("Player " + CurrentPlayer + " won\n Game Over");
				return false;
			}
				
			else if (!CheckFreeSpace())
            {
				Console.WriteLine("no free space left match drawn\nGame Over");
				return false;
			}
				
			else
				ChangePlayer();
			return true;
		}

        private void ChangePlayer()
        {
			Players player = CurrentPlayer;
			CurrentPlayer = IdlePlayer;
			IdlePlayer = player;

			char Letter = CurrentPlayerLetter;
			CurrentPlayerLetter = IdlePlayerLetter;
			IdlePlayerLetter = Letter;					
		}

        private bool CheckRowWise(char CheckLetter)
        {
			if (Board[1] == CheckLetter && Board[2] == CheckLetter && Board[3] == CheckLetter)
				return true;
			if (Board[4] == CheckLetter && Board[5] == CheckLetter && Board[6] == CheckLetter)
				return true;
			if (Board[7] == CheckLetter && Board[8] == CheckLetter && Board[9] == CheckLetter)
				return true;
			return false;
		}
		private bool CheckColumnWise(char CheckLetter)
		{
			if (Board[1] == CheckLetter && Board[4] == CheckLetter && Board[7] == CheckLetter)
				return true;
			if (Board[2] == CheckLetter && Board[5] == CheckLetter && Board[8] == CheckLetter)
				return true;
			if (Board[3] == CheckLetter && Board[6] == CheckLetter && Board[9] == CheckLetter)
				return true;
			return false;
		}
		private bool CheckDiagonalWise(char CheckLetter)
		{
			if (Board[1] == CheckLetter && Board[5] == CheckLetter && Board[9] == CheckLetter)
				return true;
			if (Board[3] == CheckLetter && Board[5] == CheckLetter && Board[7] == CheckLetter)
				return true;
			return false;
		}

		private void PlayUntilGameOver()
		{
			if (CurrentPlayer == Players.USER)
				MakeMove();
			else
				ComputerMove();
			ShowBoard();
            while (CheckGameStatus())
            {
				switch (CurrentPlayer)
                {
					case Players.USER:
						MakeMove();
						break;
					case Players.COMPUTER:
						ComputerMove();
						break;
                }
			ShowBoard();
			}
		}

		private void ComputerMove()
		{
			if (CheckIfWinsOrBlock(ComputerLetter) || CheckIfWinsOrBlock(UserLetter) || TakeAvailableCorner() || TakeCenterIfAvailable() || TakeAvailableSide())
			{
				Console.WriteLine("computers move drawn");
			}			
        }

        private bool TakeAvailableSide()
        {
			if (Board[2] == ' ')
			{
				Board[2] = ComputerLetter;
				return true;
			}
			else if (Board[6] == ' ')
			{
				Board[6] = ComputerLetter;
				return true;
			}
			else if (Board[8] == ' ')
			{
				Board[8] = ComputerLetter;
				return true;
			}
			else if (Board[4] == ' ')
			{
				Board[4] = ComputerLetter;
				return true;
			}
			return false;
		}

        private bool TakeCenterIfAvailable()
        {
            if(Board[5] == ' ')
            {
				Board[5] = ComputerLetter;
				return true;
			}
			return false;				
        }

        private bool TakeAvailableCorner()
        {
			if (Board[1] == ' ')
			{
				Board[1] = ComputerLetter;
				return true;
			}
			else if (Board[3] == ' ')
			{
				Board[3] = ComputerLetter;
				return true;
			}
			else if (Board[7] == ' ')
			{
				Board[7] = ComputerLetter;
				return true;
			}
			else if (Board[9] == ' ')
			{
				Board[9] = ComputerLetter;
				return true;
			}

			return false;
        }

        private bool CheckIfWinsOrBlock(char CheckLetter)
        {
			foreach(int EmptyCell in EmptyCells)
            {
                switch (EmptyCell)
                {
					case 1:
						if ((Board[2] == CheckLetter && Board[3] == CheckLetter) || (Board[4] == CheckLetter && Board[7] == CheckLetter)
							|| (Board[5] == CheckLetter && Board[9] == CheckLetter))
                        {
							Board[1] = ComputerLetter;
							return true;
						}							
						break;
					case 2:
						if ((Board[1] == CheckLetter && Board[3] == CheckLetter) || (Board[5] == CheckLetter && Board[8] == CheckLetter))
						{
							Board[2] = ComputerLetter;
							return true;
						}
						break;
					case 3:
						if ((Board[1] == CheckLetter && Board[2] == CheckLetter) || (Board[6] == CheckLetter && Board[9] == CheckLetter)
							|| (Board[5] == CheckLetter && Board[7] == CheckLetter))
						{
							Board[3] = ComputerLetter;
							return true;
						}
						break;
					case 4:
						if ((Board[1] == CheckLetter && Board[7] == CheckLetter) || (Board[5] == CheckLetter && Board[6] == CheckLetter))
						{
							Board[4] = ComputerLetter;
							return true;
						}
						break;
					case 5:
						if ((Board[2] == CheckLetter && Board[8] == CheckLetter) || (Board[4] == CheckLetter && Board[6] == CheckLetter)
							|| (Board[1] == CheckLetter && Board[9] == CheckLetter) || (Board[7] == CheckLetter && Board[3] == CheckLetter))
						{
							Board[5] = ComputerLetter;
							return true;
						}
						break;
					case 6:
						if ((Board[3] == CheckLetter && Board[9] == CheckLetter) || (Board[4] == CheckLetter && Board[5] == CheckLetter))
						{
							Board[6] = ComputerLetter;
							return true;
						}
						break;
					case 7:
						if ((Board[1] == CheckLetter && Board[4] == CheckLetter) || (Board[8] == CheckLetter && Board[9] == CheckLetter)
							|| (Board[5] == CheckLetter && Board[3] == CheckLetter))
						{
							Board[7] = ComputerLetter;
							return true;
						}
						break;
					case 8:
						if ((Board[2] == CheckLetter && Board[5] == CheckLetter) || (Board[7] == CheckLetter && Board[9] == CheckLetter))
						{
							Board[8] = ComputerLetter;
							return true;
						}
						break;
					case 9:
						if ((Board[3] == CheckLetter && Board[6] == CheckLetter) || (Board[7] == CheckLetter && Board[8] == CheckLetter)
							|| (Board[1] == CheckLetter && Board[5] == CheckLetter))
						{
							Board[9] = ComputerLetter;
							return true;
						}
						break;
				}				
            }
			return false;
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

			TicTacToeGame.PlayUntilGameOver();
		}      
    }
}