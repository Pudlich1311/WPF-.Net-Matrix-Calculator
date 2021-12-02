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
        public Result(long tmasm, long tmcpp, long tmcs, long tiasm, long ticpp, long tics)
        {
            InitializeComponent();
            timeasm = tmasm;
            timecpp = tmcpp;
            timecs = tmcs;
            ticksasm = tiasm;
            tickscpp = ticpp;
            tickscs = tics;
        }

        public long timeasm, timecpp, timecs;
        public long tickscpp, ticksasm, tickscs;
        /// <summary>
        /// Shows the result 2D array
        /// </summary>
        /// <param name="sender">Object on which we perform action</param>
        /// <param name="e">Event control</param>
        /// <param name="C">Result 2D array</param>
        public void show(object sender, RoutedEventArgs e, float[,] C)
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
            tcpp.Text += timecpp.ToString() + " ms" + "\n";
            tcpp.Text += tickscpp.ToString() + " ticks";

            tasm.Text += timeasm.ToString() + " ms" + "\n";
            tasm.Text += ticksasm.ToString() + " ticks";

            tcs.Text += timecs.ToString() + " ms" + "\n";
            tcs.Text += tickscs.ToString() + " ticks";
        }
    }
}
