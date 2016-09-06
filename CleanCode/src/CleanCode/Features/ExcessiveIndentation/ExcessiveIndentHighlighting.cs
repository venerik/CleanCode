using CleanCode;
using CleanCode.Features.ExcessiveIndentation;
using CleanCode.Resources;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

[assembly:RegisterConfigurableSeverity(ExcessiveIndentHighlighting.SeverityID, null,
    CleanCodeHighlightingGroupIds.CleanCode, "Excessive indentation", "The nesting in this method is excessive.",
    Severity.WARNING, false)]

namespace CleanCode.Features.ExcessiveIndentation
{
    [ConfigurableSeverityHighlighting(SeverityID, CSharpLanguage.Name)]
    public class ExcessiveIndentHighlighting : IHighlighting
    {
        internal const string SeverityID = "ExcessiveIndentation";
        private readonly DocumentRange documentRange;

        public ExcessiveIndentHighlighting(DocumentRange documentRange)
        {
            this.documentRange = documentRange;
        }

        public DocumentRange CalculateRange()
        {
            return documentRange;
        }

        public string ToolTip
        {
            get { return Warnings.ExcessiveDepth; }
        }

        public string ErrorStripeToolTip
        {
            get { return ToolTip; }
        }

        public bool IsValid()
        {
            return true;
        }
    }
}