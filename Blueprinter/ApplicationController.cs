using Blueprinter.Core.Services;
using Blueprinter.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContext _context;

        public IContext Context => _context;

        public ApplicationController(IContext context)
        {
            _context = context;
        }

        public void RunBluePrintManager()
        {
            using (var view = new ViewBlueprintManager())
            {
                var presenter = new ViewBlueprintManagerPresenter(view, this);
                presenter.Run();
            }
        }

        public void RunTemplateManager()
        {
            using (var view = new ViewTemplateManager())
            {
                var presenter = new ViewTemplateManagerPresenter(view, this);
                presenter.Run();
            }
        }
    }
}
