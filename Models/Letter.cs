using HuntingWords.Enums;

namespace HuntingWords.Models;
public class Letter
{
    public string? Name { get; set; }
    public bool IsValid { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set;}
    public Direction Direction { get; set; }
    public ConsoleColor Color { get; set; }
    public List<Character> Characters { get; set; } = new List<Character>();

    public Letter(string stringLetter)
    {
        Name = stringLetter;

        foreach(char character in stringLetter)
        {
            Characters.Add(new Character(character));
        }
    }
}