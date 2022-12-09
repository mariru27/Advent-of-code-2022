// See https://aka.ms/new-console-template for more information

using AOC_2022;
//to high 6279
const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
List<Position> tails = new List<Position>();
Position headPosition = new Position(0, 0);
Position lastheadPosition = new Position(0, 0);
Position tailPosition = new Position(0, 0);
tails.Add(new Position(tailPosition.X, tailPosition.Y));

int totalTailSteps = 0;

bool IsNotInTheSameRowOrColumnAndNotTouching()
{
  return !IsTouching() && !(tailPosition.IsInTheSameColumn(headPosition) || tailPosition.IsInTheSameRow(headPosition));
}

bool IsTouching()
{
  if (headPosition.IsEqual(tailPosition))
    return true;

  //diagonally touching
  if ((tailPosition.X - 1 == headPosition.X && tailPosition.Y + 1 == headPosition.Y) ||
     (tailPosition.X - 1 == headPosition.X && tailPosition.Y - 1 == headPosition.Y) ||
     (tailPosition.X + 1 == headPosition.X && tailPosition.Y + 1 == headPosition.Y) ||
     (tailPosition.X + 1 == headPosition.X && tailPosition.Y - 1 == headPosition.Y))
    return true;

  if ((tailPosition.X == headPosition.X && tailPosition.Y + 1 == headPosition.Y) ||
     (tailPosition.X == headPosition.X && tailPosition.Y - 1 == headPosition.Y) ||
     (tailPosition.X == headPosition.X + 1 && tailPosition.Y == headPosition.Y) ||
     (tailPosition.X == headPosition.X - 1 && tailPosition.Y == headPosition.Y))
    return true;
  return false;
}

bool MoveUp()
{
  return tailPosition.X == lastheadPosition.X && tailPosition.Y + 1 == lastheadPosition.Y;
}
bool MoveRight()
{
  return tailPosition.X + 1 == lastheadPosition.X && tailPosition.Y == lastheadPosition.Y;
}
bool MoveDown()
{
  return tailPosition.X == lastheadPosition.X && tailPosition.Y - 1 == lastheadPosition.Y;
}
bool MoveLeft()
{
  return tailPosition.X - 1 == lastheadPosition.X && tailPosition.Y == lastheadPosition.Y;
}

void MoveHeadPosition(string move)
{
  lastheadPosition = new Position(headPosition.X, headPosition.Y);
  switch (move)
  {
    case "U":
      headPosition.Up();
      break;
    case "R":
      headPosition.Right();
      break;
    case "L":
      headPosition.Left();
      break;
    case "D":
      headPosition.Down();
      break;
    default:
      break;
  }
}


void MoveToLastHeadPosition()
{
  if (MoveDown())
    tailPosition.Down();
  if (MoveLeft())
    tailPosition.Left();
  if (MoveRight())
    tailPosition.Right();
  if (MoveUp())
    tailPosition.Up();
}

void AddUniqueTail()
{
  var t = tails.Where(a => a.X == tailPosition.X && a.Y == tailPosition.Y).SingleOrDefault();

  if (t == null)
    tails.Add(new Position(tailPosition.X, tailPosition.Y));
}

void MoveTailPosition(string move)
{
  switch (move)
  {
    case "U":
      if (!IsTouching())
      {
        if (IsNotInTheSameRowOrColumnAndNotTouching())
        {
          tailPosition.Up();
          MoveToLastHeadPosition();
        }
        else
          tailPosition.Up();
        totalTailSteps++;
        AddUniqueTail();
      }
      break;
    case "R":
      if (!IsTouching())
      {
        if (IsNotInTheSameRowOrColumnAndNotTouching())
        {
          tailPosition.Right();
          MoveToLastHeadPosition();
        }
        else
          tailPosition.Right();
        totalTailSteps++;
        AddUniqueTail();
      }
      break;
    case "L":
      if (!IsTouching())
      {
        if (IsNotInTheSameRowOrColumnAndNotTouching())
        {
          tailPosition.Left();
          MoveToLastHeadPosition();
        }
        else
          tailPosition.Left();
        totalTailSteps++;
        AddUniqueTail();
      }
      break;
    case "D":
      if (!IsTouching())
      {
        if (IsNotInTheSameRowOrColumnAndNotTouching())
        {
          tailPosition.Down();
          MoveToLastHeadPosition();
        }
        else
          tailPosition.Down();
        totalTailSteps++;
        AddUniqueTail();
      }
      break;
    default:
      break;
  }
}


foreach (var line in lines)
{
  var result = line.Split(" ");
  //Console.WriteLine("-----{0}----", result[0]);
  for (int i = 0; i < int.Parse(result[1]); i++)
  {
    MoveHeadPosition(result[0]);
    MoveTailPosition(result[0]);
  //  Console.WriteLine("tail -> X: {0}, Y: {1} |  head -> X: {2}, Y: {3}",
  //tailPosition.X, tailPosition.Y, headPosition.X, headPosition.Y);
  }
}
Console.WriteLine(tails.Count);