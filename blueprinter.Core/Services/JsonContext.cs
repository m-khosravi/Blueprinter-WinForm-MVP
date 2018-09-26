using Blueprinter.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blueprinter.Core.Services
{
    public class JsonContext:IContext
    {
        private readonly IRepository<BlueprintInfo> _blueprints;
        private readonly IRepository<TemplateInfo> _templates;

        public event EventHandler BlueprintsUpdated;

        public JsonContext(string path)
        {
            var blueprintPath = $"{path}/blueprints.json";
            var templatesPath = $"{path}/templates.json";

            _blueprints = new BlueprintInfoRepository(blueprintPath);
            _templates = new TemplateInfoRepository(templatesPath);
        }

        public IEnumerable<TemplateInfo> GetAllTemplates()
        {
            return _templates.All();
        }

        public IEnumerable<BlueprintInfo> GetAllBlueprints()
        {
            return _blueprints.All();
        }

        public void SaveBlueprints(IEnumerable<BlueprintInfo> blueprints)
        {
            _blueprints.Delete(b => !blueprints.Select(bp => bp.Id).Contains(b.Id));

            foreach (var blue in blueprints)
            {
                if (blue.Id == Guid.Empty)
                {
                    _blueprints.Create(blue);
                }
                else
                {
                    _blueprints.Update(blue);
                }
            }

            OnBlueprintUpdated();
        }

        public void SaveTemplates(IEnumerable<TemplateInfo> templates)
        {
            _templates.Delete(b => !templates.Select(bp => bp.Id).Contains(b.Id));

            foreach (var temp in templates)
            {
                if (temp.Id == Guid.Empty)
                {
                    _templates.Create(temp);
                }
                else
                {
                    _templates.Update(temp);
                }
            }
        }

        IEnumerable<TemplateInfo> IContext.GetAllTemplates()
        {
            return _templates.All();
        }

        protected void OnBlueprintUpdated()
        {
            BlueprintsUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
