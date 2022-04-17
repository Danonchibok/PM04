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
        public static User User { get; set; } 
        private static PM04Entities1 context;
        public static PM04Entities1 GetContext()
        {
            if (context == null)
	        {
                context = new PM04Entities1();
	        }
            return context;
        }

    }
}
