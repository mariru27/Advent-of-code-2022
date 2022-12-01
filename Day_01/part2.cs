// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

int incNr = 0;
string[] lines = File.ReadAllLines(inputPath);
int sum = 0;
int maxsum =	0;
int i = 0;
List<int> maxsums = new();

foreach (var line in lines)
{
  i++;
	if (i == 14)
		i++;
  if (!string.IsNullOrEmpty(line))
	{
		int value = int.Parse(line);
		sum += value;
	}
	else
	{
		maxsums.Add(sum);
		sum = 0;
	}

}

if (string.IsNullOrEmpty(lines[lines.Length - 2]))
{
  int value = int.Parse(lines[lines.Length - 1]);
  maxsums.Add(value);
}

maxsums.Sort();
maxsums.Reverse();
int summ = maxsums[0] + maxsums[1] + maxsums[2];
Console.WriteLine(summ);
