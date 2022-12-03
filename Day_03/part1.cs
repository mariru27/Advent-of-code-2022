// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

int GetIndexForChar(char c)
{
  if(c <= 'z' && c >= 'a')
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
foreach (var line in lines)
{
  string firstHalf = line.Substring(0, line.Length/2);
  string secondHalf = line.Substring((line.Length / 2), (line.Length / 2));
  var common = firstHalf.Intersect(secondHalf);
  if(common.Any())
  {
    sum +=  GetIndexForChar(common.First());
  }
}


Console.WriteLine(sum);