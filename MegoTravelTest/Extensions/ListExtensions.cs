namespace MegoTravelTest.Extensions;

public static class ListExtensions
{
    public static void SafeAdd<T>(this List<T> list, T item)
    {
        if (item != null)
            list.Add(item);
    }
}