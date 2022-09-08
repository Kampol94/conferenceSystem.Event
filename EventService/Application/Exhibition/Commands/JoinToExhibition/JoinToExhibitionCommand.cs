﻿using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibition.Commands.JoinToExhibition;

public class JoinToExhibitionCommand : CommandBase
{
    public JoinToExhibitionCommand(Guid exhibitionId)
    {
        ExhibitionId = exhibitionId;
    }

    internal Guid ExhibitionId { get; }
}