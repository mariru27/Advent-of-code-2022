// See https://aka.ms/new-console-template for more information

using AOC_2022;

const string inputPath = @"C:\Users\Marina Rusu\source\repos\AOC-2022\AOC-2022\input.txt";
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
      sum += currentItem.Size;
      var z = filesystem.Where(a => a.Key.Name == currentItem.Name).FirstOrDefault();
      if (z.Value != null)
      {
        foreach (var item in z.Value)
        {
          if (!Visited.Contains(item))
            stack.Push(item);
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
        rootItem = new Item(name, ItemType.DIR, 0);
        break;
      }
      if (name == "..")
      {
        //moves out one level
        foreach (var isItem in filesystem)
        {
          if (isItem.Value.Where(a => a.Name == rootItem.Name).Any())
            rootItem = isItem.Key;
        }
        break;
      }
      rootItem = new Item(name, ItemType.DIR, 0);
      //rememberDirOrder.Add(rootItem);
      break;
    case Command.LS:
      //add items
      if (!filesystem.ContainsKey(rootItem))
      {
        filesystem.Add(rootItem, new List<Item>());
        filesystem[rootItem].Add(new Item(aStringItem));
      }
      else
      {
        filesystem[rootItem].Add(new Item(aStringItem));
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


void solutionPart1()
{
  long sum = 0;
  foreach (var item in filesystem)
  {
    if (item.Key.Size <= 100000)
      sum += item.Key.Size;
    //Console.WriteLine(item.Key.Size);
  }
  Console.WriteLine(sum);
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
solutionPart1();