namespace Application.Features.SystemParameters.Dtos;

public class SystemParameterListDto
{
    public int Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string SampleValue { get; set; }
    public string Description { get; set; }
}