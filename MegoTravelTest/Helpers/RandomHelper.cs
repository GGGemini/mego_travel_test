namespace MegoTravelTest.Helpers;

public static class RandomHelper
{
    public static int GetRandomNumber(int min, int max)
    {
        return new Random().Next(min, max);
    }

    public static bool GetRandomBool()
    {
        return new Random().NextDouble() >= 0.5;
    }
}