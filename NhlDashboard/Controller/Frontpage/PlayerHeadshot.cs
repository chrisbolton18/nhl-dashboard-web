namespace NhlDashboard.Controller.Frontpage
{

    public class PlayerHeadshot : AbstractController
    {

        protected override async Task<IJson> Call(string playerName)
        {
            try
            {
                var response = await client.GetAsync($"{BASE_URI}/frontpage/player/headshot/{playerName}");

                string b64str = await response.Content.ReadAsStringAsync();

                return new ByteJson(string.Format("data:image/png;base64,{0}", b64str));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return new ByteJson();
            }
        }

        public class ByteJson : IJson
        {
            public string? Value { get; set; }

            public ByteJson() { Value = string.Empty; }
            public ByteJson(string b64str) { Value = b64str; }
        }
    }
}