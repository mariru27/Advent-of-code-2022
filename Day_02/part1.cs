// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

int incNr = 0;
string[] lines = File.ReadAllLines(inputPath);
int sum = 0;
int maxsum =	0;
int i = 0;
List<int> maxsums = new();
Dictionary<char, int> opponent = new();
opponent.Add('A', 1);// rock
opponent.Add('B', 2);// paper
opponent.Add('C', 3);// Scissors

Dictionary<char, int> me = new();
me.Add('X', 1); // rock
me.Add('Y', 2); // paper
me.Add('Z', 3); // Scissors
const int draw = 3;
const int won = 6;

int resultGame = 0;
foreach (var line in lines)
{


  if ((line[2] == 'X' && line[0] == 'A') || (line[2] == 'Y' && line[0] == 'B' ) 
    || (line[2] == 'Z' && line[0] == 'C'))
  {
    switch (line[2])
    {
      case 'X': resultGame += me['X']; break;
      case 'Y': resultGame += me['Y']; break;
      case 'Z': resultGame += me['Z']; break;
      default:
        break;
    }
    resultGame += draw;
  }

  if ((line[0]== 'C' && line[2] == 'Y') || (line[0] == 'B' && line[2] == 'X') ||
    (line[0] == 'A' && line[2] == 'Z'))
  {
    switch (line[2])
    {
      case 'X': resultGame += me['X']; break;
      case 'Y': resultGame += me['Y']; break;
      case 'Z': resultGame += me['Z']; break;
      default:
        break;
    }
  }


  if ((line[0] == 'B' && line[2] == 'Z') || (line[0] == 'A' && line[2] == 'Y') ||
    (line[0] == 'C' && line[2] == 'X'))
  {
    switch (line[2])
    {
      case 'X': resultGame += me['X']; break;
      case 'Y': resultGame += me['Y']; break;
      case 'Z': resultGame += me['Z']; break;
      default:
        break;
    }
    resultGame += won;
  }


}


Console.WriteLine(resultGame);
