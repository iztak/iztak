using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Othello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool initializeCheck;
        bool whiteTurn;
        List<Ellipse> whiteCheck = new List<Ellipse>();
        List<Ellipse> blackCheck = new List<Ellipse>();
        List<Board> board = new List<Board>();


        public MainWindow()
            {
                InitializeComponent();
                InitializeBoard();

            }

            private void WindowIsClicked(object sender, MouseButtonEventArgs e)
            {
            if (e.OriginalSource is Rectangle)
            {

                Rectangle square = (Rectangle)e.OriginalSource;
                int squareColumn = (int)square.GetValue(Grid.ColumnProperty);
                int squareRow = (int)square.GetValue(Grid.RowProperty);

                Circles c1 = new Circles();

                if (!IsPiecePosition(squareColumn, squareRow))
                {
                    if (whiteTurn && IsValidPosition(true, squareColumn, squareRow, blackCheck, whiteCheck))
                    {
                        DrawEllipse(squareColumn, squareRow, whiteCheck, Brushes.White, Brushes.Black);
                        GameControl.Content = "Black turn";
                        whiteTurn = false;

                    }
                    else if (!whiteTurn && IsValidPosition(true, squareColumn, squareRow, whiteCheck, blackCheck))
                    {
                        DrawEllipse(squareColumn, squareRow, blackCheck, Brushes.Black, Brushes.White);
                        GameControl.Content = "White turn";
                        whiteTurn = true;

                    }
                    Score.Text = $"White: {whiteCheck.Count}   Black: {blackCheck.Count}";

                }
                if ((whiteCheck.Count + blackCheck.Count == 64) && whiteCheck.Count < blackCheck.Count)
                {
                    GameControl.Content = "Black Won!";
                    MessageBox.Show("End Game");
                    this.Close();
                }
                else if ((whiteCheck.Count + blackCheck.Count == 64) && whiteCheck.Count > blackCheck.Count)
                {
                    GameControl.Content = "White Won!";
                    MessageBox.Show("End Game");
                    this.Close();
                }
                else if ((whiteCheck.Count + blackCheck.Count == 64) && whiteCheck.Count == blackCheck.Count)
                {
                    GameControl.Content = "Draw!";
                    MessageBox.Show("End Game");
                    this.Close();
                }

                initializeCheck = false;
            }
            }

        private bool IsPiecePosition(int squareColumn, int squareRow)
            {
                for (int i = 0; i < whiteCheck.Count; i++)
                {
                    if (squareColumn == (int)whiteCheck[i].GetValue(Grid.ColumnProperty) && squareRow == (int)whiteCheck[i].GetValue(Grid.RowProperty))
                    {
                        return true;
                    }
                }
                for (int i = 0; i < blackCheck.Count; i++)
                {
                    if (squareColumn == (int)blackCheck[i].GetValue(Grid.ColumnProperty) && squareRow == (int)blackCheck[i].GetValue(Grid.RowProperty))
                    {
                        return true;
                    }
                }

            return false;
            }


        private bool IsValidPosition(bool changeColor, int squareColumn, int squareRow,  List<Ellipse> checkToChange, List<Ellipse> checkSet)
        {
            bool IsValid = false;

            for ( int i = 0; i < checkToChange.Count; i++)
            {
                int checkToChangeColumn = (int)checkToChange[i].GetValue(Grid.ColumnProperty);
                int checkToChangeRow = (int)checkToChange[i].GetValue(Grid.RowProperty);
                int columnDirection = squareColumn - checkToChangeColumn;
                int rowDirection = squareRow - checkToChangeRow;
                
                if(columnDirection == -1 && rowDirection == -1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == 1 && rowDirection == -1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == 0 && rowDirection == -1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == 1 && rowDirection == 0)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == -1 && rowDirection == 0)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == -1 && rowDirection == 1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == 1 && rowDirection == 1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }
                else if (columnDirection == 0 && rowDirection == 1)
                {
                    if (CheckForValidCheck(changeColor, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet))
                    {
                        IsValid = true;
                        i = -1;
                    }
                }

            }

            return IsValid;
        }

        private bool CheckForValidCheck(bool ChangeColor, int squareColumn, int squareRow, int columnDirection, int rowDirection, List<Ellipse> checkToChange, List<Ellipse> checkSet)
        {
            

            for (int x = 1; IsPiecePosition(squareColumn - (x * columnDirection), squareRow - (x * rowDirection)); x++)
            {

                for (int i = 0; i < checkSet.Count; i++)
                {
                    int checkSetColumn = (int)checkSet[i].GetValue(Grid.ColumnProperty);
                    int checkSetRow = (int)checkSet[i].GetValue(Grid.RowProperty);
                    if ((squareColumn - (x * columnDirection)) == checkSetColumn && (squareRow - (x * rowDirection)) == checkSetRow)
                    {
                        if(ChangeColor)
                        {
                            ChangeColorOfCheck(x, squareColumn, squareRow, columnDirection, rowDirection, checkToChange, checkSet);
                        }
                        return true;
                    }

                }

            }
            return false;
        }

        private void ChangeColorOfCheck(int a, int squareColumn, int squareRow, int columnDirection, int rowDirection, List<Ellipse> checkToChange, List<Ellipse> checkSet)
        {
            for (int x = 1;x < a; x++)
            {
                for (int j = 0; j < checkToChange.Count; j++)
                {
                    int checkToChangeColumn = (int)checkToChange[j].GetValue(Grid.ColumnProperty);
                    int checkToChangeRow = (int)checkToChange[j].GetValue(Grid.RowProperty);

                    if ((squareColumn - (x * columnDirection)) == checkToChangeColumn && (squareRow - (x * rowDirection)) == checkToChangeRow)
                    {
                        if (checkToChange[j].Fill == Brushes.White)
                        {
                            DrawEllipse(checkToChangeColumn, checkToChangeRow, blackCheck, Brushes.Black, Brushes.White);
                            checkToChange.Remove(checkToChange[j]);
                            break;
                        }
                        else
                        {
                            DrawEllipse(checkToChangeColumn, checkToChangeRow, whiteCheck, Brushes.White, Brushes.Black);
                            checkToChange.Remove(checkToChange[j]);
                            break;
                        }

                    }

                }
            }
        }

        private void DrawEllipse(int i, int j, List<Ellipse> Check, SolidColorBrush brush, SolidColorBrush strokeBrush)
        { 
            Circles c1 = new Circles();
            c1.piece.Fill = brush;
            c1.piece.Stroke = strokeBrush;

            c1.piece.SetValue(Grid.ColumnProperty, i);
            c1.piece.SetValue(Grid.RowProperty, j);

            Check.Add(c1.piece);
            board[(j * 8) + i].IsEmpty = false;
            if(Check[0].Fill == Brushes.White)
            {
                board[j * 8 + i].IsWhite = true;
            }


            Grid.Children.Add(c1.piece);
         }



        private void GameControlIsClicked(object sender, RoutedEventArgs e)
        {
            if (Score.Text == "Start Game")
            {
                DrawEllipse(3, 4, whiteCheck, Brushes.White, Brushes.Black);
                DrawEllipse(4, 3, whiteCheck, Brushes.White, Brushes.Black);
                DrawEllipse(3, 3, blackCheck, Brushes.Black, Brushes.White);
                DrawEllipse(4, 4, blackCheck, Brushes.Black, Brushes.White);
                Score.Text = "White: 2   Black 2";

                {
                    whiteTurn = true;
                    GameControl.Content = "White Turn";
                }

            }
            else if (whiteTurn) 
            {
                whiteTurn = false;
                GameControl.Content = "Black Turn";
            }
            else
            {
                whiteTurn = true;
                GameControl.Content = "White Turn";
            }

        }

      private void InitializeBoard()
      {
          for (int i = 0; i < 8; i++)
          {
              for (int j = 0; j < 8; j++)
              {
                  if((i+j)%2 == 1)
                  {
                      Board b1 = new Board();
                      b1.square.SetValue(Grid.ColumnProperty, i);
                      b1.square.SetValue(Grid.RowProperty, j);
                      b1.square.Fill = Brushes.White;
                      Grid.Children.Add(b1.square);
                      board.Add(b1);
                  }
                  else
                  {
                      Board b2 = new Board();
                      b2.square.SetValue(Grid.ColumnProperty, i);
                      b2.square.SetValue(Grid.RowProperty, j);
                      b2.square.Fill = Brushes.Black;
                      Grid.Children.Add(b2.square);
                      board.Add(b2);
                  }
              }
          }
      }

    }
    }
