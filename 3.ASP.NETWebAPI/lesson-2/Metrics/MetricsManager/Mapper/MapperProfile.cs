using AutoMapper;
using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;
using MetricsManager.DAL.Model;
using MetricsManager.Request;
using AgentInfoDto = MetricsManager.Responses.Agents.AgentInfoDto;

namespace MetricsManager.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, AgentInfoDto>();
            CreateMap<AgentInfoRequest, AgentInfo>();
        }
    }
}