using System;
using pm04.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm04
{
    internal class TemplateContext
    {
        private static PM04Entities context;
        public static PM04Entities GetContext()
        {
            if (context == null)
	        {
                context = new PM04Entities();
	        }
            return context;
        }

    }
}
