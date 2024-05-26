using HuntingWords.Enums;
using HuntingWords.Models;

namespace HuntingWords.Services;
public class LetterServices
{
    private readonly Direction[] _directions = new Direction[] { Direction.Top, Direction.Down, Direction.Left, Direction.Right, Direction.DiagonalRightDown, Direction.DiagonalRightTop, Direction.DiagonalLeftDown, Direction.DiagonalLeftTop };
    private readonly ConsoleColor[] _colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.Cyan};
    private void RaffleProperties(int minValue, int maxValue, Letter letter)
    {
        letter.PositionX = new Random().Next(minValue, maxValue);
        letter.PositionY = new Random().Next(minValue, maxValue);
        letter.Direction = _directions[new Random().Next(0, _directions.Length)];
        letter.Color = _colors[new Random().Next(0, _colors.Length)];
    }

    public void Validate(Letter letter, Character[,] board)
    {
        RaffleProperties(0, board.GetLength(0), letter);
    int count = 0;
        while(!letter.IsValid && count <= 10000000)
        {
            count++;
            letter.IsValid = true;
            switch (letter.Direction)
            {
                case Direction.DiagonalRightDown:
                    if(letter.PositionX + letter.Characters.Count - 1 >= board.GetLength(1)
                    || letter.PositionY + letter.Characters.Count - 1 >= board.GetLength(0))
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX + i, letter.PositionY + i] != null
                        && !board[letter.PositionX + i, letter.PositionY + i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX + i, letter.PositionY + i] = letter.Characters[i];
                    }
                break;

                case Direction.Down:
                    if(letter.PositionX + letter.Characters.Count - 1 >= board.GetLength(1))
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX + i, letter.PositionY] != null
                        && !board[letter.PositionX + i, letter.PositionY].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }
                    
                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX + i, letter.PositionY] = letter.Characters[i];
                    }
                break;

                case Direction.Top:
                    if(letter.PositionX - (letter.Characters.Count - 1) < 0)
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX - i, letter.PositionY] != null
                        && !board[letter.PositionX - i, letter.PositionY].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX - i, letter.PositionY] = letter.Characters[i];
                    }
                break;

                case Direction.Right:
                    if(letter.PositionY + letter.Characters.Count - 1 >= board.GetLength(0))
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX, letter.PositionY + i] != null
                        && !board[letter.PositionX, letter.PositionY + i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }
                    
                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX, letter.PositionY + i] = letter.Characters[i];
                    }
                break;

                case Direction.Left:
                    if(letter.PositionY - (letter.Characters.Count - 1) < 0)
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX, letter.PositionY - i] != null
                        && !board[letter.PositionX, letter.PositionY - i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX, letter.PositionY - i] = letter.Characters[i];
                    }
                break;

                case Direction.DiagonalRightTop:
                    if(letter.PositionX - (letter.Characters.Count - 1) < 0
                    || letter.PositionY + letter.Characters.Count - 1 >= board.GetLength(0))
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX - i, letter.PositionY + i] != null
                        && !board[letter.PositionX - i, letter.PositionY + i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX - i, letter.PositionY + i] = letter.Characters[i];
                    }
                break;

                case Direction.DiagonalLeftDown:
                    if(letter.PositionX + letter.Characters.Count - 1 >= board.GetLength(1)
                    || letter.PositionY - (letter.Characters.Count - 1) < 0)
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX + i, letter.PositionY - i] != null
                        && !board[letter.PositionX + i, letter.PositionY - i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;  

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX + i, letter.PositionY - i] = letter.Characters[i];
                    }
                break;

                case Direction.DiagonalLeftTop:
                    if(letter.PositionX - (letter.Characters.Count - 1) < 0
                    || letter.PositionY - (letter.Characters.Count - 1) < 0)
                    {
                        letter.IsValid = false;
                        RaffleProperties(0, board.GetLength(0), letter);
                        continue;
                    }
                    
                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        if(board[letter.PositionX - i, letter.PositionY - i] != null
                        && !board[letter.PositionX - i, letter.PositionY - i].Equals(letter.Characters[i]))
                        {
                            letter.IsValid = false;
                            RaffleProperties(0, board.GetLength(0), letter);
                            break;
                        }
                    }

                    if(!letter.IsValid) continue;

                    for(int i = 0; i < letter.Characters.Count; i++)
                    {
                        letter.Characters[i].Color = letter.Color;
                        board[letter.PositionX - i, letter.PositionY - i] = letter.Characters[i];
                    }
                break;
            }
        }
    }
}