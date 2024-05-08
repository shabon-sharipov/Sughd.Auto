using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.Models;

public class Test : EntityBase
{
    public string Header { get; set; }
    public string Text { get; set; }
    
    public List<string> ? Images { get; set; }
}