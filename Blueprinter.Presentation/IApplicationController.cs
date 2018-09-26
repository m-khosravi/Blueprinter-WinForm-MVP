using Blueprinter.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public interface IApplicationController
    {
        void RunBluePrintManager();
        void RunTemplateManager();

        IContext Context { get; }
    }
}
