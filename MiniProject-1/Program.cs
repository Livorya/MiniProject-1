
//Mini Project #1 - Asset Tracking
//Created by Malin Wirén

using MiniProject_1;

//Global variables
List<Asset> assets = new List<Asset>();


//Main-method
MenuManager.UseStartMenu(assets);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nThank you for using this application!");
Console.ResetColor();