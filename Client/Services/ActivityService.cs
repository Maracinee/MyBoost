using MyBoost.Client.Services.Interfaces;
using MyBoost.Shared.Data;
using System.Net.Http.Json;

namespace MyBoost.Client.Services
{
    public class ActivityService : IActivityService
    {
        private readonly HttpClient _http;
        //private readonly DataContext context;

        public ActivityService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<Activity> CreateNewActivity(Activity activity)
        {
            var result = await _http.PostAsJsonAsync("api/Activity", activity);
            return await result.Content.ReadFromJsonAsync<Activity>();
        }

        public async Task<Activity> GetActivityById(int id)
        {
            var result = await _http.GetAsync($"api/Activity/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Activity { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Activity>();
            }
        }

        public async Task<bool> EditActivity(Activity activity, int id)
        {
            var oldActivity = await GetActivityById(id);

            if (oldActivity != null & activity.Id == id)
            {
                oldActivity.Url = activity.Url;
                oldActivity.Title = activity.Title;
                oldActivity.Description = activity.Description;
                oldActivity.Priority = activity.Priority;
                oldActivity.Estimate = activity.Estimate;
                oldActivity.Version = activity.Version;

                //await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
