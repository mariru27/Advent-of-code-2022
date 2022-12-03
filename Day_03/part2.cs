// See https://aka.ms/new-console-template for more information

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

int GetIndexForChar(char c)
{
  if (c <= 'z' && c >= 'a')
  {
    return Math.Abs('a' - c) + 1;
  }
  else
  {
    return Math.Abs('A' - c) + 27;
  }
  return 1;
}

string[] lines = File.ReadAllLines(inputPath);
int sum = 0;
char[] commonChars = new char[4];
List<IEnumerable<char>> allCommonChars = new List<IEnumerable<char>>();
string lastLine = "";
int l = -1;
foreach (var line in lines)
{
  l++;
  if (string.IsNullOrEmpty(lastLine))
  {
    lastLine = line;
    continue;
  }
  else
  {
    int z = l % 3;
    if (z != 0)
    {
      allCommonChars.Add(lastLine.Intersect(line));
    }
    lastLine = line;
  }


  if (l % 3 == 0 || l == lines.Length - 1)
  {
    var common = allCommonChars[0].Intersect(allCommonChars[1]);
    if (common.Any())
      sum += GetIndexForChar(common.First());
    allCommonChars.Clear();
  }
}


Console.WriteLine(sum);