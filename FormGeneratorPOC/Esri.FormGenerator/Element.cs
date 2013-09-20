using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esri.FormGenerator
{
    public class Element
    {
        //----------
        //Properties
        //----------

        private Int32 orderName { get; set; }
        private String type { get; set; }
        private String controllerName { get; set; }
        private String labelName { get; set; }
        private String controlName { get; set; }
        private List<ElementAction> actions { get; set; }
        private List<ElementBehavior> behaviors { get; set; }
        private bool validate { get; set; }

        public Element()
        { }


        public Element(int orderName, string type, string controllerName, string labelName, string controlName, List<ElementAction> actions, List<ElementBehavior> behaviors, bool validate)
        {
            this.orderName = orderName;
            this.controllerName = controllerName;
            this.labelName = labelName;
            this.controlName = controlName;
            this.actions = actions;
            this.behaviors = behaviors;
            this.validate = validate;
        }   

        //----------
        //Events
        //----------

        public bool Validate
        {
            get { return validate; }
            set { validate = value; }
        }
        
        public Int32 OrderName
        {
            get { return orderName; }
            set { orderName = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public String ControllerName
        {
            get { return controllerName; }
            set { controllerName = value; }
        }

        public String LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }
        public String ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }
        

        public List<ElementAction> Actions
        {
            get { return actions; }
            set { actions = value.ToList<ElementAction>(); }
        }

        public List<ElementBehavior> Behaviors
        {
            get { return behaviors; }
            set { behaviors = value; }
        }
    }
}
