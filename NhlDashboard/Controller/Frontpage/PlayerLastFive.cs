using System.Text.Json;

namespace NhlDashboard.Controller.Frontpage
{

    public class PlayerLastFive : AbstractController
    {

        protected override async Task<IJson> Call(string playerName)
        {
            try
            {
                var response = await client.GetAsync($"{BASE_URI}/frontpage/player/lastfive/{playerName}");

                List<GameData> data = JsonSerializer.Deserialize<List<GameData>>(await response.Content.ReadAsStringAsync());

                GameDataList retval = new GameDataList()
                {
                    games = data,
                };

                return retval;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return new GameDataList();
            }
        }


        public class GameDataList : IJson
        {
            public List<GameData> games { get; set; }
            public GameDataList() { games = new List<GameData>(); }
        }

        public class GameData
        {
            public int assists { get; set; }
            public string gameDate { get; set; }
            public int goals { get; set; }
            public string homeRoadFlag { get; set; }
            public string opponentAbbrev { get; set; }
            public string opponentLogo { get; set; }
            public int pim { get; set; }
            public string score { get; set; }
            public bool win { get; set; }
        }


    }

}