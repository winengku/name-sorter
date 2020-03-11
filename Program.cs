using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Name_Sorter
{
    //Define name props
    public class Name
    {
        public string GivenName { get; set; }
        public string LastName { get; set; }
    }
    
    class Program { 
  
        static void Main(string[] args) {  
            //Catch arguments path and pass to variable path
            string path = $"{args[0]}";

            //Read file and input into array
            string[] readText = File.ReadAllLines(path);

            //Create list namelist in Name
            List<Name> namelist = new List<Name>();

            //Loop everyline on file
            foreach (string line in readText)
            {   
                //create new Name object 
                Name listobj = new Name();

                //Split every string in line and input into splitdata array
                string[] splitdata = line.Split(' ');

                //Validate data
                if(splitdata.Count() > 3){
                    //input data into list namelist
                    namelist.Add(new Name { GivenName = line, LastName = splitdata[2] });
                } else {
                    //input data into list namelist
                    namelist.Add(new Name { GivenName = line, LastName = splitdata[splitdata.Count()-1] });
                }
            }
            //input sortedlist into sortedlist variable
            var sortedlist = namelist.OrderBy(x => x.LastName).ThenBy(x => x.GivenName).ToList();
            
            //write sorted list into text file
            using(TextWriter tw = new StreamWriter("sorted-names-list.txt"))
            {
                foreach (var item in sortedlist)
                    tw.WriteLine("{0}",item.GivenName);
            }

            //showing output
            foreach (var item in sortedlist){
                Console.WriteLine("{0}", item.GivenName);
            }
        } 
    }    
} 

