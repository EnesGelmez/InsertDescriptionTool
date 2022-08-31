using System.ComponentModel;
using System.Runtime.InteropServices;

namespace InsertDescription
{
    internal partial class OptionsProvider
    {
        // Register the options with this attribute on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.General1Options), "InsertDescription", "General1", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class General1Options : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("My category")]
        [DisplayName("My Option")]
        [Description("An informative description.")]
        [DefaultValue(true)]
        public bool MyOption { get; set; } = true;
    }
}
