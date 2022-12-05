<Query Kind="Statements">
  <Reference Relative="05 input.txt">C:\Drive\Challenges\AoC 2022\05 input.txt</Reference>
</Query>

var input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".Split("\r\n");

input = File.ReadAllLines("05 input.txt");

var start = Enumerable.Range(0, input.Length).First(x => input[x].StartsWith(" 1   "));

var count = input[start].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Max();

var stacks = Enumerable.Range(0, count).Select(x => new Stack<char>()).ToArray();

for (int i = start - 1; i >= 0; i--)
{
  for (int s = 0; s < count; s++)
  {
    if (input[i][1 + s * 4] is var c && c != ' ')
    {
      stacks[s].Push(c);
    }
  }
}

var re = new Regex(@"move (\d+) from (\d+) to (\d+)");

for (int i = start + 2; i < input.Length; i++)
{
  if (re.Match(input[i]) is var match)
  {
    var move = int.Parse(match.Groups[1].Value);
    var from = int.Parse(match.Groups[2].Value);
    var to = int.Parse(match.Groups[3].Value);

    Enumerable
      .Range(0, move)
      .Select(x => stacks[from - 1].Pop())
      .Reverse() // Enable / disable to switch answer 1/2
      .ToList()
      .ForEach(x => stacks[to - 1].Push(x));
  }
}

new string(stacks.Select(x => x.Pop()).ToArray()).Dump("Answer 1");