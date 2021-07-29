using System;
using System.Collections.Generic;

namespace MetricsManager
{
    public class AgentsList
    {
        public readonly List<AgentInfo> AgentInfos = new List<AgentInfo>();

        public AgentsList()
        {
            // DataGrid();
        }

        // private void DataGrid()
        // {
        //     for (var j = 0; j < 30; j++)
        //     {
        //         AgentInfos.Add(
        //             new AgentInfo(
        //             new Random().Next(1, 9999999), 
        //             new Uri($"http:\\\\192.168.{new Random().Next(0,3)}.{new Random().Next(0,254)}:5000")));
        //     }
        // }
    }
}