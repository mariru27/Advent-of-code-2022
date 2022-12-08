using aoc_2022;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

const string inputPath = @"C:\Users\Marina\source\repos\aoc-2022\aoc-2022\input.txt";
string[] lines = File.ReadAllLines(inputPath);
Dictionary<Item, List<Item>> filesystem = new Dictionary<Item, List<Item>>();
List<Item> rememberDirOrder = new List<Item>();
Item rootItem = new();
Command rememberCommand = Command.CD;
//97602
//578621
bool IsCommand(string aCommand)
{
  return aCommand[0] == '$';
}

Command GetCommand(string aCommand)
{
  if (aCommand.Contains("$ ls"))
    return Command.LS;
  return Command.CD;
}

void UpdateTotalSizeForDirectories()
{
  foreach (var itemNeedSum in filesystem)
  {
    Stack<Item> stack = new Stack<Item>();
    List<Item> Visited = new();

    Item currentItem = itemNeedSum.Key;
    Visited.Add(currentItem);
    stack.Push(currentItem);
    long sum = 0;
    while (stack.Any())
    {
      currentItem = stack.Pop();
      Visited.Add(currentItem);
      var z = filesystem.Where(a => a.Key.AbsolutePath == currentItem.AbsolutePath).FirstOrDefault();
      if (z.Value != null)
      {
        foreach (var item in z.Value)
        {
          if (!Visited.Contains(item) && item.ItemTypeResult == ItemType.DIR)
            stack.Push(item);
          sum += item.Size;
        }
      }
    }
    itemNeedSum.Key.Size += sum;
  }
}

void AddNode(Command aLastCommand, string aStringItem)
{
  switch (aLastCommand)
  {
    case Command.CD:
      //change root item
      string name = aStringItem.Split(" ")[2];
      if (name == "/")
      {
        rootItem = new Item(name, ItemType.DIR, 0, "");
        break;
      }
      if (name == "..")
      {
        //moves out one level
        foreach (var isItem in filesystem)
        {
          if (isItem.Value.Where(a => a.AbsolutePath == rootItem.AbsolutePath).Any())
            rootItem = isItem.Key;
        }
        break;
      }
      rootItem = new Item(name, ItemType.DIR, 0, rootItem.AbsolutePath);
      //rememberDirOrder.Add(rootItem);
      break;
    case Command.LS:
      //add items
      if (!filesystem.ContainsKey(rootItem))
      {
        filesystem.Add(rootItem, new List<Item>());
        filesystem[rootItem].Add(new Item(aStringItem, rootItem.AbsolutePath));
      }
      else
      {
        filesystem[rootItem].Add(new Item(aStringItem, rootItem.AbsolutePath));
      }
      break;
    default:
      break;
  }
}

void DisplayFileSystem()
{

  foreach (var item in filesystem)
  {
    item.Key.print();
    Console.WriteLine("Start:");
    foreach (var i in item.Value)
    {
      i.print();
    }
    Console.WriteLine("End:");
  }
}


void solutionPart2()
{
  var firstDir = filesystem.Where(a => a.Key.AbsolutePath == "//").FirstOrDefault();
  long unusedSpace = 70000000 - firstDir.Key.Size;
  long spaceYouNeed = 30000000 - unusedSpace;
  List<long> itemsSize = new List<long>();
  long dirToDelete = 0;
  foreach (var item in filesystem)
  {
    if(item.Key.Size >= spaceYouNeed)
    {
      itemsSize.Add(item.Key.Size);
    }
  }
  itemsSize.Sort();
  Console.WriteLine(itemsSize.First());
}

//create file system
foreach (string line in lines)
{
  if (IsCommand(line))
  {
    rememberCommand = GetCommand(line);
    if (rememberCommand == Command.CD)
    {
      //change root item 
      AddNode(rememberCommand, line);
    }
    continue;
  }
  else
  {
    AddNode(rememberCommand, line);
  }
}

//DisplayFileSystem();
//Console.WriteLine("-----------update size-----------");
//determine the total size of each directory

//DisplayFileSystem();
UpdateTotalSizeForDirectories();
solutionPart2();