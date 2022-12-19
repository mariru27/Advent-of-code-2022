using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
//7413
string GetFirstDigit(string tempList)
{
  MatchCollection matches = Regex.Matches(tempList, @"\d+");
  string[] resultFirst = matches.Cast<Match>()
                         .Take(1)
                         .Select(match => match.Value)
                         .ToArray();
  //if (resultFirst.Any())
  return resultFirst[0];
  //return "-1";
}

int CountNumbersInString(string line)
{
  MatchCollection matches = Regex.Matches(line, @"\d+");
  string[] resultFirst = matches.Cast<Match>()
                         .Select(match => match.Value)
                         .ToArray();
  return resultFirst.Length;
}

bool IsDigit(char c)
{
  return c >= '0' && c <= '9';
}

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


Result CompareList(string list1, string list2)
{
  List<int> resultList1 = new List<int>();
  List<int> resultList2 = new List<int>();
  if (list1.Contains(','))
  {
    var res = list1.Split(',');
    foreach (string item in res)
    {
      resultList1.Add(int.Parse(item));
    }
  }
  else
  {
    resultList1.Add(int.Parse(GetFirstDigit(list1)));
  }

  if (list2.Contains(','))
  {
    var res = list2.Split(',');
    foreach (string item in res)
    {
      resultList2.Add(int.Parse(item));
    }
  }
  else
  {
    resultList2.Add(int.Parse(GetFirstDigit(list1)));
  }

  int i = 0;
  int equal = 0;
  while (true)
  {
    if (resultList1.Count == i && resultList1.Count == i && i == equal)
    {
      return Result.Equal;
    }
    if (resultList1.Count <= i)
    {
      return Result.Less;
    }
    if (resultList2.Count <= i)
    {
      return Result.Greater;
    }

    if (resultList1[i] < resultList2[i])
    {
      return Result.Less;
    }

    if (resultList1[i] > resultList2[i])
    {
      return Result.Greater;
    }
    if (resultList1[i] == resultList2[i])
    {
      equal++;
    }
    i++;
  }
}

// 1 first < second less
// 2 first == second qual
// 3 first > second greater

Result Compare(string firstList, string secondList)
{
  Result res = Result.Less;
  int equal = 0;
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
    if (string.IsNullOrEmpty(firstList))
    {
      return Result.Less;
    }
    else if (string.IsNullOrEmpty(secondList))
    {
      return Result.Greater;
    }

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
  if (firstList.Count(a => a == '[') == 1 && firstList.Count(a => a == ']') == 1 &&
    !secondList.Contains(']') && !secondList.Contains('['))
  {
    res = Compare(firstList, '[' + secondList + ']');
    if (res != Result.Equal)
      return res;
    else equal++;
  }

  //nr vs list
  if (secondList.Count(a => a == '[') == 1 && secondList.Count(a => a == ']') == 1 &&
  !firstList.Contains(']') && !firstList.Contains('['))
  {
    res = Compare('[' + firstList + ']', secondList);
    if (res != Result.Equal)
      return res;
    else equal++;
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
  if (result[i] ==  Result.Less)
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