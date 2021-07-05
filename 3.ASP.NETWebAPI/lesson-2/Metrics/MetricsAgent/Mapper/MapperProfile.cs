using AutoMapper;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;

namespace MetricsAgent.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<CpuMetricCreateRequest, CpuMetric>();
            CreateMap<DotNetMetric, DotNetMetricsDto>();
            CreateMap<DotNetMetricCreateRequest, DotNetMetric>();
            CreateMap<HddMetric, HddMetricsDto>();
            CreateMap<HddMetricCreateRequest, HddMetric>();
            CreateMap<NetworkMetric, NetworkMetricsDto>();
            CreateMap<NetworkMetricCreateRequest, NetworkMetric>();
            CreateMap<RamMetric, RamMetricsDto>();
            CreateMap<RamMetricCreateRequest, RamMetric>();
        }
    }
}