﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace _Ptarmigan
{
    public class IsQuad : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public IsQuad()
          : base("IsQuad", "IsQuad",
              "Gives pattern if polyline shape is a quadrilateral",
              "Ptarmigan", "Curves")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Polygon", "P", "Curves to test.", GH_ParamAccess.item);
            
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Pattern", "Pat", "Pattern determining if curve is quadrilateral", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Curve inputCurve = null;
            DA.GetData(0, ref inputCurve);

            // Sanity checks
            if (inputCurve == null)
            {
                this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Input parameter Curve failed to collect data");
                return;
            }

            Polyline polyline;
            if (!inputCurve.TryGetPolyline(out polyline))
            {
                this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Input Curve could not be converted to Polyline");
                return;
            }

            int segcount = polyline.SegmentCount;
            bool isQuad = (segcount == 4);

            DA.SetData(0, isQuad);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var stream = assembly.GetManifestResourceStream("_Ptarmigan.Resources.IsQuad-24px.png");
                return new System.Drawing.Bitmap(stream);
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("794BEC0A-409F-4972-B593-B850F89FEB09"); }
        }
    }
}