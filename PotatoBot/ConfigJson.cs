using Newtonsoft.Json;

namespace PotatoBot
{
    /// <summary>
    /// Defines a structure that holds data from our json config file
    /// </summary>
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}
