namespace Tabu.Extensions
{
    public static class IQueryableExtension
    {

        public static IQueryable<T> Random<T>(this IQueryable<T> query, int randomNumber)
        {
            Random random = new Random();
            int num = random.Next(0, randomNumber);
            return query.Skip(num);
        }
    }
}
