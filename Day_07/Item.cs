using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
  public enum ItemType
  {
    FILE,
    DIR
  }

  public enum Command
  {
    CD,
    LS
  }

  public class Item
  {
    public string Name { get; set; }
    public ItemType ItemTypeResult { get; set; }
    public long Size { get; set; } = 0;
    public string AbsolutePath { get; set; } = string.Empty;
    private ItemType GetItemType(string aItem)
    {
      if (aItem.Contains("dir"))
        return ItemType.DIR;
      return ItemType.FILE;
    }
    public void print()
    {
      Console.WriteLine("Name: {0}, ItemType: {1}, Size: {2}, Path: {3}",
        Name, ItemTypeResult, Size, AbsolutePath);
    }
    public Item(string aName, ItemType aItemType, int aSize, string aAbsolutePath)
    {
      Name = aName;
      ItemTypeResult = aItemType;
      Size = aSize;
      AbsolutePath = aAbsolutePath + "/" + Name;
    }
    public Item(string aItemString, string aAbsolutePath)
    {
      ItemTypeResult = GetItemType(aItemString);
      var result = aItemString.Split(" ");
      if (ItemTypeResult == ItemType.DIR)
      {
        Size = 0;
        Name = result[1];
        AbsolutePath += aAbsolutePath + "/" + Name;
      }
      else
      {
        Size = long.Parse(result[0]);
        Name = result[1];
        AbsolutePath += aAbsolutePath + "/" + Name;
      }
    }
    public Item() { }
  }
}
