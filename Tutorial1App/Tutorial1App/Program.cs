using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1App
{
    public class Program //private by default
    {
        //local variables lowercase any other uppercase
        public static async Task Main(string[] args)
        {
            //    int? g = null; // ? int allows nullability of int
            //    bool b = true;
            //    string str = "Str";
            //    //Integer != int Integer created to give int a null value (in java)
            //    Console.WriteLine("Hello World!");

            //    int age = 25;
            //    Console.WriteLine($"I am {age} years old");

               //Crawler that looks for email address in the page
            var url = @"https://www.pja.edu.pl";
            using (var httpClient = new HttpClient()) // var assignes the variable as right
            {
                using (var response = await httpClient.GetAsync(url))
                {

                    var content = await response.Content.ReadAsStringAsync();




                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(content); //Match only find one occurence and matches find more of them



                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }

                }
            }


            //var response = await httpClient.GetAsync(url); //asynchonous -> things run in parallel; await waits for the the method to finish
                                                           //Task.Wait blocks the thread

          
        }
    }
}
