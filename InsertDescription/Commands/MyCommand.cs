///////////////////////////////////////////////////////////////////////////////
//FileName: Intercepter.cs
//FileType: Visual C# Source file
//Size : ?Bilmiyorum :-)
//Author : Legion
//Created On : 21.07.2022 10:04:48
//Last Modified On : 21.07.2022 10:04:48
//Copy Rights : Lobitek Yazılım A.Ş.
//Description : Intercept Class For Everyting On The Services
////////////////////////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.Text;
using System.Linq;
namespace InsertDescription
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Package.JoinableTaskFactory.SwitchToMainThreadAsync();

            DocumentView docView = await VS.Documents.GetActiveDocumentViewAsync();

            var description = @$"/*--------------------𝕃𝕠𝕓𝕚𝕥𝕖𝕜 𝕐𝕒𝕫𝕚𝕝𝕚𝕞 𝔸.𝕊-----------------------------
- File: {docView.FilePath.Split('\\').Last()}
- FileType: Visual C# Source file
- Author : {Environment.UserName}
- Created On : {DateTime.Now}
- Last Modified On : {DateTime.Now}
- Copy Rights : Lobitek Yazılım A.Ş.
- Description : 
--------------------------------------------------------------------*/
";
            SnapshotSpan snapshotSpan = docView.TextView.Selection.SelectedSpans[0];

            try
            {
                using (ITextEdit edit = docView.TextView.TextBuffer.CreateEdit())
                {
                    edit.Replace(snapshotSpan, description);
                    edit.Apply();
                }
            }
            finally
            {

            }
        }
    }
}
