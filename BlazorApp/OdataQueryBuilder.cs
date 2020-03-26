using System;
using System.Collections.Generic;

namespace BlazorApp
{
    public class OdataQueryBuilder
    {
        public string BaseUrl { get; set; }
        public List<string> Select { get; set; }
        public List<string> Expand { get; set; }
        public (string, string) Filter { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
        public bool Count { get; set; }

        public OdataQueryBuilder(string baseUrl, bool getCount = true, int top = 0, int skip = 0)
        {
            BaseUrl = baseUrl;
            Select = new List<string>();
            Expand = new List<string>();

            Count = getCount;
            Top = top;
            Skip = skip;
        }

        public string BuildUrl()
        {
            var url = BaseUrl;

            url = AddOdataQuerySegment(url, nameof(Select), Select);
            url = AddOdataQuerySegment(url, nameof(Expand), Expand);
            url = AddFilter(url, nameof(Filter), Filter);
            url = AddOdataQuerySegment(url, nameof(Count), Count.ToString());

            if (Top <= 0)
                Top = 10;
            url = AddOdataQuerySegment(url, nameof(Skip), Skip.ToString());
            url = AddOdataQuerySegment(url, nameof(Top), Top.ToString());

            return url.ToLower();
        }

        string AddOdataQuerySegment(string url, string segmentName, string segment)
        {
            if (segment is null || segmentName is null)
                return url;

            var joinChar = GetJoinChar(url);
            return $"{url}{joinChar}${segmentName}={segment}";
        }

        string AddOdataQuerySegment(string url, string sectionName, List<string> segment)
        {
            if (segment is null || segment.Count == 0)
                return url;

            var joinChar =  GetJoinChar(url);
            url = $"{url}{joinChar}${sectionName}=";

            foreach (var item in segment)
                url += $"{item},";

            url = url[0..^1];

            return url;
        }

        string AddFilter(string url, string sectionName, (string key, string value) segment)
        {
            if (string.IsNullOrEmpty(segment.key) || string.IsNullOrEmpty(segment.value))
                return url;

            var joinChar = GetJoinChar(url);

            return $"{url}{joinChar}${sectionName}={segment.key} eq '{segment.value}'";
        }

        Char GetJoinChar(string url) => url.Contains("?") ? '&' : '?';
    }
}
