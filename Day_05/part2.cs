using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);
Stack<string>[] crates = new Stack<string>[10];
Stack<string>[] revCrates = new Stack<string>[10];


void move(int move, int from, int to)
{
  from--;
  to--;
  List<string> temp = new List<string>();
  for(int i = 0; i < move; i++)
  {
    temp.Add(revCrates[from].Pop());
  }
  temp.Reverse();
  foreach (var item in temp)
  {
    revCrates[to].Push(item);
  }
}

bool getCrates = false;
int i = 0;
foreach (var line in lines)
{
  if (string.IsNullOrEmpty(line))
  {
    getCrates = true;
    //reverse stack
    int j = 0;
    foreach (var item in crates)
    {
      if(item == null) continue;
      int size = item.Count;
      for (int l = 0; l < size; l++)
      {
        if (revCrates[j] == null)
        {
          revCrates[j] = new Stack<string>();
        }
        revCrates[j].Push(crates[j].Pop());
      }
      j++;
    }
    continue;
  }

  if (getCrates)
  {
    MatchCollection matches = Regex.Matches(line, @"\d+");
    string[] result = matches.Cast<Match>()
                           .Take(3)
                           .Select(match => match.Value)
                           .ToArray();
    move(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2]));
  }
  else
  {
    int a = 0;
    int b = 0;
    int j = 0;
    while(a<line.Length)
    {
      b += 4;
      if(b > line.Length) { b = line.Length; }
      var sub = line.Substring(a, b - a);
      MatchCollection matches = Regex.Matches(sub, @"[A-Z]");
      string[] result = matches.Cast<Match>()
                             .Select(match => match.Value)
                             .ToArray();
      if(result.Any())
      {
        if (crates[j] == null) 
        { 
          crates[j] = new Stack<string>();
        }
        crates[j].Push(result.First());
      }

      a = b;
      j++;
    }
  }
  i++;
}

string resultText = "";
int sizet = revCrates.Length;
for (int k = 0; k < sizet; k++)
{
  if (revCrates[k] == null) break;
  resultText += revCrates[k].Pop();
}
Console.WriteLine(resultText);