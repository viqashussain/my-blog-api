using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBog.Specs
{
    public class TestContext
    {
        Dictionary<string, object> storedItems = new Dictionary<string, object>();

        public void Remember(string identifier, object objectToRemember)
        {
            if (storedItems.Keys.Any(x => x == identifier))
            {
                storedItems.Remove(identifier);
            }
            storedItems.Add(identifier, objectToRemember);
        }

        public T Recall<T>(string identifier) where T : class
        {
            var storedItem = storedItems.SingleOrDefault(x => x.Key == identifier).Value;
            return storedItem as T;
        }

        public string ThrownException;
    }
}
