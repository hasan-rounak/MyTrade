using Dapper;
using System.Data;
using System.Text.Json;

namespace MyTrade.Infra
{
    public class JsonTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override T Parse(object value)
        {
            if ($"{value}" != "")
            {
                return JsonSerializer.Deserialize<T>($"{value}");
            }
            return default;
        }

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = value;
        }
    }
}
