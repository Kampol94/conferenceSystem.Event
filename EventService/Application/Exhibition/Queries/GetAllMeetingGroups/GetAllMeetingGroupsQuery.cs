using System.Collections.Generic;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetAllExhibitions;

public class GetAllExhibitionsQuery : IQuery<List<ExhibitionDto>>
{
}