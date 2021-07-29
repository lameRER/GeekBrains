using System;
using System.Data;
using Dapper;

namespace MetricsManager.DAL
{
    public class DateTimeOffsetMappingHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value) =>
            DateTimeOffset.FromUnixTimeSeconds((long)value).ToOffset(TimeZoneInfo.Local.BaseUtcOffset);

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value) =>
            parameter.Value = value.ToUnixTimeSeconds();
    }
}
