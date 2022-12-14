using AOC_2022;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
List<Monkey> monkeyList = new List<Monkey>();
long total = 1;

void SolutionPart1()
{
  for (int i = 0; i < monkeyList.Count; i++)
  {
    for (int j = 0; j < monkeyList[i].StartingItems.Count; j++)
    {
      monkeyList[i].InspectsItems++;
      long worryLevel = monkeyList[i].StartingItems[j];
      if (monkeyList[i].Operation == "+")
      {
        if (monkeyList[i].OperationNumber == -1)
          worryLevel += worryLevel;
        else
          worryLevel += monkeyList[i].OperationNumber;
      }
      else
      {
        if (monkeyList[i].OperationNumber == -1)
          worryLevel *= worryLevel;
        else
          worryLevel *= monkeyList[i].OperationNumber;
      }
      int throwTo = 0;
      worryLevel = worryLevel % total;
      if (worryLevel % monkeyList[i].DivisibleNr == 0)
        throwTo = monkeyList[i].ThrowToMonkey1True;
      else
        throwTo = monkeyList[i].ThrowToMonkey2False;
      monkeyList[i].StartingItems.Remove(monkeyList[i].StartingItems[j]);
      monkeyList[throwTo].StartingItems.Add(worryLevel);
      j--;
    }
  }
}

void Print()
{
  foreach (var m in monkeyList)
  {
    Console.WriteLine("-----{0}------", m.Id);
    Console.WriteLine(m.InspectsItems);
    //m.PrintStartingItems();
  }
}

void PrintResultPart1()
{
  List<long> Result = new List<long>();
  foreach (var m in monkeyList)
  {
    Result.Add(m.InspectsItems);
  }
  Result.Sort();
  Result.Reverse();
  Console.WriteLine(Result[0] * Result[1]);
}

long z = 0;
while (z < lines.Length)
{
  Monkey monkey = new Monkey(lines[z], lines[z + 1], lines[z + 2],
    lines[z + 3], lines[z + 4], lines[z + 5]);
  total *= monkey.DivisibleNr;
  monkeyList.Add(monkey);
  z += 7;
}
for (int k = 0; k < 10000; k++)
{
  SolutionPart1();
}

PrintResultPart1();
