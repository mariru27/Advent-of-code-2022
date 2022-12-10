const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
int X = 1;
int cycle = 1;

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

void SolutionPart1(string line)
{
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
		cycle++;
		X += int.Parse(result[1]);
	}
	//Console.WriteLine("x: {0}, c: {1}", X, cycle);
}

foreach (var line in lines)
{
	SolutionPart1(line);
}
int total = SignalS.Sum(x => x);

Console.WriteLine(total);
