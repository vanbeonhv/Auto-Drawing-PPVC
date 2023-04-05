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

using System.Collections;
using System.Linq.Expressions;

namespace PPVC_Drawing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            model = new Model();
        }

        public readonly Model model;
        private static readonly DrawingHandler drawingHandler1 = new DrawingHandler();
        public DrawingHandler drawingHandler = drawingHandler1;

        private void btn_getModel_Click(object sender, EventArgs e)
        {
            Picker picker = new Picker();
            TSM.ModelObject modelObject = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "pick any part of assembly");
            string drawingAtt = cbo_castUnitDrawingTemplate.SelectedItem.ToString();
            var castUnitDrawing = new WHCastUnitDrawing(modelObject, drawingAtt);
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
            }
        }
    }
}