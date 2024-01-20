using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.ForwardEmailAggregates;

public class ForwardEmail
{
    public long Id { get; private set; }
    public string SourceEmail { get; private set; }
    public string DestinationEmail { get; private set; }
    public string Subject { get; private set; }
    public string Message { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }
    public long EmailConfigId { get; private set; }
    public long TemplateId { get; private set; }
}
