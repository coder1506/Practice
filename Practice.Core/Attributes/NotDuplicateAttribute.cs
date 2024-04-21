using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.Attributes
{
    public class NotDuplicateAttribute: Attribute
    {
        public string? message { get; set; }

        public NotDuplicateAttribute(string message) {
            this.message = message;
        }
    }
}
