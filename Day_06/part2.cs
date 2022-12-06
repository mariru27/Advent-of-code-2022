using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);

bool CheckDifferentChars(string input)
{
  HashSet<char> chars= new HashSet<char>(input);
  return chars.Count == input.Length;
}

int a = 0;
int b = 14;
while(b < lines[0].Length)
{
  string sub = lines[0].Substring(a, b - a);
  if (CheckDifferentChars(sub))
    break;
  b++;
  a++;
}

Console.WriteLine(b);