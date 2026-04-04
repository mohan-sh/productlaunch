using System;
using System.Collections.Generic;

namespace ProductLaunch.Messaging
{
    public class Config
    {
        private static Dictionary<string, string> _Values = new Dictionary<string, string>();

        private static readonly Dictionary<string, string> _Defaults = new Dictionary<string, string>
        {
            { "MESSAGE_QUEUE_URL", "nats://localhost:4222" }
        };

        public static string MessageQueueUrl { get { return Get("MESSAGE_QUEUE_URL"); } }
        
        private static string Get(string variable)
        {
            if (!_Values.ContainsKey(variable))
            {
                var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrEmpty(value))
                    value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
                if (string.IsNullOrEmpty(value))
                    _Defaults.TryGetValue(variable, out value);
                _Values[variable] = value;
            }
            return _Values[variable];
        }
    }
}
