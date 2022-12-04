<Query Kind="Statements">
  <Reference Relative="03 input.txt">C:\Drive\Challenges\AoC 2022\03 input.txt</Reference>
</Query>

var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split("\r\n");

input = File.ReadAllLines("03 input.txt");

var scores = Enumerable.Range(0, 26).Select(i => ((char)('a' + i), i)) // ('a', 0), ..., ('z', 25)
  .Concat(Enumerable.Range(0, 26).Select(i => ((char)('A' + i), i + 26))) // ('A', 26), ..., ('Z', 51)
  .ToDictionary(x => x.Item1, x => x.Item2 + 1); // ('a', 1), ... ('Z', 52)

var data = from x in input let l = x.Length / 2 select (x.Substring(0, l), x.Substring(l));

data.Sum(x => x.Item1.Intersect(x.Item2).Sum(y => scores[y])).Dump("Answer 1");

input
  .Select((x, i) => (x, i)).GroupBy(x => x.i / 3, x => x.x.AsEnumerable()) // [0..2, 3..5, 6..8, ...]
  .Select(x => x.Aggregate((x, y) => x.Intersect(y)))
  .Sum(x => x.Sum(y => scores[y]))
  .Dump("Answer 2");