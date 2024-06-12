using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursova
{
    public partial class PVP : Form
    {
            private TicTacToeGame game;
            private Button[,] buttons;
            public PVP()
            {
                InitializeComponent();
                game = new TicTacToeGame();
                InitializeBoard();
            }
            private void InitializeBoard()
            {
                buttons = new Button[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Button button = new Button()
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
                    button.Text = game.CurrentPlayer.ToString();
                    if (game.CheckWin())
                    {
                        MessageBox.Show(game.CurrentPlayer + " Переміг!");
                        game.ResetBoard();
                        ResetBoard();
                    }
                    else if (game.IsBoardFull())
                    {
                        MessageBox.Show("Нічия!");
                        game.ResetBoard();
                        ResetBoard();
                    }
                    else
                    {
                        game.SwitchPlayer();
                    }
                }
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
        public class TicTacToeGame
        {
            public char[,] Board { get; private set; }
            public char CurrentPlayer { get; private set; }

            public TicTacToeGame()
            {
                Board = new char[3, 3];
                CurrentPlayer = 'X';
                InitializeBoard();
            }
            public void InitializeBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Board[i, j] = ' ';
                    }
                }
            }
            public bool MakeMove(int row, int col)
            {
                if (Board[row, col] == ' ')
                {
                    Board[row, col] = CurrentPlayer;
                    return true;
                }
                return false;
            }
            public void SwitchPlayer()
            {
                CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            }
            public bool CheckWin()
            {
                return (CheckRows() || CheckColumns() || CheckDiagonals());
            }
            private bool CheckRows()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer)
                    {
                        return true;
                    }
                }
                return false;
            }
            private bool CheckColumns()
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[0, j] == CurrentPlayer && Board[1, j] == CurrentPlayer && Board[2, j] == CurrentPlayer)
                    {
                        return true;
                    }
                }
                return false;
            }
            private bool CheckDiagonals()
            {
                if (Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer)
                {
                    return true;
                }
                if (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
                {
                    return true;
                }
                return false;
            }
            public bool IsBoardFull()
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
        private void PVP_Load(object sender, EventArgs e)
        {

        }
    }
}
