﻿using Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Contracts.Response; 

public sealed class TaskInfoResponse
{
    [JsonProperty("task_id", Required = Required.Always)]
    public required int TaskId { get; init; }

    [JsonProperty("caption", Required = Required.Always)]
    public required string TaskCaption { get; init; }

    [JsonProperty("description", Required = Required.Always)]
    public required string TaskDescription { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("task_type", Required = Required.Always)]
    public required TaskType TaskType { get; init; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("task_status", Required = Required.Default)]
    public required TaskCurrentStatus TaskStatus { get; set; } = TaskCurrentStatus.ToDo;

    [JsonProperty("reporter", NullValueHandling = NullValueHandling.Ignore)]
    public ShortUserInfo Reporter { get; set; } = default!;

    [JsonProperty("implementer", Required = Required.Default)]
    public ShortUserInfo Implementer { get; set; } = default!;
}
