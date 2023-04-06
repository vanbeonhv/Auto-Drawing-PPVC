using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

using TSMUI = Tekla.Structures.Model.UI;
using TSM = Tekla.Structures.Model;

using View = Tekla.Structures.Drawing.View;

using System.Collections;
using System.Linq.Expressions;
using Tekla.Structures.Model.Operations;
using AutoDrawing;

namespace PPVC_Drawing
{
    public partial class MainForm : Form
    {
        public readonly Model model;
        public static readonly DrawingHandler drawingHandler = new DrawingHandler();

        public MainForm()
        {
            InitializeComponent();
            model = new Model();
        }

        private void btn_createDrawing_Click(object sender, EventArgs e)
        {
            Picker picker = new Picker();
            ArrayList allParts = new ArrayList();
            TSM.ModelObjectEnumerator modelObjectEnum = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, "pick all part");
            TSM.ModelObject modelObject = null;
            bool isTouched = false;
            while (modelObjectEnum.MoveNext())
            {
                allParts.Add(modelObjectEnum.Current);
                if (!isTouched)
                {
                    modelObject = modelObjectEnum.Current;
                }
            }
            string drawingAtt = cbo_castUnitDrawingTemplate.SelectedItem.ToString();
            string drawingName = tb_drawingName.Text;
            string title1 = tb_title1.Text;
            string title2 = tb_title2.Text;
            string title3 = tb_title3.Text;
            var castUnitDrawing = new WHCastUnitDrawing(modelObject, drawingAtt, drawingName, title1, title2, title3);
            Console.WriteLine(castUnitDrawing.castUnitDrawing.UpToDateStatus);
            Operation.RunMacro("Perform_Numbering.cs");

            if (cb_createDrawing.Checked)
            {
                drawingHandler.SetActiveDrawing(castUnitDrawing.castUnitDrawing, true);
            }
            else
            {
                drawingHandler.SetActiveDrawing(castUnitDrawing.castUnitDrawing, false);
            }
            //remove unnecessary view
            foreach (DrawingObject item in castUnitDrawing.castUnitDrawing.GetSheet().GetAllViews())
            {
                item.Delete();
                item.Modify();
                castUnitDrawing.castUnitDrawing.CommitChanges();
            }

            VVHDrawingView baseSlabPlan = new VVHDrawingView("PPVC BASE SLAB PLAN", castUnitDrawing.castUnitDrawing);
            baseSlabPlan.AddView(castUnitDrawing.castUnitDrawing, allParts, castUnitDrawing.coordinateSystem, 3, 1, 1, 1);
            VVHDrawingView midWallPlan = new VVHDrawingView("PPVC MID WALL LAYOUT PLAN", castUnitDrawing.castUnitDrawing);
            midWallPlan.AddView(castUnitDrawing.castUnitDrawing, allParts, castUnitDrawing.coordinateSystem, 3, 1, 2, 1);
            VVHDrawingView roofSlabPlan = new VVHDrawingView("PPVC ROOF SLAB LAYOUT PLAN", castUnitDrawing.castUnitDrawing);
            roofSlabPlan.AddView(castUnitDrawing.castUnitDrawing, allParts, castUnitDrawing.coordinateSystem, 3, 1, 3, 1);
        }

        private void btn_setAssembly_Click(object sender, EventArgs e)
        {
            try
            {
                var picker = new TSMUI.Picker();
                TSM.ModelObject modelObject = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick a slab as a main part of assembly");
                ContourPlate mainSlab = null;
                mainSlab = modelObject as ContourPlate;
                if (mainSlab == null)
                {
                    MessageBox.Show("Please pick a slab");
                }
                Assembly mainSlabAssembly = mainSlab.GetAssembly();
                mainSlabAssembly.SetMainPart(mainSlab);

                ModelObjectEnumerator SelectedModelObjs = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, "Pick all part as sub assembly");
                while (SelectedModelObjs.MoveNext())
                {
                    TSM.Part part = SelectedModelObjs.Current as TSM.Part;
                    if (part != null)
                    {
                        Console.WriteLine("check " + part.Name);
                        mainSlabAssembly.Add(part.GetAssembly());
                        if (!mainSlabAssembly.Modify())
                        {
                            Console.WriteLine("Assembly Modify Failed!");
                        }
                    }
                }
                TSM.Part mainPart = mainSlabAssembly.GetMainPart() as TSM.Part;
                ArrayList arObj = new ArrayList();
                arObj.Add(mainPart);
                TSMUI.ModelObjectSelector modelObjectSelector = new TSMUI.ModelObjectSelector();
                modelObjectSelector.Select(arObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (model.GetConnectionStatus())
            {
                List<string> drawingTemplateList = new WHLib().GetAttDim(model, "cud");
                drawingTemplateList.ForEach(template => cbo_castUnitDrawingTemplate.Items.Add(template));
                cbo_castUnitDrawingTemplate.SelectedIndex = 0;
                tb_drawingName.Text = "TGW_WH_S_PPVC_06---_TYP_02";
                tb_title1.Text = "PRECAST FABRICATION DRAWING";
                tb_title2.Text = "PPVC06 @ BLK- 4& 10";
                tb_title3.Text = "LAYOUT";
            }
        }
    }
}