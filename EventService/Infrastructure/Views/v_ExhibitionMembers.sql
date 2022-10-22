CREATE VIEW [events].[v_ExhibitionMembers]
AS
SELECT
    [Exhibitions].Id,
    [Exhibitions].[Name],
    [Exhibitions].[Description],

    [ExhibitionsMember].[MemberId],
    [ExhibitionsMember].[RoleCode],
    [ExhibitionsMember].[IsActive],
    [ExhibitionsMember].[JoinedDate]
FROM events.Exhibitions AS [Exhibitions]
    INNER JOIN [events].[ExhibitionMembers] AS [ExhibitionsMember]
        ON [Exhibitions].[Id] = [ExhibitionsMember].[ExhibitionId]
GO