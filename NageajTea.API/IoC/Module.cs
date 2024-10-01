namespace NageajTea.API.IoC
{
    public static class Module
    {
        public static List<Type> GetSingleTypes()
        {
            var result = new List<Type>();
            return result;
        }

        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            return dic;
        }
    }
}
