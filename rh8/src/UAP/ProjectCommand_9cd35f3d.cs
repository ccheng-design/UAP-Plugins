using System;

using Rhino;
using Rhino.Commands;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin
{
  [CommandStyle(Rhino.Commands.Style.ScriptRunner)]
  public class ProjectCommand_9cd35f3d : Command
  {
    public Guid CommandId { get; } = new Guid("9cd35f3d-9348-41f4-8b08-889404fa0f51");

    public ProjectCommand_9cd35f3d() { Instance = this; }

    public static ProjectCommand_9cd35f3d Instance { get; private set; }

    public override string EnglishName => "RandomColors";

    protected override Rhino.Commands.Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      // NOTE:
      // Initialize() attempts to loads the core rhinocode plugin
      // and prepare the scripting platform. This call can not be in any static
      // ctors of Command or Plugin classes since plugins can not be loaded while
      // rhino is loading this plugin. The call has an initialized check and is
      // very fast after the first run.
      ProjectPlugin.Initialize();

      return ProjectPlugin.RunCode(this, CommandId, doc, mode);
    }
  }
}