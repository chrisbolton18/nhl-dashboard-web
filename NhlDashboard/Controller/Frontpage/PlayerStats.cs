using System.ComponentModel;

namespace NhlDashboard.Controller.Frontpage
{

    public class PlayerStats
    {

        private static HttpClient client = new HttpClient();
        private string BASE_URI = "http://127.0.0.1:8000";

        private static PlayerStats? instance = null;
        private PlayerStats() { }
        public static PlayerStats Instance()
        {
            if (instance == null) instance = new PlayerStats();
            return instance;
        }

        public async Task<PlayerStatsJson> Call(string playerName)
        {
            try
            {
                PlayerStatsJson response = await client.GetFromJsonAsync<PlayerStatsJson>($"{BASE_URI}/frontpage/player/stats/{playerName}");
                return response;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return new PlayerStatsJson();
            }
        }

        public class Career
        {
            public int assists { get; set; }
            public int goals { get; set; }
            public int pim { get; set; }
            public int plusMinus { get; set; }
            public int points { get; set; }
        }

        public class PlayerStatsJson
        {
            public Career career { get; set; }
            public SubSeason subSeason { get; set; }
        }

        public class SubSeason
        {
            public int assists { get; set; }
            public int goals { get; set; }
            public int pim { get; set; }
            public int plusMinus { get; set; }
            public int points { get; set; }
        }
    }
}