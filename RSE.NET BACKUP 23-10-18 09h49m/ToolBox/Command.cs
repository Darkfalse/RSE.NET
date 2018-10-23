using System;
using System.Collections.Generic;

namespace ToolBox {
    class Command
    {
        public string Query { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }

        public Command(string query) {
            if (string.IsNullOrWhiteSpace(query))
                throw new Exception();
            else
                Query = query;
            Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string key, object value) {
            Parameters.Add(key, (value == null)? DBNull.Value : value);
        }
    }
}
