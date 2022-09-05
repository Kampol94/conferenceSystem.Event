using System.Data;

namespace EventService.Application.Contracts;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}