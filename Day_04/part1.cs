// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);
int sum = 0;

bool CheckFullyContains(int a, int b, int x, int y)
{
  if((a <= x && b >= y) || (x <= a && y >= b))
    return true;
  else
    return false;
}

foreach (var line in lines)
{
  MatchCollection matches = Regex.Matches(line, @"\d+");
  string[] result = matches.Cast<Match>()
                         .Take(4)
                         .Select(match => match.Value)
                         .ToArray();
  int a = int.Parse(result[0]);
  int b = int.Parse(result[1]);
  int x = int.Parse(result[2]);
  int y = int.Parse(result[3]);
  if (CheckFullyContains(a, b, x, y))
    sum++;
}

Console.WriteLine(sum);