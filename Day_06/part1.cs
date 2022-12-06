using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);

bool CheckDifferentChars(string input)
{
  HashSet<char> chars= new HashSet<char>(input);
  return chars.Count == input.Length;
}

int b = 4;
while(b < lines[0].Length)
{
  string sub = lines[0].Substring(b - 4, 4);
  if (CheckDifferentChars(sub))
    break;
  b++;
}

Console.WriteLine(b);