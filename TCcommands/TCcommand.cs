﻿using System;
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

        //특정 파라미터를 가진 오브젝트 선택하기
        public void SearchObjects(Project project)
        {
            //람다식을 사용하여 추출
            project.ModelObjectManager.SetSelected(false);
            var modelsContainsParams = project.ModelObjectManager.GetModelObjects().Where(x => x.GetAttributeNames().ToList().Contains("암구간") &&
                                                                            x.GetAttributeNames().ToList().Contains("토사구간")).ToList();
            if (modelsContainsParams.Any())
            {
                project.ModelObjectManager.SetSelected(true, modelsContainsParams);
            }
        }

        //특정 파라미터 추출하기
        //value1 : 파일번호, value2 : 설계 천공심도, value3 : 파일상단, value4 : 파일하단, value5 : 천공심도, value6 : 토사구간, value7 : 암구간
        //value2 = Math.Abs(value3 - value4), value5 = value6 + value7
        public List<List<string>> GetParamSelected(Project project, string param1, string param3, string param4,
                                                    string param6, string param7)
        {
            //전체 선택 해제
            project.ModelObjectManager.SetSelected(false);
            //특정 파라미터를 가진 경우만 추출
            var modelsContainsParams = project.ModelObjectManager.GetModelObjects().Where(x => x.GetAttributeNames().ToList().Contains(param1)).ToList();
            //파라미터 리스트 만들기
            List<List<string>> list = new List<List<string>>();

            //모델 Loop 방식으로 추출하기
            foreach (ModelObject model in modelsContainsParams)
            {
                //각 파라미터별로 파라미터 셋을 null로 지정하여 파라미터 셋에 따로 포함시키지 않고 추출
                AttributeSet attrSetParam1 = model.GetAttribute(param1, null).First();
                AttributeSet attrSetParam3 = model.GetAttribute(param3, null).First();
                AttributeSet attrSetParam4 = model.GetAttribute(param4, null).First();
                AttributeSet attrSetParam6 = model.GetAttribute(param6, null).First();
                AttributeSet attrSetParam7 = model.GetAttribute(param7, null).First();
                //string으로 파싱
                string value1 = attrSetParam1.IntAttributes.First().Value.ToString();
                string value2 = Math.Abs(attrSetParam3.LengthAttributes.First().Value
                                            - attrSetParam4.LengthAttributes.First().Value).ToString("F2");
                string value3 = attrSetParam3.LengthAttributes.First().Value.ToString("F2");
                string value4 = attrSetParam4.LengthAttributes.First().Value.ToString("F2");
                string value5 = Math.Abs(attrSetParam6.LengthAttributes.First().Value
                                            - attrSetParam7.LengthAttributes.First().Value).ToString("F2");
                string value6 = attrSetParam6.LengthAttributes.First().Value.ToString("F2");
                string value7 = attrSetParam7.LengthAttributes.First().Value.ToString("F2");
                List<string> paramSet = new List<string>() { value1, value2, value3, value4, value5, value6, value7 };
                list.Add(paramSet);
            }
            return list;
        }
    }
}
