using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IViewMainPresenter : IPresenter<IViewMain>
    {
        void RunBluePrintManager();
        void RunTemplateManager();
    }
}
