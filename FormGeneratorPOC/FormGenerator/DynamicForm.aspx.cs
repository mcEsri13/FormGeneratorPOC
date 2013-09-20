using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Esri.FormGenerator;
using System.Data;

namespace FormGenerator
{
    public partial class DynamicForm : System.Web.UI.Page
    {
        //Global values to test (prototype)
        private string connectionString = @"Server=CLINTSMAN;Database=FormGenerator;Trusted_Connection=True;";
        private DataSet dataSet = new DataSet();
        String[] paramNames = { "SitecoreID" };
        Object[] paramValues = {"{70738B8A-F40B-45CB-8497-15A1F6B91F7E}"};

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            using (SqlConnection sCon = new SqlConnection(connectionString))
            {
                
                using (SqlCommand sCmd = new SqlCommand("[spr_GetAllFormDataByItemID]", sCon))
                {
                    sCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(sCmd))
                    {
                        for (int i = 0; i < paramNames.Length; i++){
                            sCmd.Parameters.Add(new SqlParameter(paramNames[i], paramValues[i]));
                        }
             
                        //open and set and close...
                        sCon.Open();
                        da.Fill(dataSet);
                        sCon.Close();
                    }
                }
            }

            //Set's form if data found...
            if (dataSet != null)
                SetForm(dataSet);
        }

        private Form SetForm(DataSet dataSet)
        {
            Form newForm = new Form();

            //Data collection for form
            DataTable formData = new DataTable();
            DataTable formContainers = new DataTable();
            DataTable formElements = new DataTable();
            DataTable elementActions = new DataTable();
            DataTable elementBehaviors = new DataTable();

            //Load Form Data
            formData            = dataSet.Tables[0];
            formContainers      = dataSet.Tables[1];
            formElements        = dataSet.Tables[2];
            elementActions      = dataSet.Tables[3];
            elementBehaviors    = dataSet.Tables[4];

            //return LoadForm(newForm, formData, formContainers, formElements, elementActions, elementBehaviors); 
            newForm = LoadForm(newForm, formData, formContainers, formElements, elementActions, elementBehaviors);
            if (newForm != null)
                BuilHTMLObjects(newForm);

            return newForm;
        }

        private void BuilHTMLObjects(Esri.FormGenerator.Form newForm)
        {
            //Controls to be built out..
            List<TextBox> TextBoxes = new List<TextBox>();
            List<DropDownList> DropDownLists = new List<DropDownList>();
            List<Button> Buttons = new List<Button>();

            //Creating dynamic holders
            foreach (string container in newForm.ContainerNames){
                Panel newPanel = new Panel();
                newPanel.ID = "pnl" + container.ToLower();
                pnlContainer.Controls.Add(newPanel);
            }

            //Creating dynamic objects  
            foreach (Element element in newForm.Elements)
            {
                //Create a new span each iteration through the elements..
                System.Web.UI.HtmlControls.HtmlGenericControl dynamicDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                dynamicDiv.Attributes.Add("class", "set");
                System.Web.UI.HtmlControls.HtmlGenericControl dynamicSpan = new System.Web.UI.HtmlControls.HtmlGenericControl("span");

                //add validation..
                //Textbox
                if (element.Type.ToLower().Equals("textbox")){
                    TextBox newTexbox = new TextBox();
                    newTexbox.ID = "txt" + element.LabelName;
                    newTexbox.Attributes.Add("validate", element.Validate.ToString());
                    newTexbox.Attributes.Add("controlName", element.ControlName.ToLower().ToString());

                    //update div and span elements
                    dynamicDiv.ID = element.LabelName;
                    dynamicSpan.InnerText = element.LabelName;

                    //add span to div...
                    dynamicDiv.Controls.Add(dynamicSpan);
                    dynamicDiv.Controls.Add(newTexbox);

                    //Find and store the controls in the correct div..
                    pnlContainer.FindControl("pnl" + element.ControllerName.ToLower()).Controls.Add(dynamicDiv);
                }
                //Dropdown
                if (element.Type.ToLower().Equals("dropdownlist")){
                    DropDownList newDropDownList = new DropDownList();
                    newDropDownList = GetStateListDemo();
                    newDropDownList.ID = "ddl" + element.LabelName;
                    newDropDownList.Attributes.Add("validate", element.Validate.ToString());
                    newDropDownList.Attributes.Add("controlName", element.ControlName.ToLower().ToString());

                    //update span text value
                    dynamicSpan.InnerText = element.LabelName;

                    //Find and store the controls in the correct div...
                    pnlContainer.FindControl("pnl" + element.ControllerName.ToLower()).Controls.Add(dynamicSpan);
                    pnlContainer.FindControl("pnl" + element.ControllerName.ToLower()).Controls.Add(newDropDownList);
                }
                //Button
                if (element.Type.ToLower().Equals("submit")){
                    Button newButton = new Button();
                    newButton.ID = "btn" + element.LabelName;
                    newButton.Text = element.LabelName;
                    newButton.OnClientClick = "Alert('Hello World')";
                    newButton.Attributes.Add("controlName", element.ControlName.ToLower().ToString());

                    //Find and store the controls in the correct div
                    pnlContainer.FindControl("pnl" + element.ControllerName.ToLower()).Controls.Add(newButton);
                }
            }
        }

        private DropDownList GetStateListDemo()
        {
            DropDownList newList = new DropDownList();
            newList.Items.Add(new ListItem("", "-1"));
            newList.Items.Add(new ListItem("Alabama", "AL"));
            newList.Items.Add(new ListItem("Alaska", "AK"));
            newList.Items.Add(new ListItem("Arizona", "AZ"));
            newList.Items.Add(new ListItem("Arkansas", "AR"));
            newList.Items.Add(new ListItem("California", "CA"));
            newList.Items.Add(new ListItem("Colorado", "CO"));
            newList.Items.Add(new ListItem("Connecticut", "CT"));
            newList.Items.Add(new ListItem("Delaware", "DE"));
            newList.Items.Add(new ListItem("Florida", "FL"));
            newList.Items.Add(new ListItem("Georgia", "GA"));
            newList.Items.Add(new ListItem("Hawaii", "HI"));
            newList.Items.Add(new ListItem("Idaho", "ID"));
            newList.Items.Add(new ListItem("Illinois", "IL"));
            newList.Items.Add(new ListItem("Indiana", "IN"));
            newList.Items.Add(new ListItem("Iowa", "IA"));
            newList.Items.Add(new ListItem("Kansas", "KS"));
            newList.Items.Add(new ListItem("Kentucky", "KY"));
            newList.Items.Add(new ListItem("Louisiana", "LA"));
            newList.Items.Add(new ListItem("Maine", "ME"));
            newList.Items.Add(new ListItem("Maryland", "MD"));
            newList.Items.Add(new ListItem("Massachusetts", "MA"));
            newList.Items.Add(new ListItem("Michigan", "MI"));
            newList.Items.Add(new ListItem("Minnesota", "MN"));
            newList.Items.Add(new ListItem("Mississippi", "MS"));
            newList.Items.Add(new ListItem("Missouri", "MO"));
            newList.Items.Add(new ListItem("Montana", "MT"));
            newList.Items.Add(new ListItem("Nebraska", "NE"));
            newList.Items.Add(new ListItem("Nevada", "NV"));
            newList.Items.Add(new ListItem("New Hampshire", "NH"));
            newList.Items.Add(new ListItem("New Jersey", "NJ"));
            newList.Items.Add(new ListItem("New Mexico", "NM"));
            newList.Items.Add(new ListItem("New York", "NY"));
            newList.Items.Add(new ListItem("North Carolina", "NC"));
            newList.Items.Add(new ListItem("North Dakota", "ND"));
            newList.Items.Add(new ListItem("Ohio", "OH"));
            newList.Items.Add(new ListItem("Oklahoma", "OK"));
            newList.Items.Add(new ListItem("Oregon", "OR"));
            newList.Items.Add(new ListItem("Pennsylvania", "PA"));
            newList.Items.Add(new ListItem("Rhode Island", "RI"));
            newList.Items.Add(new ListItem("South Carolina", "SC"));
            newList.Items.Add(new ListItem("South Dakota", "SD"));
            newList.Items.Add(new ListItem("Tennessee", "TN"));
            newList.Items.Add(new ListItem("Texas", "TX"));
            newList.Items.Add(new ListItem("Utah", "UT"));
            newList.Items.Add(new ListItem("Vermont", "VT"));
            newList.Items.Add(new ListItem("Virginia", "VA"));
            newList.Items.Add(new ListItem("Washington", "WA"));
            newList.Items.Add(new ListItem("West Virginia", "WV"));
            newList.Items.Add(new ListItem("Wisconsin", "WI"));
            newList.Items.Add(new ListItem("Wyoming", "WY"));

            return newList;
        }

        private Form LoadForm(Esri.FormGenerator.Form newForm, DataTable formData, DataTable formContainers, DataTable formElements, DataTable elementActions, DataTable elementBehaviors)
        {
            //Instantiate new lists
            newForm.ContainerNames = new List<string>();
            newForm.Elements = new List<Element>();

            #region Validation
            
                #region FormData

                //Validation
                if (!formData.Rows[0]["Name"].Equals(null))
                    newForm.Name = formData.Rows[0]["Name"].ToString();

                if (!formData.Rows[0]["ItemID"].Equals(null))
                    newForm.SitecoreID = formData.Rows[0]["ItemID"].ToString();

                if (!formData.Rows[0]["CSSClass"].Equals(null))
                    newForm.CssClass = formData.Rows[0]["CSSClass"].ToString();

                #endregion

                #region FormContainer

                foreach (DataRow row in formContainers.Rows)
                {
                    //Validation
                    if (!row["ContainerID"].Equals(null))
                        newForm.ContainerNames = new List<string>();
                        newForm.ContainerNames.Add(row["ContainerID"].ToString());
                }

                #endregion

                #region FormElement

                foreach (DataRow row in formElements.Rows)
                {
                    Element element = new Element();

                    //Validation
                    if (!row["LabelName"].Equals(null))
                        element.LabelName = row["LabelName"].ToString();
                    if (!row["OrderNumber"].Equals(null))
                        element.OrderName = Convert.ToInt32(row["OrderNumber"].ToString());
                    if (!row["ContainerName"].Equals(null))
                        element.ControllerName = row["ContainerName"].ToString();
                    if (!row["ElementType"].Equals(null))
                        element.Type = row["ElementType"].ToString();
                    if (!row["Validate"].Equals(null))
                        element.Validate = Convert.ToBoolean(row["Validate"].ToString());
                    if (!row["ControlName"].Equals(null))
                        element.ControlName = row["ControlName"].ToString();

                    
                    #region Action

                    foreach (DataRow elementRow in elementActions.Rows)
                    {
                        ElementAction action = new ElementAction();

                        //Validation
                        if (!elementActions.Rows[0]["ActionName"].Equals(null))
                        {
                            element.Actions = new List<ElementAction>();
                            element.Actions.Add(new ElementAction { Action = elementActions.Rows[0]["ActionName"].ToString() });
                            element.Actions.Add(action);
                        }
                    }

                    #endregion

                    #region Behaviors

                    foreach (DataRow behaviorRow in elementBehaviors.Rows)
                    {
                        ElementBehavior behavior = new ElementBehavior();

                        //Validation
                        if (behaviorRow["BehaviorName"].Equals(null))
                        {
                            behavior.Behavior = behaviorRow["BehaviorName"].ToString();
                            element.Behaviors.Add(behavior);
                        }
                    }

                    #endregion

                    //add element to list of elements..
                    newForm.Elements.Add(element);
                }

                #endregion

            #endregion

            return newForm;
        }
    }
}

#region OldCode
//using (SqlDataReader sReader = sCmd.ExecuteReader())
//{
//    SqlParameter parameter = new SqlParameter();
//    int readerIndex = 0;
//    //Read values back...
//    while (sReader.Read())
//    {
//        parameter.ParameterName = sReader.GetName(readerIndex).ToString();
//        parameter.Value = sReader.GetValue(readerIndex).ToString();

//        //Add Values as string index...
//        sCmd.Parameters[parameter.ParameterName] = sCmd.Parameters.Add(parameter);
//    }
//}
#endregion