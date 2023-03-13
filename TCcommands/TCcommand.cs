using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Trimble.Connect.Desktop.API;
using Trimble.Connect.Desktop.API.Attributes;
using Trimble.Connect.Desktop.API.ModelObjects;
using Trimble.Connect.Desktop.API.Models;
using Trimble.Connect.Desktop.API.Projects;

namespace TCTableBuilder.TCcommands
{
    public class TCcommand
    {
        private readonly TrimbleConnectDesktopClient client = new TrimbleConnectDesktopClient();
        public string Text;
        private bool connected = false;

        public bool Connect()
        {
            this.connected = this.client.Connect();
            return this.connected;
        }

        public void Disconnect()
        {
            this.client.Disconnect();
            this.connected = false;
        }

        public Project getActiveProject()
        {
            if (this.connected)
            {
                var activeProject = this.client.ProjectManager.GetActiveProject();
                return activeProject;
            }
            else
            {
                return null;
            }
        }

        public string getProjectName(Project project)
        {
            if (project != null)
            {
                return project.Name;
            }
            else
            {
                return null;
            }
        }

        public void MoveObjects(Project project, double moveX, double moveY, double moveZ)
        {
            var models = project.ModelManager.GetLoadedModels().ToList();
            foreach (Model model in models)
            {
                model.SetPosition(moveX, moveY, moveZ);
            }
        }

        //Select object which has specific attribute.
        public void SearchObjects(Project project)
        {
            //Using lambda expression
            project.ModelObjectManager.SetSelected(false);
            var modelsContainsParams = project.ModelObjectManager.GetModelObjects().Where(x => x.GetAttributeNames().ToList().Contains("암구간") &&
                                                                            x.GetAttributeNames().ToList().Contains("토사구간")).ToList();
            if(modelsContainsParams.Any())
            {
                project.ModelObjectManager.SetSelected(true, modelsContainsParams);
            }
        }

        //Getting specific attribute
        public List<List<string>> GetParamSelected(Project project, string idxName,string param1, string param2)
        {
            //Deselect all
            project.ModelObjectManager.SetSelected(false);
            //Filtering the model which has the specific parameters
            var modelsContainsParams = project.ModelObjectManager.GetModelObjects().Where(x => x.GetAttributeNames().ToList().Contains(param1) &&
                                                                            x.GetAttributeNames().ToList().Contains(param2)).ToList();
            //Parameter lists
            List<List<string>> list = new List<List<string>>();

            //Parse attribute values.
            foreach(ModelObject model in modelsContainsParams)
            {
                AttributeSet attrSetIdx = model.GetAttribute(idxName, null).First();
                AttributeSet attrSetParam1 = model.GetAttribute(param1, null).First();
                AttributeSet attrSetParam2 = model.GetAttribute(param2, null).First();

                //ToString() all values.
                string idx = attrSetIdx.IntAttributes.First().Value.ToString();
                string value1 = attrSetParam1.LengthAttributes.First().Value.ToString("F2");
                string value2 = attrSetParam2.LengthAttributes.First().Value.ToString("F2");
                List<string> paramSet = new List<string>() { idx, value1, value2 };
                list.Add(paramSet);
            }
            return list;
        }
    }
}
