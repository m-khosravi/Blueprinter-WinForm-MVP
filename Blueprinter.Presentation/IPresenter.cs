using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IPresenter<TView>
    {
        TView View { get; }
        void Run();
    }
}
