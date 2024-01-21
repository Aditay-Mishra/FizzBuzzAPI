namespace FizzBuzz.Utility;

public class FizzBuzzLogic
{
    public static string GenerateFizzBuzzString(int firstNumber, int secondNumber, int limit, string stringToReplaceMultipleOfFirstNumber, string stringToReplaceMultipleOfSecondNumber)
    {
        int firstInterval = firstNumber;
        int secondInterval = secondNumber;
        string output = "";
        string stringValueForBoth = stringToReplaceMultipleOfFirstNumber + stringToReplaceMultipleOfSecondNumber;
        for (int i = 1; i <= limit; i++)
        {
            if (i > 1 && i <= limit)
            {
                output += ',';
            }
            firstInterval--;
            secondInterval--;
            // Console.WriteLine("i=" + i + ", finterval=" + firstInterval + ", sinterval=" + secondInterval);
            if (firstInterval == 0 && secondInterval == 0)
            {
                output += stringValueForBoth;
                firstInterval = firstNumber;
                secondInterval = secondNumber;
            }
            else if (firstInterval == 0)
            {
                output += stringToReplaceMultipleOfFirstNumber;
                firstInterval = firstNumber;
            }
            else if (secondInterval == 0)
            {
                output += stringToReplaceMultipleOfSecondNumber;
                secondInterval = secondNumber;
            }
            else
            {
                output += i;
            }
        }
        return output;
    }
}