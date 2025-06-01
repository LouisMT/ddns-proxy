using System.Text.Json.Serialization;
using Core.Requests;
using Core.Responses;

namespace Core;

[JsonSerializable(typeof(UpdateDnsRecordRequest))]
[JsonSerializable(typeof(ListDnsRecordsResponse))]
[JsonSerializable(typeof(ListResponse))]
[JsonSerializable(typeof(UpdateDnsRecordResponse))]
[JsonSerializable(typeof(UpdateResponse))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}
