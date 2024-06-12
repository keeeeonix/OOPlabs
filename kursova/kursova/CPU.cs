using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static kursova.PVP;

namespace kursova
{
    public partial class CPU : Form
    {
        public class TicTacToeGame
        {
            public char[,] Board { get; private set; }
            public char CurrentPlayer { get; private set; }
            public bool GameOver { get; private set; }

            public TicTacToeGame()
            {
                Board = new char[3, 3];
                CurrentPlayer = 'X'; 
                InitializeBoard();
            }

            private void InitializeBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Board[i, j] = ' ';
                    }
                }
                GameOver = false;
            }

            public bool MakeMove(int row, int col)
            {
                if (Board[row, col] == ' ' && !GameOver)
                {
                    Board[row, col] = CurrentPlayer;
                    if (CheckWin())
                    {
                        GameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        GameOver = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                    return true;
                }
                return false;
            }

            public void ComputerMove()
            {
                if (GameOver) return;

                int bestScore = int.MinValue;
                Tuple<int, int> bestMove = null;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Board[i, j] == ' ')
                        {
                            Board[i, j] = CurrentPlayer;
                            int score = Minimax(Board, 0, false);
                            Board[i, j] = ' ';
                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestMove = new Tuple<int, int>(i, j);
                            }
                        }
                    }
                }

                if (bestMove != null)
                {
                    MakeMove(bestMove.Item1, bestMove.Item2);
                }
            }

            private int Minimax(char[,] board, int depth, bool isMaximizing)
            {
                if (CheckWinCondition('O'))
                {
                    return -1;
                }
                else if (CheckWinCondition('X'))
                {
                    return 1;
                }
                else if (IsBoardFull())
                {
                    return 0;
                }

                if (isMaximizing)
                {
                    int bestScore = int.MinValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == ' ')
                            {
                                board[i, j] = 'X';
                                int score = Minimax(board, depth + 1, false);
                                board[i, j] = ' ';
                                bestScore = Math.Max(score, bestScore);
                            }
                        }
                    }
                    return bestScore;
                }
                else
                {
                    int bestScore = int.MaxValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == ' ')
                            {
                                board[i, j] = 'O';
                                int score = Minimax(board, depth + 1, true);
                                board[i, j] = ' ';
                                bestScore = Math.Min(score, bestScore);
                            }
                        }
                    }
                    return bestScore;
                }
            }

            public bool CheckWinCondition(char player)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player)
                    {
                        return true;
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    if (Board[0, j] == player && Board[1, j] == player && Board[2, j] == player)
                    {
                        return true;
                    }
                }
                if (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player)
                {
                    return true;
                }
                if (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player)
                {
                    return true;
                }
                return false;
            }

            private void SwitchPlayer()
            {
                CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            }

            private bool CheckWin()
            {
                return CheckWinCondition(CurrentPlayer);
            }

            private bool IsBoardFull()
            {
                foreach (var cell in Board)
                {
                    if (cell == ' ')
                    {
                        return false;
                    }
                }
                return true;
            }

            public void ResetBoard()
            {
                InitializeBoard();
                CurrentPlayer = 'X'; 
            }
        }
        private TicTacToeGame game;
        private Button[,] buttons;

        public CPU()
        {
            InitializeComponent();
            game = new TicTacToeGame();
            InitializeBoard();
            MakeComputerMove(); 
            UpdateBoard();
        }


        private void InitializeBoard()
        {
            buttons = new Button[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button
                    {
                        Width = 100,
                        Height = 100,
                        Top = i * 100,
                        Left = j * 100,
                        Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                        Tag = new Tuple<int, int>(i, j)
                    };
                    button.Click += Cell_Click;
                    buttons[i, j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            int row = position.Item1;
            int col = position.Item2;

            if (game.MakeMove(row, col))
            {
                UpdateBoard();
                if (game.GameOver)
                {
                    DisplayWinner();
                    ResetGame();
                }
                else
                {
                    MakeComputerMove();
                }
            }
        }

        private void MakeComputerMove()
        {
            if (!game.GameOver)
            {
                game.ComputerMove();
                UpdateBoard();

                if (game.GameOver)
                {
                    DisplayWinner();
                    ResetGame();
                }
            }
        }

        private void DisplayWinner()
        {
            if (game.CheckWinCondition('X'))
            {
                MessageBox.Show("Наступного разу пощастить!");
            }
            else if (game.CheckWinCondition('O'))
            {
                MessageBox.Show("Ви перемогли!");
            }
            else
            {
                MessageBox.Show("Нічия!");
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = game.Board[i, j].ToString();
                }
            }
        }

        private void ResetGame()
        {
            game.ResetBoard();
            ResetBoard();
            MakeComputerMove(); 
            UpdateBoard();
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                }
            }
        }
        private void CPU_Load(object sender, EventArgs e)
        {

        }
    }
}