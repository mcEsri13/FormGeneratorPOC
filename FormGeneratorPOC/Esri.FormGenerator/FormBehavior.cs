using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esri.FormGenerator
{
    public class FormBehavior
    {
        //----------
        //Properties
        //----------

        private Boolean isModal { get; set; }
        private Boolean hasPaging { get; set; }
        private Boolean hasConfirmation { get; set; }
        private Boolean isRepsonsive { get; set; }

        //----------
        //Events
        //----------
        
        public Boolean IsModal
        {
            get { return IsModal; }
            set { IsModal = value; }
        }

        public Boolean HasPaging
        {
            get { return hasPaging; }
            set { hasPaging = value; }
        }

        public Boolean HasConfirmation
        {
            get { return hasConfirmation; }
            set { hasConfirmation = value; }
        }

        public Boolean IsResponsive
        {
            get { return isRepsonsive; }
            set { isRepsonsive = value; }
        }
    }
}
