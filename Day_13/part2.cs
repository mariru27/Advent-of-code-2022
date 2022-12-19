using System.Collections;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);

//added manually in input [[2]] and [[6]]

List<string> result = new List<string>();

for (int i = 0; i < lines.Length; i += 3)
{
  result.Add(lines[i]);
  result.Add(lines[i + 1]);
}

result.Sort(new CompareString());

int fIndex = result.IndexOf("[[2]]") + 1;
int sIndex = result.IndexOf("[[6]]") + 1;

Console.WriteLine(fIndex * sIndex);

public class CompareString : IComparer<string>
{
  KeyValuePair<string, string> GetNextElement(string list)
  {
    int nr = 0, j = 0;
    string result = "";
    while (j < list.Length)
    {
      if (list[j] == '[')
      {
        result += '[';
        nr++;
      }
      else if (list[j] == ']')
      {
        result += ']';
        nr--;
      }
      else if (list[j] == ',' && nr == 0)
      {
        KeyValuePair<string, string> keyValuePair =
          new(result, list.Substring(result.Length + 1));
        return keyValuePair;
      }
      else
      {
        result += list[j];
      }
      j++;
    }

    KeyValuePair<string, string> keyValuePair2;
    if (result.Length + 1 < list.Length)
    {
      keyValuePair2 = new(result, list.Substring(result.Length + 1));
    }
    else
    {
      keyValuePair2 = new(result, "");
    }


    return keyValuePair2;
  }



  // 1 first < second less
  // 2 first == second qual
  // 3 first > second greater

  Result CompareLists(string firstList, string secondList)
  {
    Result res = Result.Less;
    //compare numbers
    if (!firstList.Contains('[') && !secondList.Contains("[") &&
      !firstList.Contains(']') && !secondList.Contains(']') &&
      !firstList.Contains(',') && !secondList.Contains(','))
    {
      if (int.Parse(firstList) < int.Parse(secondList))
        return Result.Less;
      else if (int.Parse(firstList) > int.Parse(secondList))
        return Result.Greater;
      else if (int.Parse(firstList) == int.Parse(secondList))
        return Result.Equal;
    }

    //list vs list
    if (firstList.Contains('[') && secondList.Contains("[") &&
      firstList.Contains(']') && secondList.Contains(']'))
    {
      firstList = firstList.Remove(0, 1);
      secondList = secondList.Remove(0, 1);
      firstList = firstList.Remove(firstList.Length - 1, 1);
      secondList = secondList.Remove(secondList.Length - 1, 1);
      while (true)
      {
        if (firstList.Length == 0 && secondList.Length != 0)
          return Result.Less;
        else if (firstList.Length != 0 && secondList.Length == 0)
          return Result.Greater;
        else if (firstList.Length == 0 && secondList.Length == 0)
          return Result.Equal;

        string f = GetNextElement(firstList).Key;
        string s = GetNextElement(secondList).Key;
        firstList = GetNextElement(firstList).Value;
        secondList = GetNextElement(secondList).Value;

        res = CompareLists(f, s);
        if (res != Result.Equal)
          return res;
      }
    }

    //list vs nr
    if (firstList.Contains(']') && firstList.Contains('[') &&
      !secondList.Contains(']') && !secondList.Contains('['))
    {
      res = CompareLists(firstList, '[' + secondList + ']');
      if (res != Result.Equal)
        return res;
    }

    //nr vs list
    if (secondList.Contains(']') && secondList.Contains('[') &&
    !firstList.Contains(']') && !firstList.Contains('['))
    {
      res = CompareLists('[' + firstList + ']', secondList);
      if (res != Result.Equal)
        return res;
    }
    return res;
  }

  public int Compare(string x, string y)
  {
    Result z = CompareLists(x, y);
    if (z == Result.Less)
      return -1;
    if (z == Result.Equal)
      return 0;
    if (z == Result.Greater)
      return 1;
    return -1;
  }
}
enum Result
{
  Less,
  Equal,
  Greater,
};

