using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Rhiannon Lawson U40661089
namespace Stock_project_attempt_2
{
    public partial class StockProgram : Form
    {
        private List<Candlestick> Candlesticks = null;//declares the candlesticks class of list type
        private BindingList<Candlestick> boundCandlesticks = null;//declares the bound candlesticks class of binding type

        public StockProgram()
        {
            InitializeComponent();
            Candlesticks = new List<Candlestick>(1024);//makes candlestick into a new  list
            boundCandlesticks = new BindingList<Candlestick>();//makes boundcnadlesticks into a new binding list
        }


        /// <summary>
        /// class to make a candlestick, lists all the parameters at the top
        /// </summary>
        internal class Candlestick//to be able to make candle sticks
        {
            public decimal open { get; set; }//declaring open
            public decimal close { get; set; }//declaring close
            public decimal high { get; set; }//declaring high
            public decimal low { get; set; }//declaring low
            public decimal adjLow { get; set; }//declaring adj low
            public ulong volume { get; set; }//declaring volume(its not a decimal)
            public DateTime date { get; set; }//declaring date

            /// <summary>
            /// hopefully will convert data into a candlestick from one line of excel.
            /// </summary>
            /// <param name="data">"data is the string that is passed as a line of a single candle stick"</param>
            public Candlestick(string data)
            {
                char[] seperators = new char[] { ',', ' ', '"' };//the characters that seperate each item in the list

                string[] subs = data.Split(seperators, StringSplitOptions.RemoveEmptyEntries);//split the data based on their seperators and nuke any empty spaces

                //now that they are cut into tiny pieces can build a candlestick out of said pieces 
                //start with the date
                string dateString = subs[0];//grabbing the date from the first in the list because thats how excel formatted that
                date = DateTime.Parse(dateString);//parse the data

                //open
                decimal temp;//temp value to take on the value of parsed decimal 
                bool success = decimal.TryParse(subs[1], out temp);//success is true only if the parse is successful, the parse outputs into temp
                if (success) open = temp;//if the success is true because previous line worked then the open value of the candle is written in

                //high
                success = decimal.TryParse(subs[2], out temp);//success is true only if the parse is successful, the parse outputs into temp
                if (success) high = temp;//if the success is true because previous line worked then the high value of the candle is written in

                //low
                success = decimal.TryParse(subs[3], out temp);//success is true only if the parse is successful, the parse outputs into temp
                if (success) low = temp;//if the success is true because previous line worked then the low value of the candle is written in

                //close
                success = decimal.TryParse(subs[4], out temp);//success is true only if the parse is successful, the parse outputs into temp
                if (success) close = temp;//if the success is true because previous line worked then the close value of the candle is written in

                //adj close
                success = decimal.TryParse(subs[5], out temp);//success is true only if the parse is successful, the parse outputs into temp
                if (success) adjLow = temp;//if the success is true because previous line worked then the adj close value of the candle is written in

                //volume
                ulong tempVol;//needs a new temp because the type of volume is not decimal
                success = ulong.TryParse(subs[6], out tempVol);//success is true only if the parse is successful, the parse outputs into tempVol, needs a ulong unlike others bec thats its type
                if (success) volume = tempVol;//if the success is true because previous line worked then the volume value of the candle is written in

            }
        }



        /// <summary>
        /// when the button is clicked it will take the selection of time type and call the dialog box
        /// then the button will refresh to show it can be used again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)//the function that is called if the stock button is clicked
        {

            //put the range select here so it can be used in the dialog open
            if (radioButton_day.Checked == true)//if day is selected
            {
                openFileDialog_stockChoose.Filter = "Daily|*-Day.csv";//the filter gets the day filter
            }
            else if (radioButton_week.Checked == true)//if week is selected
            {
                openFileDialog_stockChoose.Filter = "Weekly|*-Week.csv";//the filter gets the week filter
            }
            else if (radioButton_month.Checked == true)//if month is selected
            {
                openFileDialog_stockChoose.Filter = "Monthly|*-Month.csv";//the filter gets the month filter
            }
            else//if nothing was selected
            {
                openFileDialog_stockChoose.Filter = "Monthly|*-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv|All Files|*.csv";// enters the filter to automatically put month first, then week, then day, then all files
            }

            openFileDialog_stockChoose.ShowDialog();//opens the dialog box to choose the stock
            button_stockLoad.Text = "Load new stock";//changes the text on the button 

        }





        /// <summary>
        /// the things that are done when openfile dialog is opened, not going to lie I have no clue what 
        /// the parameters do on this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)//things that will happen once the dialog box opens
        {
            string fileName = openFileDialog_stockChoose.FileName;//making filename be the path of the file
            this.Text = fileName;//changes the name of what the program is desplaying in the top left to be the path of the file

            //reading file
            goReadFile();//calls the read file method

            filterCandlesticks();//calls for the candle sticks to be filtered

            normalizeChart();//calls for chart to be normalized

            displayChart();//calls for the chart to display the new list

            
        }







        /// <summary>
        /// The function that calls the real go read file, just does all the inbetween 
        /// work like getting the file name
        /// </summary>

        private void goReadFile()
        {
            string fileName = openFileDialog_stockChoose.FileName;//making filename be the path of the file
            this.Text = fileName;//changes the name of what the program is desplaying in the top left to be the path of the file
            goReadFile(fileName);//summons the actual go read file

        }
        /// <summary>
        /// reads a line from the excel spread sheet and passes it to candlestick to make a new candlestick
        /// until it runns out of lines
        /// </summary>
        /// <param name="filename">"the filename of the file thats being read so it knows what file to read</param>
        private void goReadFile(string filename)//function to read the data from the selected file
        {
            const string refString = "Date,Open,High,Low,Close,Adj Close,Volume";//make refrence string be the orderthe data is displayed

            using (StreamReader sr = new StreamReader(filename))//set sr to be reading the file name
            {
                Candlesticks.Clear();//clear out previous candle sticks
                string line = sr.ReadLine();//read a line

                if (line == refString)//start reading and continue until file ends
                {
                    while ((line = sr.ReadLine()) != null)//while the reader didnt hit the end of the file
                    {
                        Candlestick cs = new Candlestick(line);//make a new candle stick
                        Candlesticks.Add(cs);//add it to the list
                    }
                }
                else//else for if the file doesnt follow the same format of the candle sticks or something else goes wrong
                {
                    Text = "Bad file" + filename;//A print to show the files bad
                }
            }
        }




        /// <summary>
        /// Calls the real and better filter Candlestick and puts the result in a binding list
        /// </summary>
        private void filterCandlesticks()
        {
            //calls filter candlesticks with the parameters needed
            List<Candlestick> filteredList = filterCandlesticks(Candlesticks, dateTimePicker_start.Value, dateTimePicker_End.Value);
            boundCandlesticks = new BindingList<Candlestick>(filteredList);//puts the filtered list into a binding list
        }

        /// <summary>
        /// Creates a new filtered list within the date range selected by the user in the date time picker
        /// by comparing the dates and only putting the ones inbetween into the filtered list
        /// </summary>
        /// <param name="unfilteredList">"the list of all the candles from the company</param>
        /// <param name="start">the start date</param>
        /// <param name="end">"the end date"</param>
        /// <returns>returns the filtered list of candles sticks in the date range</returns>
        private List<Candlestick> filterCandlesticks(List<Candlestick> unfilteredList, DateTime start, DateTime end)
        {
            List<Candlestick> filteredList = new List<Candlestick>(unfilteredList.Count);//make a new list to put everything into
            foreach (Candlestick c in unfilteredList)//go through each candle and determin if it is in the date range or not
            {
                if (c.date < start)//if the date of the candle is before the start date
                {
                    continue;//then continue because there are still candles to check but we dont want this one added
                }

                if (c.date > end)//if the date of the candle is after the end date
                {
                    break;//break because all the candles after that wont be in the range and are useless
                }

                filteredList.Add(c);//if it makes it this far it means its in the range and should be added to the filtered list

            }
            return filteredList;//return the new and improved filtered list
        }



        /// <summary>
        /// the basic version of calling display chart
        /// </summary>

        private void displayChart()
        {
            displayChart(boundCandlesticks);//calls for the better function to display the candle sticks
        }

        /// <summary>
        /// the display chart funtion that actually does stuff. It connects the data to
        /// the data grid view and the chart
        /// </summary>
        /// <param name="candleList">the bound list that is passed</param>

        private void displayChart(BindingList<Candlestick> candleList)
        {
            dataGridView_candleSticks.DataSource = candleList;//connects candleStick as the data source to the graph
            chart_OHLC.DataSource = candleList;//connects the data to the chart
            chart_OHLC.DataBind();//binds the data to the chart because it wont load otherwise
        }



        /// <summary>
        /// I wanted to do something with this but am now struggling to try to figure out how to delete this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void radioButton_day_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// this is for when the update button is clicked
        /// idk what the parameters are because they were autofilled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_update_Click(object sender, EventArgs e)
        {
            update();
        }



        /// <summary>
        /// calling this updates the chart withough having to pick a new file
        /// </summary>
        
        private void update()
        {
            filterCandlesticks();//calls for the candle sticks to be filtered

            normalizeChart();//calls for the chart to be normalized

            displayChart();//calls for the chart to display the new list
        }







        /// <summary>
        /// gets the min and max of the filtered list
        /// </summary>
        /// <param name="candleStickList">the filtered list passed through</param>

        private static(decimal,decimal) getMinMax(BindingList<Candlestick> candleStickList, decimal min, decimal max)
        {
            foreach (Candlestick c in candleStickList)//go through each candle stick
            {
                if (max == 0)//set the first high to max, if 0, that means its the first
                {
                    max = c.high;//set the high of the first to max
                }

                if(min == 0)//set the first low to min, if 0 it means its the first
                {
                    min = c.low;//set the low of the first to min
                }
                if (c.high > max)//if high is greater than current max then its the new max
                {
                    max = c.high;//set the new max
                }

                if (c.low < min)//if low is lower than current min then its the new min
                {
                    min = c.low;//set the new min
                }
            }
            return (min,max);//return the min of the low and max of the high
        }
        /// <summary>
        /// the function that gets the min and max for the normalizing of the chart
        /// </summary>

        private void normalizeChart()
        {
            decimal min = 0;//set a min
            decimal max = 0;//set a max
            (min,max) = getMinMax(boundCandlesticks, min, max);//call the min and max function so they can be passed in the next line
            normalizeChart(min, max);//call the actual normalization function
        }


        /// <summary>
        /// this makes the chart be 2% higher than its highest high value and
        /// 2% lower than its lowest low
        /// </summary>
        /// <param name="minimum">is the smallest low of the candles</param>
        /// <param name="maximum">is the highest high of the candles</param>
        private void normalizeChart(decimal minimum, decimal maximum)
        {
            
            double up = Convert.ToDouble(maximum);//convert max to a double
            double down = Convert.ToDouble(minimum);//convert min to a double
            double spacing = up - down;//get the number between max and min
            double temp = spacing * 0.02;//find the 2% of that
            

            //for the next two lines Math.floor/ceiling is for rounding up or down and multiplying by 100 before using floor&ceiling then dividing by 100 gives a number out to 2 decimals
            chart_OHLC.ChartAreas[0].AxisY.Minimum = Math.Floor((down - temp)*100)/100;//change the min to be 2% less than its lowest value
            chart_OHLC.ChartAreas[0].AxisY.Maximum = Math.Ceiling((up + temp)*100)/100;//change the max to be 2% more than its highest value
            temp = Math.Round((temp*100)/100)*10;//get a nice number for the Y axis spacing by putting a number out by 2 decimals. The 10 is just because 10 ends up looking like a nice number
            chart_OHLC.ChartAreas[0].AxisY.Interval = temp;//change the Y axis interval to be off by the offput one lilne above
        }


    }
 }


    

