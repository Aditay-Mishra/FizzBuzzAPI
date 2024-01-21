using FizzBuzz.Models;

namespace FizzBuzz.Repository;

interface IFrequencyRepo
{
    public void AddRequest(InputRequestData curRequest);

    public InputRequestData? GetMostFrequentRequest();
}