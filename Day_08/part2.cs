using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);

int[,] forest = new int[100,100];
int i = 0, j = 0;

int IsVisibleTop(int x, int y)
{
  int blocked = 0;
	for (int z = x - 1; z > 0; z--)
	{
    blocked++;
		if (forest[z,y] >= forest[x,y])
		{
      return blocked;
		}
	}
  return x;
}

int IsVisibleBottom(int x, int y)
{
  int blocked = 0;
  for (int z = x + 1; z < i; z++)
  {
    blocked++;
    if (forest[z, y] >= forest[x, y])
    {
      return blocked;
    }
  }
  return i - x - 1;
}

int IsVisibleRight(int x, int y)
{
  int blocked = 0;
  for (int z = y + 1; z < i; z++)
  {
    blocked++;
    if (forest[x , z] >= forest[x, y])
    {
      return blocked;
    }
  }
  return j - y - 1;
}

int IsVisibleLeft(int x, int y)
{
  int blocked = 0;
  for (int z = y - 1; z > 0; z--)
  {
    blocked++;
    if (forest[x, z] >= forest[x, y])
    {
      return blocked;
    }
  }
  return y;
}

void SolutionPart1()
{
	int visible = 0;
  int maxScore = 0;
	for (int ia = 0; ia < i; ia++)
	{
		for (int ja = 0; ja < j; ja++)
		{
      var t1 = IsVisibleTop(ia, ja);
      var t2 = IsVisibleBottom(ia, ja);
      var t3 = IsVisibleLeft(ia, ja);
      var t4 = IsVisibleRight(ia, ja);
      visible = t1 * t2 * t3 * t4;
      maxScore = Math.Max(visible, maxScore);
		}
	}
  Console.WriteLine(maxScore);
}

foreach (var line in lines)
{
	j = 0;
	foreach (var l in line)
	{
		int temp = l - '0';
		forest[i,j] = temp;
		j++;
	}
	i++;
}

SolutionPart1();


Console.WriteLine();