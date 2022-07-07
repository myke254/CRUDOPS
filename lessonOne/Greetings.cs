using System.Text.RegularExpressions;
using lessonOne;

public class Greetings : IGreetings
{
    public string? name;
    public int YOB;
    private string? yobString;
    private int today = DateTime.Now.Year;
    private bool isnum;

     MyConstants myConstants = new MyConstants();

    public Greetings(string pName = "", int pYOB = 0, string? pYobstring = "", bool pIsnum = false)
    {
        this.name = pName;
        this.YOB = pYOB;
        this.yobString = pYobstring;
        this.isnum = pIsnum;
    }

    public void GetName()
    {
        Console.WriteLine(myConstants.initialGreeting);
    start:
        name = Console.ReadLine();
        Regex rx = new Regex(@"^[A-Za-z]+$");
        while (!rx.IsMatch(name!)||string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine(myConstants.invalidName);
            goto start;
        }
    }

    public void getYOB(string myName)
    {
        Console.WriteLine(myConstants.AskForYOB(name!));

    start:
        yobString = Console.ReadLine()!;
        isnum = int.TryParse(yobString, out YOB);

        while (!isnum || YOB < 0 || YOB > today || YOB == today)
        {
            Console.WriteLine(myConstants.invalidYear(name!));
            goto start;
        }

        YOB = int.Parse(yobString!);
    }

    public void getAge(int yearOfBirth)
    {

        int age = (today - yearOfBirth);
        string myAge = myConstants.ageMessage(age);
        Console.WriteLine(myConstants.finalMessage(name!,myAge));
    }
}