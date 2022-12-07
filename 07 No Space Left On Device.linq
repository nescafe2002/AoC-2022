<Query Kind="Statements">
  <Reference Relative="07 input.txt">C:\Drive\Challenges\AoC 2022\07 input.txt</Reference>
</Query>

var input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k".Split("\r\n");

input = File.ReadAllLines("07 input.txt");

var dirs = new Dictionary<string, int>();

var dir = "/";

foreach (var line in input)
{
  if (line.StartsWith("$ cd .."))
  {
    dir = dir.Substring(0, Math.Max(dir.LastIndexOf('/'), 1));
  }
  else if (line.StartsWith("$ cd /"))
  {
    dir = "/";
  }
  else if (line.StartsWith("$ cd "))
  {
    dir = dir.TrimEnd('/') + "/" + line.Substring(5);
  }

  dirs.TryAdd(dir, 0);

  if (!line.StartsWith("$") && !line.StartsWith("dir"))
  {
    dirs[dir] += int.Parse(line.Split(' ', 2)[0]);
  }
}

var cumulative = dirs.Select(x => dirs.Where(y => y.Key.StartsWith(x.Key)).Sum(x => x.Value)).ToArray();

cumulative.Where(x => x <= 100000).Sum().Dump("Answer 1");

var required = 30000000 + dirs.Sum(x => x.Value) - 70000000;

cumulative.OrderBy(x => x).First(x => x >= required).Dump("Answer 2");