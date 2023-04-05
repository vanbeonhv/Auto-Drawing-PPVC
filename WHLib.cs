using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model.Operations;

//Drawing
using TS = Tekla.Structures;

using TSM = Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;
using TSG = Tekla.Structures.Geometry3d;
using TSDD = Tekla.Structures.Dialog;

using TSD = Tekla.Structures.Drawing;
using TSDUI = Tekla.Structures.Drawing.UI;
using Tekla.Structures.DrawingInternal;
using System.Security.AccessControl;

using Tekla.Structures.Drawing;

using Tekla.Structures.ModelInternal;
using System.Collections;

using Tekla.Structures.Solid;

namespace PPVC_Drawing
{
    public class WHLib
    {
        #region Get template from Tekla

        public List<string> GetAttDim(TSM.Model myModel, string fileExtentsion)
        {
            List<string> attList = new List<string>();
            List<string> distinctAttList = new List<string>();
            //Lấy tất cả path file của app Tekla và folder attribute của model Tekla
            List<string> allPath = EnvironmentFiles.PropertyFileDirectories; //haven't used yet

            if (myModel.GetConnectionStatus())
            {
                string modelPath = myModel.GetInfo().ModelPath;
                string modelAttPaths = modelPath + "\\attributes";
                //Lấy tất cả path trong model Tekla
                //string[] listModelPath = System.IO.Directory.GetDirectories(modelPath);

                string[] filePaths = Directory.GetFiles(modelAttPaths);

                foreach (string filePath in filePaths)
                {
                    if (filePath.Contains($".{fileExtentsion}"))
                    {
                        int fileExtLastPos = filePath.LastIndexOf(".");
                        int fileExtFirstPos = filePath.IndexOf(".");
                        if (fileExtLastPos >= 0)
                        {
                            string filePathWithoutExtention = filePath.Substring(0, fileExtFirstPos);
                            string fileNameWithoutExtention = Path.GetFileName(filePathWithoutExtention);
                            attList.Add(fileNameWithoutExtention);
                        }
                    }

                    //string[] sub = filename.Split('.');
                    //string[] keysub = key.Split('.');
                    //if (sub[sub.Length - 1] == keysub[keysub.Length - 1])
                    //{
                    //    string name = Path.GetFileNameWithoutExtension(filename);
                    //    listAtt.Add(name);
                    //}
                }
                distinctAttList = attList.Distinct().ToList();
                //for (int i = 0; i < listAtt.Count; i++)
                //{
                //    for (int j = i + 1; j < listAtt.Count; j++)
                //    {
                //        if (listAtt[i] == listAtt[j])
                //        {
                //            listAtt.RemoveAt(j);
                //            j--;
                //        }
                //    }
                //}
            }
            return distinctAttList;
        }

        #endregion Get template from Tekla
    }
}