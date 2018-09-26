using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Core.Services
{
    public interface IContext
    {
        IEnumerable<BlueprintInfo> GetAllBlueprints();
        void SaveBlueprints(IEnumerable<BlueprintInfo> blueprints);


        IEnumerable<TemplateInfo> GetAllTemplates();
        void SaveTemplates(IEnumerable<TemplateInfo> templates);

        event EventHandler BlueprintsUpdated;
    }
}
