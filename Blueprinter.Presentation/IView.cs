using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; set; }
        void Run();
    }
}
