using Microsoft.Data.Analysis;
using MSG_TNO;
using MSG_TNO.Model;

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
    var df = DataFrame.LoadCsv(filePath, separator: ';' , header: false);
    // Map the entries from binary to decimal and create a record per row
    var data = df.Rows.Select(row => new RadarData(row.Select(o => Convert.ToInt32(o.ToString(), 2)).ToList())).ToList();
    
    var simulator = new Simulator(data, new Simulation(0.8, data.Count(), TimeSpan.FromSeconds(1)));
    await simulator.Run();
    
    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    return 3;
}
