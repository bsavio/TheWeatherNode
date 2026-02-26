namespace TheWeatherNode.Core.Web
{
    public static class HttpQueryBuilder
    {
        public static string BuildQueryString(Dictionary<string, object> parameters)
        {
            var queryParts = new List<string>();

            foreach (var kvp in parameters)
            {
                if (kvp.Value is List<string> list)
                {
                    queryParts.Add($"{kvp.Key}={string.Join(",", list)}");
                }
                else
                {
                    queryParts.Add($"{kvp.Key}={kvp.Value}");
                }
            }

            return string.Join("&", queryParts);
        }
    }
}
