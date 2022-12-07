using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022
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
    private ItemType GetItemType(string aItem)
    {
      if (aItem.Contains("dir"))
        return ItemType.DIR;
      return ItemType.FILE;
    }
    public void print()
    {
      Console.WriteLine("Name: {0}, ItemType: {1}, Size: {2}", 
        Name, ItemTypeResult, Size);
    }
    public Item(string aName, ItemType aItemType, int aSize)
    {
      Name = aName;
      ItemTypeResult = aItemType;
      Size = aSize;
    }
    public Item(string aItemString)
    {
      ItemTypeResult = GetItemType(aItemString);
      var result = aItemString.Split(" ");
      if(ItemTypeResult == ItemType.DIR)
      {
        Size = 0;
        Name = result[1];
      }else
      {
        Size = long.Parse(result[0]);
        Name = result[1];
      }
    }
    public Item() { }
  }
}
