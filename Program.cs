// Build and run this application afterwards, This will display the list of the files in a descending order worked out by the Last time written. I used this method of OrderByDescending to sort files.
// Using the commands dotnet build ,dotnet run
// Thank you for your time.


using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(){
    
        string sourcePath = @"C:\Users\Kawka\Downloads\MCMS Practical Test (C#)\MCMS Practical Test\Split File";
        string destinationDirectory = @"C:\Users\Kawka\Downloads\MCMS Practical Test (C#)";
           
        if (!Directory.Exists(sourcePath)){
            Console.WriteLine("Source path not found.");
            return;
        }

        else if (!Directory.Exists(destinationDirectory)){
            Directory.CreateDirectory(destinationDirectory);
        }

        string[] files = Directory.GetFiles(sourcePath);

        Array.Sort(files,(a,b) => GetFileNumber(a).CompareTo(GetFileNumber(b)));

        foreach (string partPath in files){
            string destinationPath =Path.Combine(destinationDirectory,Path.GetFileName(partPath));
            File.Move(partPath,destinationPath);
            Console.WriteLine($"Moved:{partPath} to {destinationPath}");
        }
        
        Console.WriteLine("Parts successfully organized based on the part number .");
    }

    static int GetFileNumber(string partPath){
        string partName =Path.GetFileNameWithoutExtension(partPath);
        int partNumber;

        if (int.TryParse(partName, out partNumber)){
            return partNumber;
        }

            return 0;
        // If no number is included in the part name
    }

}

