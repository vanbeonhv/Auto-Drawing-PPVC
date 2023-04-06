using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

namespace PPVC_Drawing
{
    public class WHCastUnitDrawing
    {
        public double WidthDrawing { get; set; }
        public double HeightDrawing { get; set; }
        public TSD.CastUnitDrawing castUnitDrawing { get; set; }
        public TSG.CoordinateSystem coordinateSystem { get; set; }
        public string drawingName { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }

        public WHCastUnitDrawing(TSM.ModelObject modelObject, string drawingAtt, string drawingName, string Title1, string Title2, string Title3)
        {
            TSG.CoordinateSystem coordinateSystem = GetCoordinateSystem(modelObject);
            if (modelObject is TSM.Part)
            {
                TSM.Part part = modelObject as TSM.Part;
                TSM.Assembly assembly = part.GetAssembly();
                Console.WriteLine("touched");
                castUnitDrawing = new TSD.CastUnitDrawing(assembly.Identifier, drawingAtt);
            }
            if (modelObject is TSM.Assembly)
            {
                TSM.Assembly assembly = (TSM.Assembly)modelObject;
                castUnitDrawing = new TSD.CastUnitDrawing(assembly.Identifier, drawingAtt);
            }
            if (modelObject is TSM.Component)
            {
                TSM.Component component = modelObject as TSM.Component;
                TSM.Assembly assembly = component.GetAssembly();
                castUnitDrawing = new TSD.CastUnitDrawing(assembly.Identifier, drawingAtt);
            }
            castUnitDrawing.Insert();
            WidthDrawing = castUnitDrawing.Layout.SheetSize.Width;
            HeightDrawing = castUnitDrawing.Layout.SheetSize.Height;
            drawingName = castUnitDrawing.Name = drawingName;
            title1 = castUnitDrawing.Title1 = Title1;
            title2 = castUnitDrawing.Title2 = Title2;
            title3 = castUnitDrawing.Title3 = Title3;
            castUnitDrawing.Modify();
            castUnitDrawing.CommitChanges();
        }

        private TSG.CoordinateSystem GetCoordinateSystem(TSM.ModelObject selectedModelObject)
        {
            TSG.CoordinateSystem coordinateSystem = new CoordinateSystem();
            if (selectedModelObject is TSM.Part)
            {
                coordinateSystem = (selectedModelObject as TSM.Part).GetCoordinateSystem();
            }
            else if (selectedModelObject is TSM.Assembly)
            {
                coordinateSystem = (selectedModelObject as TSM.Assembly).GetCoordinateSystem();
            }
            else if (selectedModelObject is TSM.BaseComponent)
            {
                coordinateSystem = (selectedModelObject as TSM.BaseComponent).GetCoordinateSystem();
            }
            else
            {
                coordinateSystem = new TSG.CoordinateSystem();
            }
            return coordinateSystem;
        }
    }
}