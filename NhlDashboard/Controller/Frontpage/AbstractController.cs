namespace NhlDashboard.Controller.Frontpage
{

    public abstract class AbstractController
    {
        protected static HttpClient client = new HttpClient();
        protected string BASE_URI = "http://127.0.0.1:8000";

        protected abstract Task<IJson> Call(string playerName);

        public async Task<IJson> Perform(string playerName)
        {
            IJson response = await Call(playerName);

            return response;
        }
    }


}