using System.Linq;
using System.IO;
class InflationAnalysis
{
    List<Inflation> AsianPacificInflation;

    public InflationAnalysis()
    {
        AsianPacificInflation = new List<Inflation>();
    }
public void ReadInflationData(string filePath)
{
    try
    {
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // Skip the header line
            int lineNumber = 1;

            while (!reader.EndOfStream)
            {
                lineNumber++;
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (values.Length < 6)
                {
                    Console.WriteLine($"Error: Insufficient columns in line {lineNumber}: {line}");
                    continue;
                }

                if (int.TryParse(values[1], out int year) &&
                    double.TryParse(values[2].Replace("%", ""), out double inflationRate))
                {
                    Inflation inflationData = new Inflation
                    {
                        RegionalMember = values[0].Trim('"'),
                        Year = year,
                        InflationRate = inflationRate,
                        UnitOfMeasurement = values[3],
                        Subregion = values[4],
                        CountryCode = values[5]
                    };

                    AsianPacificInflation.Add(inflationData);

                    if (inflationData.RegionalMember == "Nepal")
                    {
                        Console.WriteLine($"Debug: Nepal data added - Year: {year}, Inflation: {inflationRate}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error parsing data in line {lineNumber}: {line}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
}    public List<Inflation> GetInflationRatesForYear(int year)
    {
        return AsianPacificInflation.Where(inflation => inflation.Year == year).ToList();
    }

   public int GetYearWithHighestInflationForCountry(string countryName)
{
    var countryData = AsianPacificInflation
    .Where(inflation => inflation.RegionalMember.Trim().Equals(countryName.Trim(), StringComparison.OrdinalIgnoreCase))        .ToList();

    if (countryData.Count == 0)
    {
        Console.WriteLine($"No data found for country: {countryName}");
        return 0;
    }

    var highestInflation = countryData
        .OrderByDescending(inflation => inflation.InflationRate)
        .FirstOrDefault();

    if (highestInflation == null)
    {
        Console.WriteLine($"No valid inflation data found for country: {countryName}");
        return 0;
    }

    Console.WriteLine($"Highest inflation for {countryName}: {highestInflation.InflationRate}% in {highestInflation.Year}");
    return highestInflation.Year;
}

    public List<Inflation> GetTop10RegionsWithHighestInflation()
    {
        return AsianPacificInflation
            .Where(inflation => !string.IsNullOrEmpty(inflation.CountryCode))
            .GroupBy(inflation => inflation.RegionalMember)
            .Select(group => new Inflation
            {
                RegionalMember = group.Key,
                InflationRate = group.Average(inflation => inflation.InflationRate)
            })
            .OrderByDescending(inflation => inflation.InflationRate)
            .Take(10)
            .ToList();
    }

    public List<Inflation> GetTop3SouthAsianCountriesWithLowestInflationForYear(int year)
    {
        return AsianPacificInflation
            .Where(inflation => inflation.Year == year && inflation.Subregion == "South Asia")
            .OrderBy(inflation => inflation.InflationRate)
            .Take(3)
            .ToList();
    }
}
