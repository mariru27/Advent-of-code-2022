const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
int X = 1;
int cycle = 1;
char[] screen = new char[500];

List<int> SignalS = new List<int>();
void KeppSignalStrength()
{
  if (cycle >= 20)
  {
    if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140
      || cycle == 180 || cycle == 220)
    {
      SignalS.Add(X * cycle);
    }
  }

}

bool Intersects()
{
  if(cycle == X || cycle == X-1 || cycle == X+1)
  {
    return true;
  }
  return false;
}

void Draw()
{
  if(Intersects())
  {
    screen[cycle] = '#';
    Console.WriteLine("x: {0}, cycle: {1}  #",X, cycle);
  }
  else
  {
    screen[cycle] = '.';
    Console.WriteLine("x: {0}, cycle: {1}  .",X, cycle);
  }
}

void SolutionPart1(string line)
{
    Draw();
  KeppSignalStrength();
  if (line == "noop")
  {
    cycle++;
  }
  else
  {
    var result = line.Split(' ');
    cycle++;
    KeppSignalStrength();
    Draw();
    cycle++;
    X += int.Parse(result[1]);
  }
  //Console.WriteLine("x: {0}, c: {1}", X, cycle);
}

foreach (var line in lines)
{
  SolutionPart1(line);
}

for (int i = 0; i < cycle; i++)
{
  Console.Write(screen[i]);
  if(i % 40 == 0)
    Console.WriteLine();
}

int total = SignalS.Sum(x => x);

Console.WriteLine(total);
