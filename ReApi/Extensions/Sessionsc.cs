﻿
using ReApi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReApi.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, List<Bookmark> value)
        {
            session.SetString(key, value.ToJson());
        }

        public static List<T> GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(List<T>) : JsonConvert.DeserializeObject<List<T>>(value);
        }
    }

}
