using System;
using System.Collections.Generic;
using System.Text;
using Blueprinter.Core;

namespace Blueprinter.Presentation
{
    public interface IViewTemplateManager : IView<IViewTemplateManagerPresenter>
    {
        IEnumerable<TemplateInfo> Templates { get; set; }
        IEnumerable<TemplateType> TemplateTypes { get; set; }
    }
}
