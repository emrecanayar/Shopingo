using Application.Features.SystemParameters.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SystemParameters.Models;

public class SystemParameterListModel : BasePageableModel
{
    public IList<SystemParameterDto> Items { get; set; }
}