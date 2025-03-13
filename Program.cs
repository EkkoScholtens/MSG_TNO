using System.Globalization;
using System.IO;
using Microsoft.Data.Analysis;
using MSG_TNO;

args = Environment.GetCommandLineArgs();
if (args.Length < 1)
{
    Console.WriteLine("Usage: <csv_file>");
    return 1;
}

var filePath = args[1];

if (!File.Exists(filePath)) {
    Console.WriteLine($"File not found: {filePath}");
    return 2;
}

try {
    // Read the CSV file using the DataFrame::LoadCsv method
    var df = DataFrame.LoadCsv(filePath, separator: ';');
    // Map the entries from binary to decimal and create a record per row
    var data = df.Rows.Select(row => new TimeStepData(row.Select(o => Convert.ToInt32(o.ToString(), 2)).ToList()));
    
    var simulator = new Simulator(data);
    simulator.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
return 0;