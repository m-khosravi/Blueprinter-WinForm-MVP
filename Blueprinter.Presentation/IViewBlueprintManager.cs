using System;
using System.Collections.Generic;
using System.Text;
using Blueprinter.Core;

namespace Blueprinter.Presentation
{
    public interface IViewBlueprintManager : IView<IViewBlueprintManagerPresenter>
    {
        IEnumerable<BlueprintInfo> BluePrints { get; set; }
    }
}
