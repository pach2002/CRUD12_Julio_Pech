using Travels.Core.Journeys;
using Travels.DataAccess;

namespace Travels.Api.Checkers
{
    public class Checkers
    {
         
        // local context of travels ORM
        /*private readonly TravelsDataContext _travelsDataContext;

        // injection dependency
        public Checkers(TravelsDataContext travelsDataContext) 
        {
            _travelsDataContext = travelsDataContext;
        }*/
        // -------------------------------
        // THIS IS A CLIENT SIDE CODE

        // FUNC 
        // INPUT Passenger.id
        // Check if current id exists in Passengers table
        public async Task<Boolean> IsPassengerChecked(int passengerId)
        {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7215/api/Passenger/{passengerId}");

            // if was successful
            if (response.IsSuccessStatusCode) 
            {
                // recover info and convert to json
                var content = await response.Content.ReadAsStringAsync();
                var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Passenger>(content);

                // if result is different to null and equals to current id
                if (jsonResponse != null && jsonResponse.Id == passengerId) 
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<Boolean> IsJourneyChecked(int JourneyId)
        {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7215/api/Journey/{JourneyId}");

            // if was successful
            if (response.IsSuccessStatusCode)
            {
                // recover info and convert to json
                var content = await response.Content.ReadAsStringAsync();
                var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Journey>(content);

                // if result is different to null and equals to current id
                if (jsonResponse != null && jsonResponse.Id == JourneyId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
