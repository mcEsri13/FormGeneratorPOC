using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esri.FormGenerator
{
    public class ElementAction
    {
        //----------
        //Properties
        //----------

        private String action { get; set; }

        //----------
        //Events
        //----------

        public String Action
        {
            get { return action; }
            set { action = value; }
        }
    }
}
