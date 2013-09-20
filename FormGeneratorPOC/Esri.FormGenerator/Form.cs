using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esri.FormGenerator
{
    public class Form
    {
        //----------
        //Properties
        //----------

        private List<Element> elements { get; set; }
        private String cssClass { get; set; }
        private String sitecoreID { get; set; }
        private String name { get; set; }
        private List<String> containerNames {get; set;}

        //----------
        //Events
        //----------

        public List<Element> Elements
        {
            get { return elements; }
            set { elements = value.ToList<Element>(); }
        }

        public String CssClass
        {
            get { return cssClass; }
            set { cssClass = value; }
        }

        public String SitecoreID
        {
            get { return sitecoreID; }
            set {sitecoreID = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<String> ContainerNames
        {
            get { return containerNames; }
            set { containerNames = value; }
        }
    }
}
