using Blueprinter.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blueprinter.Core.Services
{
    public class XmlContext:IContext
    {
        private readonly IRepository<BlueprintInfo> _blueprints;
        private readonly IRepository<TemplateInfo> _templates;

        public event EventHandler BlueprintsUpdated;

        public XmlContext(string path)
        {
            var blueprintPath = $"{path}/blueprints.xml";
            var templatesPath = $"{path}/templates.xml";

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
    }
}
