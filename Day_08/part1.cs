using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";

string[] lines = File.ReadAllLines(inputPath);

int[,] forest = new int[100,100];
int i = 0, j = 0;

bool IsVisibleTop(int x, int y)
{
	for (int z = 0; z < x; z++)
	{
		if (forest[z,y] >= forest[x,y])
		{
      return false;
		}
	}
	return true;
}

bool IsVisibleBottom(int x, int y)
{
  for (int z = i - 1; z > x; z--)
  {
    if (forest[z, y] >= forest[x, y])
    {
      return false;
    }
  }
  return true;
}

bool IsVisibleRight(int x, int y)
{
  for (int z = j - 1; z > y; z--)
  {
    if (forest[x , z] >= forest[x, y])
    {
      return false;
    }
  }
  return true;
}

bool IsVisibleLeft(int x, int y)
{
  for (int z = 0; z < y; z++)
  {
    if (forest[x, z] >= forest[x, y])
    {
      return false;
    }
  }
  return true;
}

void SolutionPart1()
{
	int visible = 0;
	for (int ia = 0; ia < i; ia++)
	{
		for (int ja = 0; ja < j; ja++)
		{

      var t1 = IsVisibleTop(ia, ja);
      var t2 = IsVisibleBottom(ia, ja);
      var t3 = IsVisibleLeft(ia, ja);
      var t4 = IsVisibleRight(ia, ja);
      if (t1 || t2 || t3 || t4)
      {
        visible++;
      }
		}
	}
  Console.WriteLine(visible);
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