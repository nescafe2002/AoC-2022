<Query Kind="Statements">
  <Reference Relative="10 input.txt">C:\Drive\Challenges\AoC 2022\10 input.txt</Reference>
</Query>

var input = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop".Split("\r\n");

input = File.ReadAllLines("10 input.txt");

var cycle = 0;
var X = 1;
var strength = 0;
var row = "";
var rows = new List<string>();

void Cycle()
{
  if ((row += cycle % 40 is var pos && X - 1 <= pos && pos <= X + 1 ? '#' : '.').Length == 40)
  {
    rows.Add(row);
    row = "";
  }

  if ((++cycle - 20) % 40 == 0)
  {
    strength += cycle * X;
  }
}

foreach (var line in input)
{
  Cycle();

  if (line.Split(' ') is var parts && parts[0] is var op)
  {
    switch (op)
    {
      case "noop":
        break;
      case "addx":
        Cycle();

        X += int.Parse(parts[1]);
        break;
      default:
        throw new NotSupportedException($"Not supported: {op}");
    }
  }
}

strength.Dump("Answer 1");

Util.WithStyle(string.Join("\r\n", rows), "font-family: Consolas;").Dump("Answer 2");
