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

            if (myModel.GetConnectionStatus())
            {
                string modelPath = myModel.GetInfo().ModelPath;
                string modelAttPaths = modelPath + "\\attributes";

                string[] filePaths = Directory.GetFiles(modelAttPaths);
                attList.AddRange(from string filePath in filePaths
                                 where filePath.Contains($".{fileExtentsion}")
                                 let fileExtLastPos = filePath.LastIndexOf(".")
                                 let fileExtFirstPos = filePath.IndexOf(".")
                                 where fileExtLastPos >= 0
                                 let filePathWithoutExtention = filePath.Substring(0, fileExtFirstPos)
                                 let fileNameWithoutExtention = Path.GetFileName(filePathWithoutExtention)
                                 select fileNameWithoutExtention);
                /*
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
                }
                */
                distinctAttList = attList.Distinct().ToList();
            }
            return distinctAttList;
        }

        #endregion Get template from Tekla

        #region Find and return list point in top face

        public List<TSG.Point> FindTopFaceOfPartInDrawingView(TSD.Part myDrawingPart)
        {
            Face topFace = null;
            double valueZ = 0;
            List<TSG.Point> pointTop = new List<TSG.Point>();
            TSM.Model mymodel = new TSM.Model();
            myDrawingPart.GetIdentifier();
            TSM.ModelObject obj = mymodel.SelectModelObject(myDrawingPart.ModelIdentifier);
            TSM.Part myPart = obj as TSM.Part;
            TSD.View view = myDrawingPart.GetView() as TSD.View;
            TransformationPlane drawingViewCoordinateSytem = new TransformationPlane(view.DisplayCoordinateSystem);
            if (myPart != null)
            {
                Solid mySolid = myPart.GetSolid();
                FaceEnumerator faceEnumerator = mySolid.GetFaceEnumerator();
                double Zmax = mySolid.MaximumPoint.Z;
                while (faceEnumerator.MoveNext())
                {
                    List<TSG.Point> listPoint = new List<TSG.Point>();
                    Face tempFace = faceEnumerator.Current as Face;
                    LoopEnumerator loopEnumerator = tempFace.GetLoopEnumerator();
                    while (loopEnumerator.MoveNext())
                    {
                        Loop loop = loopEnumerator.Current as Loop;
                        VertexEnumerator vertexEnumerator = loop.GetVertexEnumerator();
                        while (vertexEnumerator.MoveNext())
                        {
                            TSG.Point vertex = vertexEnumerator.Current as TSG.Point;
                            if (!listPoint.Contains(vertex))
                            {
                                listPoint.Add(vertex);
                            }
                        }
                    }
                    if (listPoint.Count > 1)
                    {
                        bool isTop = false;
                        TSG.Point pointStart = listPoint[0] as TSG.Point;
                        for (int i = 0; i < listPoint.Count; i++)
                        {
                            if (Math.Round(listPoint[i].Z, 0) == Math.Round(Zmax, 0))
                            {
                                isTop = true;
                            }
                            else
                            {
                                isTop = false;
                            }
                        }
                        if (isTop == true)
                        {
                            topFace = tempFace;
                            valueZ = listPoint[0].Z;
                            pointTop = listPoint;
                        }
                    }
                }
            }
            Matrix matrix = drawingViewCoordinateSytem.TransformationMatrixToLocal;
            List<TSG.Point> pointTopLocal = new List<TSG.Point>();
            for (int i = 0; i < pointTop.Count; i++)
            {
                TSG.Point A = matrix.Transform(pointTop[i]);
                pointTopLocal.Add(A);
            }
            return pointTopLocal;
        }

        #endregion Find and return list point in top face

        #region Find and return list point in top face

        public List<TSG.Point> FindTopFaceOfPartInMOdel(TSM.Part myPart, TSD.View view)
        {
            Face topFace = null;
            double valueZ = 0;
            List<TSG.Point> pointTop = new List<TSG.Point>();
            TSM.Model mymodel = new TSM.Model();
            TransformationPlane drawingViewCoordinateSytem = new TransformationPlane(view.DisplayCoordinateSystem);
            if (myPart != null)
            {
                Solid mySolid = myPart.GetSolid();
                FaceEnumerator faceEnumerator = mySolid.GetFaceEnumerator();
                double Zmax = mySolid.MaximumPoint.Z;
                while (faceEnumerator.MoveNext())
                {
                    List<TSG.Point> listPoint = new List<TSG.Point>();
                    Face tempFace = faceEnumerator.Current as Face;
                    LoopEnumerator loopEnumerator = tempFace.GetLoopEnumerator();
                    while (loopEnumerator.MoveNext())
                    {
                        Loop loop = loopEnumerator.Current as Loop;
                        VertexEnumerator vertexEnumerator = loop.GetVertexEnumerator();
                        while (vertexEnumerator.MoveNext())
                        {
                            TSG.Point vertex = vertexEnumerator.Current as TSG.Point;
                            if (!listPoint.Contains(vertex))
                            {
                                listPoint.Add(vertex);
                            }
                        }
                    }
                    if (listPoint.Count > 1)
                    {
                        bool isTop = false;
                        TSG.Point pointStart = listPoint[0] as TSG.Point;
                        for (int i = 0; i < listPoint.Count; i++)
                        {
                            if (Math.Round(listPoint[i].Z, 0) == Math.Round(Zmax, 0))
                            {
                                isTop = true;
                            }
                            else
                            {
                                isTop = false;
                            }
                        }
                        if (isTop == true)
                        {
                            topFace = tempFace;
                            valueZ = listPoint[0].Z;
                            pointTop = listPoint;
                        }
                    }
                }
            }
            Matrix matrix = drawingViewCoordinateSytem.TransformationMatrixToLocal;
            List<TSG.Point> pointTopLocal = new List<TSG.Point>();
            for (int i = 0; i < pointTop.Count; i++)
            {
                TSG.Point A = matrix.Transform(pointTop[i]);
                pointTopLocal.Add(A);
            }
            return pointTopLocal;
        }

        #endregion Find and return list point in top face
    }
}