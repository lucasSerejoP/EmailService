using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.ConfigEmailAggregates;

public class ConfigEmail
{
    private ConfigEmail() { }
    public long Id { get; private set; }
    public string SourceEmail { get; private set; }
    public string Subject { get; private set; }
    public string? DefaultMessage { get; private set; }
    public string? DefaultHeader { get; private set; }
    public string? DefaultFooter { get; private set; }
    public string? DefaultButtons { get; private set; }
    public int TemplateId { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }

}
