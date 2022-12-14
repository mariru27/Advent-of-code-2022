using System.Text.RegularExpressions;

namespace AOC_2022
{

  public class Monkey
  {
    public List<long> GetStartingItems(string line)
    {
      List<long> items = new List<long>();
      MatchCollection matches = Regex.Matches(line, @"\d+");
      string[] result = matches.Cast<Match>()
                             .Select(match => match.Value)
                             .ToArray();
      foreach (var item in result)
      {
        items.Add(long.Parse(item));
      }
      return items;
    }

    public long GetOneDigitFromString(string line)
    {
      MatchCollection matches = Regex.Matches(line, @"\d+");
      string[] result = matches.Cast<Match>()
                             .Take(1)
                             .Select(match => match.Value)
                             .ToArray();
      return long.Parse(result[0]);
    }

    public long GetOperationNumber(string line)
    {
      MatchCollection matches = Regex.Matches(line, @"\d+");
      string[] result = matches.Cast<Match>()
                             .Take(1)
                             .Select(match => match.Value)
                             .ToArray();
      if (!result.Any())
        return -1;
      return long.Parse(result[0]);
    }

    public string GetOperation(string line)
    {
      MatchCollection matches = Regex.Matches(line, @"\+|\*");
      string[] result = matches.Cast<Match>()
                             .Take(1)
                             .Select(match => match.Value)
                             .ToArray();
      return result[0];
    }

    public void PrintStartingItems()
    {
      foreach (var item in StartingItems)
      {
        Console.Write(item + ", ");
      }
      Console.WriteLine();
    }
    public long Id { get; set; }
    public List<long> StartingItems { get; set; }
    public string Operation { get; set; }
    public long OperationNumber { get; set; }
    public long DivisibleNr { get; set; }
    public int ThrowToMonkey1True { get; set; }
    public int ThrowToMonkey2False { get; set; }
    public long InspectsItems { get; set; }
    public Monkey(string lineId, string lineStratingItems, string lineOperation,
                  string lineDivisibleNr, string lineMonkey1, string lineMonkey2)
    {
      InspectsItems = 0;
      Id = GetOneDigitFromString(lineId);
      StartingItems = GetStartingItems(lineStratingItems);
      Operation = GetOperation(lineOperation);
      OperationNumber = GetOperationNumber(lineOperation);
      DivisibleNr = GetOneDigitFromString(lineDivisibleNr);
      ThrowToMonkey1True = (int)GetOneDigitFromString(lineMonkey1);
      ThrowToMonkey2False = (int)GetOneDigitFromString(lineMonkey2);
    }
  }
}
