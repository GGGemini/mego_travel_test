namespace MegoTravelTest.Helpers;

public static class RandomHelper
{
    public static int GetRandomNumber(int min, int max)
    {
        if (min > max)
            throw new Exception("MinValue more than MaxValue");
        
        return new Random().Next(min, max);
    }

    public static bool GetRandomBool()
    {
        return new Random().NextDouble() >= 0.5;
    }
}