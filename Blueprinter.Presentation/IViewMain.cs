using Blueprinter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IViewMain : IView<IViewMainPresenter>
    {
        IEnumerable<BlueprintInfo> Blueprints { get; set; }

        string ProjectPath { get; }
        string ProjectBlueprint { get; }
    }
}
