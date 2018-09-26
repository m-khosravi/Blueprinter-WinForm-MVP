using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public class ViewBlueprintManagerPresenter : IViewBlueprintManagerPresenter
    {
        private readonly IViewBlueprintManager _view;
        private readonly IApplicationController _appController;
        public ViewBlueprintManagerPresenter(IViewBlueprintManager view, IApplicationController appController)
        {
            _view = view;
            _appController = appController;
            _view.Presenter = this;
        }

        public IViewBlueprintManager View
        {
            get => _view;
        }

        public void Run()
        {
            _view.BluePrints = _appController.Context.GetAllBlueprints();
            _view.Run();
        }

        public void Save()
        {
            var blueprints = _view.BluePrints;

            _appController.Context.SaveBlueprints(blueprints);
        }
    }
}
