using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blueprinter.Core.Data
{
    public class TemplateInfoRepository : JsonRepository<TemplateInfo>
    {
        public TemplateInfoRepository(string path) : base(path)
        {
        }

        public override TemplateInfo Create(TemplateInfo t)
        {
            if (t.Id != Guid.Empty)
            {
                throw new Exception("Blueprint ID already exist.");
            }

            t.Id = Guid.NewGuid();
            t.LastModified = DateTime.Now;

            Records.Add(t);

            WriteFile();

            return t;
        }

        public override int Delete(TemplateInfo t)
        {
            var record = Records.SingleOrDefault(r => r.Id == t.Id);

            if (record == null)
            {
                return 0;
            }

            Records.Remove(record);

            WriteFile();

            return 1;
        }

        public override int Update(TemplateInfo t)
        {
            var record = Records.SingleOrDefault(r => r.Id == t.Id);

            if (record == null)
            {
                return 0;
            }

            record.Name = t.Name;
            record.Shortcut = t.Shortcut;
            record.Content = t.Content;
            record.LastModified = DateTime.Now;

            WriteFile();

            return 1;
        }
    }
}
