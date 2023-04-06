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
using System.Data.Common;
using PPVC_Drawing;

namespace AutoDrawing
{
    public class VVHDrawingView
    {
        public TSD.Drawing drawing { get; set; }
        public string ViewAtt { get; set; }

        public VVHDrawingView(string viewATT, TSD.Drawing wHDrawingView)
        {
            ViewAtt = viewATT;
            drawing = wHDrawingView;
        }

        public TSD.View AddView(TSD.Drawing mydrawing, ArrayList parts, TSG.CoordinateSystem coordinateSystem, double column, double row, double selectionX, double selectionY)
        {
            TSD.View view = new TSD.View(mydrawing.GetSheet(), coordinateSystem, coordinateSystem, parts, "standard");

            TSD.View.CreateTopView(mydrawing, LocationPointView(column, row, selectionX, selectionY, "a3"), new TSD.View.ViewAttributes("standard"), out view);
            view.Attributes.LoadAttributes(ViewAtt);
            view.Modify();
            return view;
        }

        public TSD.View AddSectionView(bool IsX, TSD.Drawing mydrawing, TSD.View viewplane, ArrayList parts, TSG.CoordinateSystem coordinateSystem, double column, double row, double selectionX, double selectionY)
        {
            WHLib luci = new WHLib();
            TSM.Part part = parts[0] as TSM.Part;

            List<TSG.Point> listPointPart = luci.FindTopFaceOfPartInMOdel(part, viewplane);
            TransformationPlane planeview = new TransformationPlane(viewplane.DisplayCoordinateSystem);
            TransformationPlane partplane = new TransformationPlane(part.GetCoordinateSystem());
            TSG.Point pointmax = part.GetSolid().MaximumPoint;
            TSG.Point pointmin = part.GetSolid().MinimumPoint;
            TSG.Point pointmaxLocal = planeview.TransformationMatrixToLocal.Transform(pointmax);
            TSG.Point pointminLocal = planeview.TransformationMatrixToLocal.Transform(pointmin);

            double minX = pointminLocal.X;
            double minY = pointminLocal.Y;

            double maxX = pointmaxLocal.X;
            double maxY = pointmaxLocal.Y;

            TSG.Point pointXmin = new TSG.Point(minX, (minY + maxY) / 2, 0);
            TSG.Point pointnXmax = new TSG.Point(maxX, (minY + maxY) / 2, 0);
            TSG.Point pointSectionXmin = pointXmin;
            TSG.Point pointSectionXmax = pointnXmax;

            TSG.Point pointYmin = new TSG.Point((minX + maxX) / 2, minY - 100, 0);
            TSG.Point pointYmax = new TSG.Point((maxX + minX) / 2, maxY + 100, 0);
            TSG.Point pointSectionYmin = pointYmin;
            TSG.Point pointSectionYmax = pointYmax;

            TSD.View view = new TSD.View(mydrawing.GetSheet(), coordinateSystem, coordinateSystem, parts, "standard");

            if (IsX)
            {
                TSD.SectionMark sectionMark = new TSD.SectionMark(viewplane, pointSectionXmin, pointSectionXmax, new SectionMarkBase.SectionMarkAttributes("SECTION MARK_D"));
                TSD.View.CreateSectionView(viewplane, pointSectionXmin, pointSectionXmax, LocationPointView(column, row, selectionX, selectionY, "a3"), Math.Abs(minX), Math.Abs(maxX),
                    new TSD.View.ViewAttributes("CR106_SECTION"), new SectionMarkBase.SectionMarkAttributes("SECTION MARK_D"), out view, out sectionMark);
            }
            else
            {
                TSD.SectionMark sectionMark = new TSD.SectionMark(viewplane, pointSectionYmin, pointSectionYmax, new SectionMarkBase.SectionMarkAttributes("SECTION MARK_D"));
                TSD.View.CreateSectionView(viewplane, pointSectionYmin, pointSectionYmax, LocationPointView(column, row, selectionX, selectionY, "a3"), Math.Abs(minX), maxX,
                    new TSD.View.ViewAttributes("CR106_SECTION"), new SectionMarkBase.SectionMarkAttributes("SECTION MARK_D"), out view, out sectionMark);
            }

            view.Attributes.LoadAttributes("CR106_SECTION");
            view.Modify();
            return view;
        }

        public TSG.Point LocationPointView(double column, double row, double selectX, double selectY, string paperSize)
        {
            TSG.Point location = new TSG.Point();
            double paperHeight = 0.0;
            double paperWidth = 0.0;
            double rightDrawingFrameWidth = 53.0;
            switch (paperSize)
            {
                case "a1":
                    paperHeight = 594.0;
                    paperWidth = 841.0;
                    break;

                case "a2":
                    paperHeight = 420.0;
                    paperWidth = 594;
                    break;

                case "a3":
                    paperHeight = 297.0;
                    paperWidth = 420.0 - rightDrawingFrameWidth;
                    break;

                case "a4":
                    paperHeight = 210.0;
                    paperWidth = 297.0;
                    break;

                default:
                    break;
            }

            double hightCell = paperHeight / row;
            double wightCell = paperWidth / column;
            location.X = wightCell * selectX - wightCell / 2;
            location.Y = hightCell * selectY - hightCell / 2;
            location.Z = 0;
            return location;
        }
    }
}