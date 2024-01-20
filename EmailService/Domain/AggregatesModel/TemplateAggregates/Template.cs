namespace Domain.AggregatesModel.TemplateAggregate;

public class Template
{
    public Template() { }
    public long Id { get; private set; }
    public string Html { get; private set; }
    public string? HeaderField { get; private set; }
    public string ContentField { get; private set; }
    public string? ButtonsField { get; private set; }
    public string? FooterField { get; private set; }
}
