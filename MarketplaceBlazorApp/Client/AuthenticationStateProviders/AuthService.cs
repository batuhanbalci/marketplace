using MarketplaceBlazorApp.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp.Client.AuthenticationStateProviders
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResultModel> Register(UserModel registerModel)
        {
            var result = await _httpClient.PostJsonAsync<RegisterResultModel>("api/user/register", registerModel);

            return result;
        }

        public async Task<UserModel> Login(AuthenticateModel loginModel)
        {
            //var loginAsJson = JsonSerializer.Serialize(loginModel);
            //var response = await _httpClient.PostAsync("api/user/authenticate", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            UserModel user;
            user = await _httpClient.PostJsonAsync<UserModel>("api/login/authenticate", loginModel);
            //var loginResult = JsonSerializer.Deserialize<LoginResultModel>(await user.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (user == null)
            {
                return null;
            }

            await _localStorage.SetItemAsync("authToken", user.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(user.Token);//orijinalinde token yerine mail vardı ama sanki bu daha mantıklı oldu gibi
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

            return user;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
