using System;
using System.Data;
using Dapper;

namespace MetricsManager.DAL
{
    public class UriMappingHandler : SqlMapper.TypeHandler<Uri>
    {
        public override Uri Parse(object value) =>
            new Uri(value as string);

        public override void SetValue(IDbDataParameter parameter, Uri value) =>
            parameter.Value = value.ToString();
    }
}
