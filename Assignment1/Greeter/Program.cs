using System;

var fullName = "Ashmita ";
Console.WriteLine(fullName);

// Name to upper Case
var cFullName = fullName.ToUpper();
Console.WriteLine($"Hello,{cFullName}!");

//Ask user to enter the name
Console.WriteLine("Please enter your full name:");
string FullName = Console.ReadLine();
Console.WriteLine($"Hello, {FullName}");


CalculateAge a = new();
a.Age();
