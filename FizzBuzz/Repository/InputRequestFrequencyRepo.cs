using FizzBuzz.Models;

namespace FizzBuzz.Repository;

public class InputRequestFrequencyRepo : IFrequencyRepo
{
    private static readonly object MAP_LOCK = new();

    private int MaxFrequency { get; set; }

    private InputRequestData? MostFrequentInput { get; set; }

    readonly Dictionary<string, int> InputRequestFrequencyMap;

    public InputRequestFrequencyRepo()
    {
        InputRequestFrequencyMap = [];
        MaxFrequency = -1;
        MostFrequentInput = null;
    }

    public InputRequestData? GetMostFrequentRequest()
    {
        if (MostFrequentInput == null)
        {
            return null;
        }
        InputRequestData curMaxFrequentRequest = MostFrequentInput;
        curMaxFrequentRequest.HitCount = InputRequestFrequencyMap[curMaxFrequentRequest.GetAsDictKey()];
        return curMaxFrequentRequest;
    }

    public void AddRequest(InputRequestData curRequest)
    {
        string key = curRequest.GetAsDictKey();
        if (InputRequestFrequencyMap.Count == 0)
        {
            // synchronize this block
            lock (MAP_LOCK)
            {
                if (InputRequestFrequencyMap.Count == 0)
                {
                    UpdateMostFrequestInput(key, curRequest, 1);
                    return;
                }
            }
        }
        
        if (InputRequestFrequencyMap.TryGetValue(key, out int prevHitCount))
        {
            int curHitCount = prevHitCount + 1;
            if (MaxFrequency < curHitCount)
            { // synchronize this block
                lock (MAP_LOCK)
                {
                    if (MaxFrequency < curHitCount)
                    {
                        UpdateMostFrequestInput(key, curRequest, curHitCount);
                        return;
                    }
                }
            }
        }
        InputRequestFrequencyMap[key] = prevHitCount + 1;
    }

    
    private void UpdateMostFrequestInput(string key, InputRequestData inputRequest, int newFrequency)
    {
        MaxFrequency = newFrequency;
        MostFrequentInput = inputRequest;
        InputRequestFrequencyMap[key] = newFrequency;
    }
}