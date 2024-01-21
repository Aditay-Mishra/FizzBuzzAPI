namespace FizzBuzz.Models;

public class InputRequestData(int firstNumber, int secondNumber, int limit, string valueForFirstMultiple, string valueForSecondMultiple)
{

    public int FirstNumber { get; } = firstNumber;

    public int SecondNumber { get; } = secondNumber;

    public int Limit { get; } = limit;

    public string StringToReplaceMultipleOfFirstNumber { get; } = valueForFirstMultiple;

    public string StringToReplaceMultipleOfSecondNumber { get; } = valueForSecondMultiple;

    public int HitCount { get; set; }

    public string GetAsDictKey()
    {
        return FirstNumber + ":" + SecondNumber + ":" + Limit + ":" + StringToReplaceMultipleOfFirstNumber + ":" + StringToReplaceMultipleOfSecondNumber;
    }
}