using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Utilities
{
    public static class SessionHelper
    {
        //Set
        public static void SetProductJson(this ISession _session, string _key, object _value)//elma, CartItem
        {
            _session.SetString(_key, JsonConvert.SerializeObject(_value));

        }

        //Get
        public static T GetProductFromJson<T>(this ISession session, string key)

        {
            var result = session.GetString(key);

            if (result == null)
            {
                return default(T);
            }
            else
            {

                var des = JsonConvert.DeserializeObject<T>(result);
                return des;
            }



            //return result == null ? default(T) : JsonConvert.DeserializeObject<T>(result);
        }

        //Remove
        public static void RemoveSession(this ISession session , string key)
        {
            session.Remove(key);
        }

    }
}
