// See https://aka.ms/new-console-template for more information

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";

int incNr = 0;
string[] lines = File.ReadAllLines(inputPath);
int sum = 0;
int maxsum = 0;
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
  char iRock = ' ';
  char iPaper = ' ';
  char iScissors = ' ';

  if (line[2] == 'X')
  {
    //i need to lose
    if (line[0] == 'A')
      iScissors = 'Z';
    if (line[0] == 'B')
      iRock = 'X';
    if (line[0] == 'C')
      iPaper = 'Y';
  }

  if (line[2] == 'Y')
  {
    //draw
    if (line[0] == 'A')
      iRock = 'X';
    if (line[0] == 'B')
      iPaper = 'Y';
    if (line[0] == 'C')
      iScissors = 'Z';
  }

  if (line[2] == 'Z')
  {
    //i need to won
    if (line[0] == 'A')
      iPaper = 'Y';
    if (line[0] == 'B')
      iScissors = 'Z';
    if (line[0] == 'C')
      iRock = 'X';
  }

  if ((iRock == 'X' && line[0] == 'A') || (line[2] == 'Y' && line[0] == 'B')
  || (iScissors == 'Z' && line[0] == 'C'))
  {
    char iChoose = ' ';
    if (iRock != ' ')
      iChoose = iRock;
    if (iScissors != ' ')
      iChoose = iScissors;
    if (iPaper != ' ')
      iChoose = iPaper;

    switch (iChoose)
    {
      case 'X': if (iRock != ' ') resultGame += me['X']; break;
      case 'Y': if (iPaper != ' ')  resultGame += me['Y']; break;
      case 'Z': if (iScissors != ' ')  resultGame += me['Z']; break;
      default:
        break;
    }
    resultGame += draw;
  }

  if ((line[0] == 'C' && iPaper == 'Y') || (line[0] == 'B' && iRock == 'X') ||
    (line[0] == 'A' && iScissors == 'Z'))
  {
    char iChoose = ' ';
    if (iRock != ' ')
      iChoose = iRock;
    if (iScissors != ' ')
      iChoose = iScissors;
    if (iPaper != ' ')
      iChoose = iPaper;

    switch (iChoose)
    {
      case 'X': if (iRock != ' ')  resultGame += me['X']; break;
      case 'Y': if (iPaper != ' ')  resultGame += me['Y']; break;
      case 'Z': if (iScissors != ' ')  resultGame += me['Z']; break;
      default:
        break;
    }
  }


  if ((line[0] == 'B' && iScissors == 'Z') || (line[0] == 'A' && iPaper == 'Y') ||
    (line[0] == 'C' && iRock == 'X'))
  {
    char iChoose = ' ';
    if (iRock != ' ')
      iChoose = iRock;
    if (iScissors != ' ')
      iChoose = iScissors;
    if (iPaper != ' ')
      iChoose = iPaper;

    switch (iChoose)
    {
      case 'X': if (iRock != ' ') resultGame += me['X']; break;
      case 'Y': if (iPaper != ' ') resultGame += me['Y']; break;
      case 'Z': if (iScissors != ' ') resultGame += me['Z']; break;
      default:
        break;
    }
    resultGame += won;
  }


}


Console.WriteLine(resultGame);
