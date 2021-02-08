﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComicStore.Shared.Classes
{
    public static class Utils
    {
        private static readonly Random random = new Random();
        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public static async Task<byte[]> GetImageBytesFromUrl(string imageUrl)
        {
            byte[] imageBytes;
            using (HttpClient http = new HttpClient())
            {
                using (Stream stream = await http.GetStreamAsync(imageUrl))
                {
                    imageBytes = stream.ReadFully();
                }
            }

            return imageBytes;
        }

        public static byte[] ReadFully(this Stream input)
        {
            var ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }

        public static void Repeat(this int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }

        public static IList<T> GetRandomElements<T>(this IList<T> sourceList, int quantity = 1)
        {
            var list = new List<T>();

            quantity.Repeat(() => list.Add(PickRandom(sourceList)));
            return list;
        }

        public static T GetRandomElement<T>(this IList<T> sourceList)
        {
            var element = PickRandom(sourceList);
            return element;
        }

        public static T PickRandom<T>(IList<T> list)
        {
            T randomElement = list[random.Next(list.Count)];
            return randomElement;
        }
    }
}
