using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IViewBlueprintManagerPresenter : IPresenter<IViewBlueprintManager>
    {
        void Save();
    }
}
