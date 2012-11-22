// Type: Roslyn.Scripting.CSharp.ScriptEngine
// Assembly: Roslyn.Compilers.CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Users\amiralles\Dev\posts\Roslyn-Dsl\packages\Roslyn.Compilers.CSharp.1.2.20906.2\lib\net45\Roslyn.Compilers.CSharp.dll

using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Scripting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Roslyn.Scripting.CSharp
{
  public sealed class ScriptEngine : CommonScriptEngine
  {
    private static readonly ParseOptions DefaultInteractive = new ParseOptions(CompatibilityMode.None, LanguageVersion.CSharp6, true, SourceCodeKind.Interactive, new ReadOnlyArray<string>());
    private static readonly ParseOptions DefaultScript = new ParseOptions(CompatibilityMode.None, LanguageVersion.CSharp6, true, SourceCodeKind.Script, new ReadOnlyArray<string>());

    static ScriptEngine()
    {
    }

    public ScriptEngine(MetadataFileProvider metadataFileProvider = null, IAssemblyLoader assemblyLoader = null)
      : base(metadataFileProvider, assemblyLoader)
    {
    }

    internal override CommonCompilation CreateCompilation(IText code, string path, bool isInteractive, Session session, Type returnType, DiagnosticBag diagnostics)
    {
      Compilation previousSubmission = (Compilation) session.LastSubmission;
      IEnumerable<MetadataReference> referencesForCompilation = session.GetReferencesForCompilation();
      ReadOnlyArray<string> namespacesForCompilation = session.GetNamespacesForCompilation();
      ParseOptions options = isInteractive ? ScriptEngine.DefaultInteractive : ScriptEngine.DefaultScript;
      SyntaxTree syntaxTree = SyntaxTree.ParseText(code, path, options, new CancellationToken());
      diagnostics.Add((IEnumerable<CommonDiagnostic>) syntaxTree.GetDiagnostics(new CancellationToken()));
      if (diagnostics.HasAnyErrors())
        return (CommonCompilation) null;
      string assemblyName;
      string typeName;
      this.GenerateSubmissionId(out assemblyName, out typeName);
      Compilation submission = Compilation.CreateSubmission(assemblyName, new CompilationOptions(OutputKind.DynamicallyLinkedLibrary, (string) null, typeName, (IEnumerable<string>) namespacesForCompilation.ToList(), DebugInformationKind.None, false, true, false, true, (string) null, (string) null, new bool?(), 0, 0UL, Platform.AnyCPU, ReportWarning.Default, 4, (IReadOnlyDictionary<int, ReportWarning>) null, false, new SubsystemVersion()), syntaxTree, previousSubmission, referencesForCompilation, session.FileResolver, this.metadataFileProvider, returnType, session.HostObjectType);
      this.ValidateReferences((CommonCompilation) submission, diagnostics);
      if (diagnostics.HasAnyErrors())
        return (CommonCompilation) null;
      else
        return (CommonCompilation) submission;
    }

    internal void ValidateReferences(CommonCompilation compilation, DiagnosticBag diagnostics)
    {
      foreach (AssemblyIdentity identity in compilation.ReferencedAssemblyNames)
      {
        if (CommonScriptEngine.IsReservedAssemblyName(identity))
          DiagnosticBagExtensions.Add(diagnostics, ErrorCode.ERR_ReservedAssemblyName, (Location) null, new object[1]
          {
            (object) identity.GetDisplayName(false)
          });
      }
    }
  }
}
