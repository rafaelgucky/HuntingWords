using System.Text;
using HuntingWords.Models;
using HuntingWords.Services;


char[] alpha = new char[27] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ç'};
LetterServices letterServices = new LetterServices();

Console.Write("Size: ");
int size = int.Parse(Console.ReadLine()!);

Character[,] board = new Character[size, size];

Console.InputEncoding = Encoding.Unicode;

List<Letter> letters = new List<Letter>();

char response = 's';
while(response == 's')
{
    Console.Write("Letter: ");
    string? letter = Console.ReadLine();
    while(string.IsNullOrEmpty(letter) || letter?.Length > board.GetLength(0))
    {
        Console.Write("Letter: ");
        letter = Console.ReadLine();
    }
    letters.Add(new Letter(letter!));
    Console.Write("Add a new letter? [s/n]");
    response = char.Parse(Console.ReadLine()!.ToLower());
}

letters = letters.OrderByDescending(letter => letter.Characters.Count).ToList();

for(int i = 0; i < letters.Count; i++)
{
    Console.Clear();
    letterServices.Validate(letters[i], board);
    Console.WriteLine((i + 1) * (100 / letters.Count) + "%");
}

Console.Clear();

for (int i = 0; i < board.GetLength(0); i++)
{
    for(int y = 0; y < board.GetLength(1); y++)
    {
        if(board[i, y] == null)
        {
            Console.Write(alpha[new Random().Next(0, 27)] + "  ");
            continue;
        }
        Console.ForegroundColor = board[i, y].Color;
        Console.Write(board[i, y].Code.ToString()!.ToUpper() + "  ");
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.WriteLine();
}

