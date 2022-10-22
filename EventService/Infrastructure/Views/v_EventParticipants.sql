CREATE VIEW [events].[v_EventParticipants]
AS
SELECT
    [EventParticipant].[EventId],
    [EventParticipant].[ParticipantId],
    [EventParticipant].[DecisionDate],
    [EventParticipant].[RoleCode],

    [Member].[FirstName],
    [Member].[LastName]
FROM [events].[EventParticipants] AS [EventParticipant]
    INNER JOIN [events].[Members] AS [Member]
        ON [EventParticipant].[EventId] = [Member].[Id]
GO