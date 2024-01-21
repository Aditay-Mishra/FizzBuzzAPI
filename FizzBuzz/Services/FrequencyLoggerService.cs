using FizzBuzz.Models;
using FizzBuzz.Repository;

namespace FizzBuzz.Services;

public class FrequencyLoggerService
{
    public static readonly FrequencyLoggerService INSTANCE = new(new InputRequestFrequencyRepo());

    private readonly IFrequencyRepo FrequencyRepository;
    static FrequencyLoggerService()
    {
    }

    private FrequencyLoggerService(IFrequencyRepo frequencyRepository)
    {
        FrequencyRepository = frequencyRepository;
    }

    public void RecordIncomingRequest(InputRequestData curRequest)
    {
        FrequencyRepository.AddRequest(curRequest);
    }

    public InputRequestData? GetMostFrequentRequest()
    {
        return FrequencyRepository.GetMostFrequentRequest();
    }
}