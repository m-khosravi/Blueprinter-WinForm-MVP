using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IViewTemplateManagerPresenter : IPresenter<IViewTemplateManager>
    {
        void Save();
    }
}
