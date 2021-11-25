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
using System.Windows.Shapes;
using System.Runtime.InteropServices;

/// <summary>
/// Tymczasowa funkcja do odpalania asm
/// </summary>


namespace APL_Matrix_Calculator
{
 
    /// <summary> Class <c>InsertValues</c>
    /// Control window in whuch the user can write values to the matrices
    /// </summary>
    public partial class InsertValues : Window
    {
        /// <summary>
        /// Stores the number of rows in matrix A
        /// </summary>
        private int A_rows;

        /// <summary>
        /// Stores the number of columns in matrix A
        /// </summary>
        private int A_col;

        /// <summary>
        /// Stores the number of rows in matrix B
        /// </summary>
        private int B_rows;

        /// <summary>
        /// Stores the number of columns in matrix B
        /// </summary>
        private int B_col;

        /// <summary>
        /// Stores the type of operation that is performed
        /// </summary>
        private int operation;

        /// <summary>
        /// Stores the matrix A as a 2D array of ints
        /// </summary>
        private int[,] A;

        /// <summary>
        /// Stores the matrix B as a 2D array of ints
        /// </summary>
        private int[,] B;

        /// <summary>
        /// Stores the matrix with results as a 2D array of ints
        /// </summary>
        private int[,] C;

        /// <summary>
        /// Stores what kind of language we want to use
        /// 1 - Asm
        /// 2 - C++
        /// 3 - C#
        /// </summary>
        public int type;

        long tim;
        long ticks;

        /// <summary>
        /// Constructor
        /// </summary>
        public InsertValues()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows on the window which operation is being performed
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        /// <param name="i">Type of operation</param>
        public void Oper(object sender, RoutedEventArgs e, int i)
        {
            operation = i;
            if(i == 1)
            {
                Operation.Text = "+";
            }
            else if(i==2)
            {
                Operation.Text = "-";
            }
            else if(i==3)
            {
                Operation.Text = "*"; 
            }

            
        }

        /// <summary>
        /// Function to display the ammount of rows and columns that the user declared of matrix A
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">number of columns</param>
        public void TextBoxesA(object sender, RoutedEventArgs e, int rows, int columns)
        {
            A_rows = rows;
            A_col = columns;
            A = new int[A_rows,A_col];
            for(int i = 3; i >= 0 ; i--)
            {
                for(int j = 3; j >= 0; j--)
                {
                    if((j >= columns && i >= rows) || (j <= columns && i >= rows) || (j >= columns && i <= rows))
                    {
                        string name = "a" + i + j;
                        object item = Calc.FindName(name);

                        if (item is TextBox)
                        {
                            TextBox txt = (TextBox)item;
                            txt.Visibility = Visibility.Collapsed;
                        }
                    }
                }
             
            }
        }

        /// <summary>
        /// Function to display the ammount of rows and columns that the user declared of matrix B
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">number of columns</param>
        public void TextBoxesB(object sender, RoutedEventArgs e, int rows, int columns)
        {
            B_rows = rows;
            B_col = columns;
            B = new int[B_rows, B_col];
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if ((j >= columns && i >= rows) || (j <= columns && i >= rows) || (j >= columns && i <= rows))
                    {
                        string name = "b" + i + j;
                        object item = Calc.FindName(name);

                        if (item is TextBox)
                        {
                            TextBox txt = (TextBox)item;
                            txt.Visibility = Visibility.Collapsed;
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Function to check on button click if both matrices have correct values
        /// if not it shows an error message,
        /// if it is correct add those values to the 2D arrays, declare the size of result matrix 
        /// and call specific asm functions to perform calculations
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i <= A_rows-1; i++)
            {
                for (int j = 0; j <= A_col-1; j++)
                {
                        string name = "a" + i + j;
                        object item = Calc.FindName(name);

                    if (item is TextBox)
                    {
                        TextBox txt = (TextBox)item;
                        int Value;
                        if (!int.TryParse(txt.Text, out Value))
                        {
                            MessageBox.Show("Error, character or no value in matrix A");
                            return;
                        }
                        else
                        {
                            A[i, j] = Value;
                        }
                    }
                    
                }

            }

            for (int i = 0; i <= B_rows-1; i++)
            {
                for (int j = 0; j <= B_col-1; j++)
                {
                    string name = "b" + i + j;
                    object item = Calc.FindName(name);

                    if (item is TextBox)
                    {
                        TextBox txt = (TextBox)item;
                        int Value;
                        if (!int.TryParse(txt.Text, out Value))
                        {
                            MessageBox.Show("Error, character or no value in matrix B");
                            return;
                        }
                        else
                        {
                            B[i, j] = Value;
                        }
                    }

                }

            }

            calloperations(sender, e);
            
        }

        /// <summary>
        /// Create new window where the result will be displayed
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void resultwindow(object sender, RoutedEventArgs e)
        {
            Result res = new Result();
            res.show(sender, e, C, tim, ticks);
            res.ShowDialog();
        }


        private void calloperations(object sender, RoutedEventArgs e)
        {
            CallFunctions functions = new CallFunctions();
            functions.A = A;
            functions.B = B;
            functions.type = type;

            if (operation == 1)
            {
                //Add
                C = new int[A_rows, A_col];
                functions.C = C;
                functions.callAdd();

            }
            else if (operation == 2)
            {
                //Sub
                C = new int[A_rows, A_col];
                functions.C = C;
                functions.callSub();
 
            }
            else if (operation == 3)
            {
                //Mul
                C = new int[A_rows, B_col];
                functions.C = C;
                functions.callMul();

            }

            tim = functions.tim;
            ticks = functions.ticks;
            resultwindow(sender, e);
        }
    }
}
