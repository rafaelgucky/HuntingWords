using HuntingWords.Enums;

namespace HuntingWords.Models;
public class Character
{
    public char? Code { get; set;}
    public ConsoleColor Color { get; set;} = ConsoleColor.White;

    public Character(char code)
    {
        Code = code;
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if(!(obj is Character))
        {
            return false;
        }
        var c2 = obj as Character;
        return Code.ToString()!.ToUpper() == c2!.Code.ToString()!.ToUpper();
    }
}