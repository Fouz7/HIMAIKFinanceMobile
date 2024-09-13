using HimaikFinanceMobile.Models;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace HimaikFinanceMobile.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<string> LoginUserAsync(string username, string password)
    {
        var loginData = new { Username = username, Password = password };
        var response = await _httpClient.PostAsJsonAsync("User/LoginUser", loginData);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        _logger.LogError("Login failed");
        return string.Empty;
    }
    
    public async Task<List<TransactionData>> GetAllTransactionsAsync(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _httpClient.GetFromJsonAsync<List<TransactionData>>(
            $"Transaction/GetAllTransactions?pageNumber={pageNumber}&pageSize={pageSize}");
        return response ?? new List<TransactionData>();
                
    }
    
    public async Task<List<IncomeData>> GetIncomeDataAsync(string nominalSortOrder = "asc", int pageNumber = 1, int pageSize = 10)
    {
        var response = await _httpClient.GetFromJsonAsync<List<IncomeData>>(
            $"IncomeData/GetAllIncomeData?nominalSortOrder={nominalSortOrder}&pageNumber={pageNumber}&pageSize={pageSize}");
        return response ?? new List<IncomeData>();
    }
    
}