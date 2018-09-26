using System;
using System.Collections.Generic;
using System.Text;

namespace Blueprinter.Core
{
    public class BlueprintInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Blueprint { get; set; }
        public DateTime LastModified { get; set; }

    }
}
