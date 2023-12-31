﻿using Models.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Contracts.Request;

namespace Contracts;

public class EventInputDTO : RequestWithToken
{
    [JsonProperty("caption", Required = Required.Always)]
    public required string Caption { get; init; }

    [JsonProperty("description", Required = Required.Always)]
    public required string Description { get; init; }

    [JsonProperty("scheduled_start", Required = Required.Always)]
    public required DateTimeOffset ScheduledStart { get; init; }

    [JsonProperty("duration", Required = Required.Always)]
    public required TimeSpan Duration { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("event_type", Required = Required.Always)]
    public required EventType EventType { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("event_status", Required = Required.Always)]
    public required EventStatus EventStatus { get; init; }

    [JsonProperty("group_id", Required = Required.Default)]
    public required int GroupId { get; init; }

    [JsonProperty("guests_ids", Required = Required.Default)]
    public List<int> GuestsIds { get; set; } = default!;
}
