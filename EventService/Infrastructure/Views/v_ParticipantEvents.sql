CREATE VIEW [events].[v_ParticipantEvents]
AS
SELECT
	[Event].[Id],
    [Event].[Title],
    [Event].[Description],
    [Event].[TermStartDate],
    [Event].[TermEndDate],

    [EventParticipants].[ParticipantId],
    [EventParticipants].[IsRemoved],
    [EventParticipants].[RoleCode]
FROM [events].[Events] AS [Event]
    INNER JOIN [events].[EventParticipants] AS [EventParticipants]
        ON [Event].[Id] = [EventParticipants].[EventId]
GO