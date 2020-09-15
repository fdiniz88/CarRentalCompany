using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarRentalCompany.App.Application.Models.Dtos;
using CarRentalCompany.App.Application.Models.ViewModels.ReserveAggregate;

namespace CarRentalCompany.App.Application
{
    public class ApplicationService
    {
        private static string token;
        public ObservableCollection<ReserveViewModel> Statement { get; set; }
        public async Task<ObservableCollection<ReserveViewModel>> GetCarStatementAsync(Guid carId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await httpClient.GetAsync("https://CarRentalCompany-fernando-reserve-microservice-api.azurewebsites.net/api/reserves/" + carId.ToString());
            if (!result.IsSuccessStatusCode)
                return null;
            var serializedStatement = await result.Content.ReadAsStringAsync();
            var statement = JsonConvert.DeserializeObject<IEnumerable<ReserveViewModel>>(serializedStatement);

            Statement = new ObservableCollection<ReserveViewModel>(statement);
            return Statement;
        }
        public bool SignIn(string username, string password)
        {
            token = GetToken(username, password);

            if (String.IsNullOrWhiteSpace(token))
                return false;

            return true;
        }
        public bool SignUp(UserPasswordDto userPassword)
        {
            var adminToken = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + adminToken);
            var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://CarRentalCompany-fernando-iam-microservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }
        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://CarRentalCompany-fernando-iam-microservice-identity.azurewebsites.net/connect/token",
                ClientId = "CarRentalCompanyMobileApp_ClientId",
                UserName = "admin",
                Password = "111288Fer$"
            }).Result;

            return response.AccessToken;
        }
        public string GetToken(string username, string password)
        {
            var httpClient = new HttpClient();
            var response = httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://CarRentalCompany-fernando-iam-microservice-identity.azurewebsites.net/connect/token",
                ClientId = "CarRentalCompanyMobileApp_ClientId",
                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }
    }
}
