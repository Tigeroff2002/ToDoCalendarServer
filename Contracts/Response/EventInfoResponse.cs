﻿using Models.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Contracts.Response;

public sealed class EventInfoResponse
{
    [JsonProperty("event_id", Required = Required.Always)]
    public required int EventId { get; init; }

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

    [JsonProperty("manager", NullValueHandling = NullValueHandling.Ignore)]
    public ShortUserInfo? Manager { get; set; } = default!;

    [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
    public GroupInfoResponse? Group { get; set; } = default!;

    [JsonProperty("guests", NullValueHandling = NullValueHandling.Ignore)]
    public List<UserInfoWithDecision>? Guests { get; set; } = default!;

    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public object Content { get; set; } = default!;
}
