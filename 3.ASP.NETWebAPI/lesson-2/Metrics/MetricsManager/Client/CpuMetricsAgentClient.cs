using System;
using System.Net.Http;
using System.Text.Json;
using MetricsManager.Client.Interface;
using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;
using NLog;

namespace MetricsManager.Client
{
    public class CpuMetricsAgentClient : ICpuMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public CpuMetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public AgentMetricsResponse<AgentCpuMetricDto> GetMetrics(CpuMetricsClientRequest request)
        {
            var url = $"{request.BaseUrl}api/metrics/cpu/from/{request.FromTime}/to/{request.ToTime}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var responseMessage = _httpClient.SendAsync(httpRequestMessage).Result;
                using var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AgentMetricsResponse<AgentCpuMetricDto>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.Error($"{request.BaseUrl} {ex.Message}" );
            }

            return null;
        }
    }
}