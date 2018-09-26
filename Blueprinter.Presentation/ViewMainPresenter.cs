using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Presentation
{
    public class ViewMainPresenter : IViewMainPresenter
    {
        private readonly IViewMain _view;
        private readonly IApplicationController _appController;
        public ViewMainPresenter(IViewMain view,IApplicationController appController)
        {
            _view = view;
            _appController = appController;
            _view.Presenter = this;

            _appController.Context.BlueprintsUpdated += Context_BlueprintsUpdated;
        }

        private void Context_BlueprintsUpdated(object sender, EventArgs e)
        {
            _view.Blueprints = _appController.Context.GetAllBlueprints();
        }

        public IViewMain View {
            get => _view;
        }

        public void Run()
        {
            Context_BlueprintsUpdated(null, null);
            _view.Run();
        }

        public void RunBluePrintManager()
        {
            _appController.RunBluePrintManager();
        }

        public void RunTemplateManager()
        {
            _appController.RunTemplateManager();
        }
    }
}
