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

namespace APL_Matrix_Calculator
{
    /// <summary> Class <c>Result</c>
    /// Controls the result window
    /// </summary>
    public partial class Result : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Result()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the result 2D array
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        /// <param name="C">Result 2D array</param>
        public void show(object sender, RoutedEventArgs e, int[,] C, long time, long ticks)
        {
            int rowLength = C.GetLength(0);
            int colLength = C.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Answer.Text += C[i, j];
                    if(j != colLength-1)
                    {
                        Answer.Text += "  ";
                    }
                }
                Answer.Text += "\n";
            }
            t.Text += time.ToString() + " ms" + "\n";
            t.Text += ticks.ToString() + " ticks";
        }
    }
}
