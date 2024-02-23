using System.ComponentModel;

namespace NhlDashboard.Controller.Frontpage
{

    public class PlayerStats : AbstractController
    {

        protected override async Task<IJson> Call(string playerName)
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

        public class PlayerStatsJson : IJson
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