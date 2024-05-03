namespace WebSudoku.Shared.Extensions
{
    public static class ListExtensions
    {
        public static T PopRandomElement<T>(this List<T> list, Random? random = null)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (random == null)
            {
                random = Random.Shared;
            }

            var index = random.Next(list.Count);
            var selectedElement = list[index];
            list.RemoveAt(index);
            return selectedElement;
        }
    }
}
