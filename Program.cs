using System.Diagnostics.Metrics;
using System.Text;
namespace change_back
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int pennies = 0;
            int nickles = 0;
            int dimes = 0;
            int quarters = 0;
            int loonies = 0;
            int toonies = 0;
            foreach (string i in File.ReadLines(@"change_back_sample.txt", Encoding.UTF8))
            {
                string j = i.Trim() + ' ';
                string temp = "";
                
                foreach (char c in j)
                {
                    if (c != ' '){
                        temp += c;
                    }
                    else{
                        if (counter == 0){
                            counter++;
                            Int32.TryParse(temp, out pennies);
                            temp = "";
                        }
                        else if (counter == 1){
                            counter++;
                            Int32.TryParse(temp, out nickles);
                            temp = "";
                        }
                        else if (counter == 2){
                            counter++;
                            Int32.TryParse(temp, out dimes);
                            temp = "";
                        }
                        else if (counter == 3){
                            counter++;
                            Int32.TryParse(temp, out quarters);
                            temp = "";
                        }
                        else if (counter == 4){
                            counter++;
                            Int32.TryParse(temp, out loonies);
                            temp = "";
                        }
                        else if (counter == 5){
                            counter = 0;
                            Int32.TryParse(temp, out toonies);
                            temp = "";
                        }
                    }
                }
                bool lowestFound = false;
                double lowestVal = 0.00;
                double lowest;
                while (!lowestFound)
                {
                    lowestVal += 0.01;
                    lowestVal = Math.Round(lowestVal, 2);
                    lowest = Math.Round(lowestVal,2);
                    int tempToonies = toonies;
                    while ((lowest - 2.00) >= 0 && tempToonies > 0)
                    {
                        lowest -= 2.00;
                        tempToonies--;
                        lowest = Math.Round(lowest, 2);
                    }
                    int tempLoonies = loonies;
                    while ((lowest - 1.00) >= 0 && tempLoonies > 0)
                    {
                        lowest -= 1.00;
                        tempLoonies--;
                        lowest = Math.Round(lowest, 2);
                    }
                    int tempQuarters = quarters;
                    while ((lowest - 0.25) >= 0 && tempQuarters > 0)
                    {
                        lowest -= 0.25;
                        tempQuarters--;
                        lowest = Math.Round(lowest, 2);
                    }
                    int tempDimes = dimes;
                    while ((lowest - 0.10) >= 0 && tempDimes > 0)
                    {
                        lowest -= 0.10;
                        tempDimes--;
                        lowest = Math.Round(lowest, 2);
                    }
                    int tempNickles = nickles;
                    while ((lowest - 0.05) >= 0 && tempNickles > 0)
                    {
                        lowest -= 0.05;
                        tempNickles--;
                        lowest = Math.Round(lowest, 2);
                    }
                    int tempPennies = pennies;
                    while ((lowest - 0.01) >= 0 && tempPennies > 0)
                    {
                        lowest -= 0.01;
                        tempPennies--;
                        lowest = Math.Round(lowest, 2);
                    }
                    if (lowest == 0.01){
                        lowestFound = true;
                    }
                }
                Console.WriteLine($"Mickey can't make change for ${lowestVal.ToString("0.00")}");
            }
        }
    }
}