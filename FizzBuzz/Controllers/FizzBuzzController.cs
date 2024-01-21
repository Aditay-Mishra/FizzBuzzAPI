using FizzBuzz.Models;
using FizzBuzz.Services;
using FizzBuzz.Utility;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers;

[ApiController]
[Route("[controller]")]
public class FizzBuzzController : ControllerBase
{
    public FizzBuzzController()
    {

    }

    [HttpGet("convertToFizzBuzz")]
    public ActionResult<string> ConvertToFizzBuzz(int firstNumber, int secondNumber, int limit, string stringToReplaceMultipleOfFirstNumber, string stringToReplaceMultipleOfSecondNumber)
    {
        if (limit < 1 || firstNumber < 1 || secondNumber < 1) {
            return BadRequest("any number < 1 is not allowed");
        }
        string output = FizzBuzzLogic.GenerateFizzBuzzString(firstNumber, secondNumber, limit, stringToReplaceMultipleOfFirstNumber, stringToReplaceMultipleOfSecondNumber);
        FrequencyLoggerService.INSTANCE.RecordIncomingRequest(
            new InputRequestData(firstNumber, secondNumber, limit, stringToReplaceMultipleOfFirstNumber, stringToReplaceMultipleOfSecondNumber));
        return output;
    }

    [HttpGet("mostFrequentRequest")]
    public ActionResult<InputRequestData> GetMostFrequentRequest()
    {
        InputRequestData? mostFrequentRequest = FrequencyLoggerService.INSTANCE.GetMostFrequentRequest();
        if (mostFrequentRequest == null)
        {
            return Ok("No request logged yet!");
        }
        return mostFrequentRequest;
    }
}