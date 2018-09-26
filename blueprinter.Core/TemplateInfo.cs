using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Core
{
    public  class TemplateInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Shortcut { get; set; }
        public TemplateType Type { get; set; }
        public DateTime LastModified { get; set; }
    }
}
