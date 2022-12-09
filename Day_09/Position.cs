using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022
{
  public class Position
  {
    public int X { get; set; }
    public int Y { get; set; }
    public void Up(int steps = 1)
    {
      Y += steps;
    }
    public void Right(int steps = 1)
    {
      X += steps;
    }
    public void Down(int steps = 1)
    {
      Y -= steps;
    }
    public void Left(int steps = 1)
    {
      X -= steps;
    }

    // -1 +1
    public void ULdiagonal()
    {
      X--;
      Y++;
    }

    // +1 +1
    public void URdiagonal()
    {
      X++;
      Y++;
    }

    // -1 -1
    public void DLdiagonal()
    {
      X--;
      Y--;
    }

    // +1 -1
    public void DRdiagonal()
    {
      X++;
      Y--;
    }

    public bool IsInTheSameColumn(Position p)
    {
      return p.X == X && p.Y != Y;
    }

    public bool IsInTheSameRow(Position p)
    {
      return p.X != X && p.Y == Y;
    }

    public bool IsEqual(Position p)
    {
      return X == p.X && Y == p.Y;
    }

    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }
    public Position()
    {

    }
  }
}
