﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing;

namespace FirstPlugin.Turbo.CourseMuuntStructs
{
    public class ObjPathGroup : BasePathGroup, IObject
    {
        public List<BaseObjPoint> ObjectPoints = new List<BaseObjPoint>();

        public const string N_UnitIdNum = "UnitIdNum";

        public ObjPathGroup(dynamic bymlNode)
        {
            if (bymlNode is Dictionary<string, dynamic>) Prop = (Dictionary<string, dynamic>)bymlNode;
            else throw new Exception("不是字典");

            foreach (var point in this["ObjPt"])
            {
                ObjectPoints.Add(new BaseObjPoint(point));
            }

            foreach (var point in this["PathPt"])
            {
                PathPoints.Add(new ObjPathPoint(point));
            }
        }

        [Browsable(false)]
        public Dictionary<string, dynamic> Prop { get; set; } = new Dictionary<string, dynamic>();

        public int SplitWidth
        {
            get { return this["SplitWidth"] != null ? this["SplitWidth"] : -1; }
            set { if (value != -1) this["SplitWidth"] = value; }
        }

        public bool IsClosed
        {
            get { return this["Delete"] != null ? this["Delete"] : false; }
            set { this["Delete"] = value; }
        }

        public int PtNum
        {
            get { return this["PtNum"] != null ? this["PtNum"] : -1; }
            set { if (value != -1) this["PtNum"] = value; }
        }

        public int UnitIdNum
        {
            get { return this[N_UnitIdNum] != null ? this[N_UnitIdNum] : -1; }
            set { this[N_UnitIdNum] = value; }
        }

        public dynamic this[string name]
        {
            get
            {
                if (Prop.ContainsKey(name)) return Prop[name];
                else return null;
            }
            set
            {
                if (Prop.ContainsKey(name)) Prop[name] = value;
                else Prop.Add(name, value);
            }
        }
    }

    public class ObjPathPoint : BasePathPoint
    {
        private RenderablePathPoint renderablePoint;

        [Browsable(false)]
        public override RenderablePathPoint RenderablePoint
        {
            get
            {
                if (renderablePoint == null)
                    renderablePoint = new RenderablePathPoint(new Vector4(0f, 0f, 0f, 1f), Translate, Rotate, new OpenTK.Vector3(30), this);
                return renderablePoint;
            }
        }

        [Category("Properties")]
        public int Index
        {
            get { return this["Index"] != null ? this["Index"] : -1; }
            set { if (value != -1) this["Index"] = value; }
        }

        [Category("Properties")]
        public int prm1
        {
            get { return this["prm1"] != null ? this["prm1"] : -1; }
            set { if (value != -1) this["prm1"] = value; }
        }

        [Category("Properties")]
        public int prm2
        {
            get { return this["prm2"] != null ? this["prm2"] : -1; }
            set { if (value != -1) this["prm2"] = value; }
        }

        public ObjPathPoint(dynamic bymlNode)
        {
            if (bymlNode is Dictionary<string, dynamic>) Prop = (Dictionary<string, dynamic>)bymlNode;
            else throw new Exception("不是字典");


            foreach (var point in this["ControlPoints"])
            {
                ControlPoints.Add(new BaseControlPoint(point));
            }
        }
    }
}
