<Query Kind="Statements">
  <Reference Relative="04 input.txt">C:\Drive\Challenges\AoC 2022\04 input.txt</Reference>
</Query>

var input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8".Split("\r\n");

input = File.ReadAllLines("04 input.txt");

var data =
  input
    .Select(x => x.Split(',')
      .Select(y => y.Split('-').Select(int.Parse).ToArray())
      .Select(z => (Start: z[0], End: z[1]))
      .ToArray())
    .Select(x => (First: x[0], Second: x[1]))
    .ToArray();

// Full overlap
data.Count(x => (x.First.Start <= x.Second.Start && x.First.End >= x.Second.End)
             || (x.First.Start >= x.Second.Start && x.First.End <= x.Second.End)).Dump("Answer 1");

// Overlap
data.Count(x => (x.First.Start <= x.Second.End && x.Second.Start <= x.First.End)).Dump("Answer 2");
