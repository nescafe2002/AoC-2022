<Query Kind="Statements">
  <Reference Relative="02 input.txt">C:\Drive\Challenges\AoC 2022\02 input.txt</Reference>
</Query>

var input = @"A Y
B X
C Z".Split("\r\n").ToArray();

input = File.ReadAllLines("02 input.txt");

var data = input.Select(x => (A: x[0] - 'A', B: x[2] - 'X'));

int Score(int a, int b) => 1 + b + ((b - a + 4) % 3) * 3;

data.Sum(x => Score(x.A, x.B)).Dump("Answer 1");

int Shape(int a, int b) => (a + b + 2) % 3;

data.Sum(x => Score(x.A, Shape(x.A, x.B))).Dump("Answer 2");