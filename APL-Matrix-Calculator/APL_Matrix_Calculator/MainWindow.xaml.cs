using System;
using System.Windows;



namespace APL_Matrix_Calculator
{

    /// <summary> Class <c>MainWindow</c>
    /// Controls the main window of the program
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This variable stores what operation the user wants to perform
        /// </summary>
        int oper = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Function to display addition operation that the user choose after clicking a specific button 
        /// and changing the variable that stores it
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void Add(object sender, RoutedEventArgs e)
        {
          
            State.Text = "A+B";
            oper = 1;
        }

        /// <summary>
        /// Function to display substraction that the user choose after clicking a specific button 
        /// and changing the variable that stores it
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void Sub(object sender, RoutedEventArgs e)
        {
           
            State.Text = "A-B";
            oper = 2;
        }
        /// <summary>
        /// Function to display multiplication that the user choose after clicking a specific button 
        /// and changing the variable that stores it
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void Mul(object sender, RoutedEventArgs e)
        {
           
            State.Text = "A*B";
            oper = 3;
        }

        /// <summary>
        /// Function to check on button click if the user choose a operation and correct sizes of matrices,
        /// if not a warning message is displayed,
        ///if everything is correct call function to the next window
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void NextWindow(object sender, RoutedEventArgs e)
        {
          if(oper ==0)
          {
                string message = "No operation selected";
                MessageBox.Show(message);
                return;
          }

            if (A_Rows.SelectedItem == null || A_Columns.SelectedItem == null || B_Rows.SelectedItem == null || B_Columns.SelectedItem == null)
            {
                string message = "No value in one of the row and column boxes";
                MessageBox.Show(message);
                return;

            }

            if (oper ==1 || oper == 2)
            {
                if(A_Rows.SelectedIndex != B_Rows.SelectedIndex || A_Columns.SelectedIndex != B_Columns.SelectedIndex)
                {
                    string message = "Not the same number of rows and columns, please correct";
                    MessageBox.Show(message);
                }
                else
                {

                    newwin(sender, e);
                }
            }
            else if(oper == 3)
            {
                if(A_Columns.SelectedIndex != B_Rows.SelectedIndex)
                {
                    string message = "Not the same number of columns in matrix A and rows in matrix B, please correct";
                    MessageBox.Show(message);
                }
                else
                {
                    newwin(sender, e);
                }
            }
          
        }

        /// <summary>
        /// Function to create new window in which the user will write the values to the matrices
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        private void newwin(object sender, RoutedEventArgs e)
        {
            InsertValues insval = new InsertValues();
            insval.Oper(sender, e, oper);
            insval.TextBoxesA(sender, e, A_Rows.SelectedIndex+1, A_Columns.SelectedIndex+1);
            insval.TextBoxesB(sender, e, B_Rows.SelectedIndex + 1, B_Columns.SelectedIndex + 1);
            insval.ShowDialog();
            
        }
    }

}
