namespace aznews.Utilities
{


    public class Function
    {

        public static string titleRoute(string type, string title, long? id)
        {
            return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id + ".html";
        }
    }
}