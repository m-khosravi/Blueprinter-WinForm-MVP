using Blueprinter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public class ViewTemplateManagerPresenter : IViewTemplateManagerPresenter
    {
        private readonly IViewTemplateManager _view;
        private readonly IApplicationController _appController;
        public ViewTemplateManagerPresenter(IViewTemplateManager view, IApplicationController appController)
        {
            _view = view;
            _appController = appController;
            _view.Presenter = this;
        }

        public IViewTemplateManager View
        {
            get => _view;
        }

        public void Run()
        {
            _view.TemplateTypes = new[]
            {
                TemplateType.Text,
                TemplateType.Url,
            };

            _view.Templates = _appController.Context.GetAllTemplates();
            _view.Run();
        }

        public void Save()
        {
            var templates = _view.Templates;

            _appController.Context.SaveTemplates(templates);
        }
    }
}
