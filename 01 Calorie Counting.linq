<Query Kind="Statements">
  <Reference Relative="01 input.txt">C:\Drive\Challenges\AoC 2022\01 input.txt</Reference>
</Query>

var input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Split("\r\n");

input = File.ReadAllLines("01 input.txt").ToArray();

var list = string.Join(',', input).Split(",,").Select(x => x.Split(',').Select(int.Parse).Sum()).OrderByDescending(x => x).Take(3).ToArray();

var top1 = list.Take(1).Sum().Dump("Answer 1");
var top3 = list.Take(3).Sum().Dump("Answer 2");