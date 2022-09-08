﻿namespace EventService.Application.Exhibition.Queries.GetAllMeetingGroups;

public class ExhibitionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? LocationCountryCode { get; set; }

    public string? LocationCity { get; set; }
}