using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esri.FormGenerator
{
    public class ElementBehavior
    {
        //-----------
        //Properties
        //-----------

        private String behavior { get; set; }

        //----------
        //Events
        //----------
        public string Behavior 
        {
            get { return behavior; }
            set { behavior = value; }
        }
    }
}
