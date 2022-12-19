const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);

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

Result Compare(string firstList, string secondList)
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

      res = Compare(f, s);
      if (res != Result.Equal)
        return res;
    }
  }

  //list vs nr
  if (firstList.Contains(']') && firstList.Contains('[') &&
    !secondList.Contains(']') && !secondList.Contains('['))
  {
    res = Compare(firstList, '[' + secondList + ']');
    if (res != Result.Equal)
      return res;
  }

  //nr vs list
  if (secondList.Contains(']') && secondList.Contains('[') &&
  !firstList.Contains(']') && !firstList.Contains('['))
  {
    res = Compare('[' + firstList + ']', secondList);
    if (res != Result.Equal)
      return res;
  }
  return res;
}

List<Result> result = new List<Result>();
for (int i = 0; i < lines.Length; i += 3)
{
  result.Add(Compare(lines[i], lines[i + 1]));
}

int total = 0;
for (int i = 0; i < result.Count; i++)
{
  if (result[i] == Result.Less)
  {
    total += i + 1;
  }
}

Console.WriteLine(total);
enum Result
{
  Less,
  Equal,
  Greater,
};