<Query Kind="Statements">
  <Reference Relative="06 input.txt">C:\Drive\Challenges\AoC 2022\06 input.txt</Reference>
</Query>

var input = "bvwbjplbgvbhsrlpgdmjqwftvncz";

input = File.ReadAllText("06 input.txt");

int Unique(int count) => Enumerable.Range(0, input.Length).First(x => input.Skip(x - count).Take(count).Distinct().Count() == count);

Unique(4).Dump("Answer 1");
Unique(14).Dump("Answer 2");
