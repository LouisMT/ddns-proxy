using System.Text.Json.Serialization;
using Core.Requests;
using Core.Responses;

namespace Core;

[JsonSerializable(typeof(UpdateDnsRecordRequest))]
[JsonSerializable(typeof(UpdateDnsRecordResponse))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}
