﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Toolbox;
using System.Windows.Forms;
using Toolbox.Library;
using Toolbox.Library.Forms;
using Toolbox.Library.IO;
using FirstPlugin.Forms;
using Syroot.Maths;
using SharpYaml.Serialization;
using FirstPlugin;
using LayoutBXLYT.Revolution;

namespace LayoutBXLYT
{
    public class BRLYT : IFileFormat, IEditorForm<LayoutEditor>, IConvertableTextFormat, ILeaveOpenOnLoad
    {
        public FileType FileType { get; set; } = FileType.Layout;

        public bool CanSave { get; set; }
        public string[] Description { get; set; } = new string[] { "Revolution布局(GUI)" };
        public string[] Extension { get; set; } = new string[] { "*.brlyt" };
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public IFileInfo IFileInfo { get; set; }

        public bool Identify(System.IO.Stream stream)
        {
            using (var reader = new Toolbox.Library.IO.FileReader(stream, true))
            {
                return reader.CheckSignature(4, "RLYT") ||
                       reader.CheckSignature(4, "TYLR");
            }
        }

        public Type[] Types
        {
            get
            {
                List<Type> types = new List<Type>();
                return types.ToArray();
            }
        }

        #region Text Converter Interface
        public TextFileType TextFileType => TextFileType.Xml;
        public bool CanConvertBack => false;

        public string ConvertToString()
        {
            return "";
        }

        public void ConvertFromString(string text)
        {
        }

        #endregion

        public LayoutEditor OpenForm()
        {
            LayoutEditor editor = new LayoutEditor();
            editor.Dock = DockStyle.Fill;
            editor.LoadBxlyt(header);
            return editor;
        }

        public void FillEditor(Form control) {
            ((LayoutEditor)control).LoadBxlyt(header);
        }

        public Header header;
        public void Load(System.IO.Stream stream)
        {
            CanSave = true;

            header = new Header();
            header.Read(new FileReader(stream), this);
        }

        public List<BRLYT> GetLayouts()
        {
            List<BRLYT> animations = new List<BRLYT>();
            if (IFileInfo.ArchiveParent != null)
            {
                foreach (var file in IFileInfo.ArchiveParent.Files)
                {
                    if (Utils.GetExtension(file.FileName) == ".brlyt")
                    {
                        BRLYT brlyt = (BRLYT)file.OpenFile();
                        animations.Add(brlyt);
                    }
                }
            }
            return animations;
        }

        public Dictionary<string, STGenericTexture> GetTextures()
        {
            Dictionary<string, STGenericTexture> textures = new Dictionary<string, STGenericTexture>();
            if (IFileInfo.ArchiveParent != null)
            {
                foreach (var file in IFileInfo.ArchiveParent.Files)
                {
                    try
                    {
                        if (Utils.GetExtension(file.FileName) == ".tpl")
                        {
                            TPL tpl = (TPL)file.OpenFile();
                            file.FileFormat = tpl;
                            foreach (var tex in tpl.TextureList)
                            {
                                //Only need the first texture
                                if (!textures.ContainsKey(tpl.FileName))
                                    textures.Add(tpl.FileName, tex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        STErrorDialog.Show($"加载纹理失败{file.FileName}. ", "布局编辑器", ex.ToString());
                    }
                }
                Console.WriteLine($"纹理{textures.Count}");
            }

            return textures;
        }

        public void Unload()
        {

        }

        public void Save(System.IO.Stream stream) {
            header.Write(new FileWriter(stream));
        }

        //Thanks to SwitchThemes for flags, and enums
        //https://github.com/FuryBaguette/SwitchLayoutEditor/tree/master/SwitchThemesCommon
        public class Header : BxlytHeader, IDisposable
        {
            private string Magic = "RLYT";

            private ushort ByteOrderMark;
            private ushort HeaderSize;

            public LYT1 LayoutInfo { get; set; }
            public TXL1 TextureList { get; set; }
            public MAT1 MaterialList { get; set; }
            public FNL1 FontList { get; set; }
            //   private List<SectionCommon> Sections;
            //  public List<PAN1> Panes = new List<PAN1>();

            public override int AddFont(string name)
            {
                if (!FontList.Fonts.Contains(name))
                    FontList.Fonts.Add(name);

                return FontList.Fonts.IndexOf(name);
            }

            public override int AddTexture(string name)
            {
                if (!TextureList.Textures.Contains(name))
                    TextureList.Textures.Add(name);

                return TextureList.Textures.IndexOf(name);
            }

            public override void RemoveTexture(string name)
            {
                if (TextureList.Textures.Contains(name))
                    TextureList.Textures.Remove(name);

                RemoveTextureReferences(name);
            }

            public int TotalPaneCount()
            {
                int panes = GetPanes().Count;
                int grpPanes = GetGroupPanes().Count;
                return panes + grpPanes;
            }

            public override short AddMaterial(BxlytMaterial material)
            {
                if (material == null) return -1;

                if (!MaterialList.Materials.Contains(material))
                    MaterialList.Materials.Add(material);

                if (material.NodeWrapper == null)
                    material.NodeWrapper = new MatWrapper(material.Name)
                    {
                        Tag = material,
                        ImageKey = "material",
                        SelectedImageKey = "material",
                    };

                if (!MaterialFolder.Nodes.Contains(material.NodeWrapper))
                    MaterialFolder.Nodes.Add(material.NodeWrapper);

                return (short)MaterialList.Materials.IndexOf(material);
            }

            public override List<int> AddMaterial(List<BxlytMaterial> materials)
            {
                List<int> indices = new List<int>();
                foreach (var material in materials)
                    indices.Add(AddMaterial(material));
                return indices;
            }

            public override void TryRemoveMaterial(BxlytMaterial material)
            {
                if (material == null) return;
                material.RemoveNodeWrapper();

                if (MaterialList.Materials.Contains(material))
                    MaterialList.Materials.Remove(material);
            }

            public override void TryRemoveMaterial(List<BxlytMaterial> materials)
            {
                foreach (var material in materials)
                {
                    if (material == null) continue;
                    material.RemoveNodeWrapper();

                    if (MaterialList.Materials.Contains(material))
                        MaterialList.Materials.Remove(material);
                }
            }

            public override BasePane CreateNewNullPane(string name)
            {
                return new PAN1(this, name);
            }

            public override BasePane CreateNewTextPane(string name)
            {
                return new TXT1(this, name);
            }

            public override BasePane CreateNewPicturePane(string name)
            {
                return new PIC1(this, name);
            }

            public override BasePane CreateNewWindowPane(string name)
            {
                return new WND1(this, name);
            }

            public override BasePane CreateNewBoundryPane(string name)
            {
                return new BND1(this, name);
            }

            public override List<string> Textures
            {
                get { return TextureList.Textures; }
            }

            public override List<string> Fonts
            {
                get { return FontList.Fonts; }
            }

            public override List<BxlytMaterial> Materials
            {
                get { return MaterialList.Materials; }
            }

            public override Dictionary<string, STGenericTexture> GetTextures
            {
                get { return ((BRLYT)FileInfo).GetTextures(); }
            }

            public List<PAN1> GetPanes()
            {
                List<PAN1> panes = new List<PAN1>();
                GetPaneChildren(panes, (PAN1)RootPane);
                return panes;
            }

            public override BxlytMaterial GetMaterial(ushort index) {
                return MaterialList.Materials[index];
            }

            public override BxlytMaterial CreateNewMaterial(string name)
            {
                return new Material(name, this);
            }

            public List<GRP1> GetGroupPanes()
            {
                List<GRP1> panes = new List<GRP1>();
                GetGroupChildren(panes, (GRP1)RootGroup);
                return panes;
            }

            private void GetPaneChildren(List<PAN1> panes, PAN1 root)
            {
                panes.Add(root);
                foreach (var pane in root.Childern)
                    GetPaneChildren(panes, (PAN1)pane);
            }

            private void GetGroupChildren(List<GRP1> panes, GRP1 root)
            {
                panes.Add(root);
                foreach (var pane in root.Childern)
                    GetGroupChildren(panes, (GRP1)pane);
            }

            public void Read(FileReader reader, BRLYT brlyt)
            {
                PaneLookup.Clear();
                LayoutInfo = new LYT1();
                TextureList = new TXL1();
                MaterialList = new MAT1();
                FontList = new FNL1();
                RootPane = new PAN1();
                RootGroup = new GRP1();

                FileInfo = brlyt;

                reader.SetByteOrder(true);
                Magic = reader.ReadSignature(4);
                if (Magic == "TYLR")
                    reader.ReverseMagic = true;
                ByteOrderMark = reader.ReadUInt16();
                reader.CheckByteOrderMark(ByteOrderMark);
                Version = reader.ReadUInt16();
                uint FileSize = reader.ReadUInt32();
                HeaderSize = reader.ReadUInt16();
                ushort sectionCount = reader.ReadUInt16();

                IsBigEndian = reader.ByteOrder == Syroot.BinaryData.ByteOrder.BigEndian;
                TextureManager.LayoutFile = this;
                TextureManager.Platform = TextureManager.PlatformType.Wii;

                bool setRoot = false;
                bool setGroupRoot = false;

                BasePane currentPane = null;
                BasePane parentPane = null;

                GroupPane currentGroupPane = null;
                GroupPane parentGroupPane = null;

                reader.SeekBegin(HeaderSize);
                for (int i = 0; i < sectionCount; i++)
                {
                    long pos = reader.Position;

                    string Signature = reader.ReadSignature(4);
                    uint SectionSize = reader.ReadUInt32();

                    SectionCommon section = new SectionCommon(Signature);
                    switch (Signature)
                    {
                        case "lyt1":
                            LayoutInfo = new LYT1(reader);
                            break;
                        case "txl1":
                            TextureList = new TXL1(reader, this);
                            break;
                        case "fnl1":
                            FontList = new FNL1(reader, this);
                            break;
                        case "mat1":
                            MaterialList = new MAT1(reader, this);
                            break;
                        case "pan1":
                            var panel = new PAN1(reader, this);
                            AddPaneToTable(panel);
                            if (!setRoot)
                            {
                                RootPane = panel;
                                setRoot = true;
                            }

                            SetPane(panel, parentPane);
                            currentPane = panel;
                            break;
                        case "pic1":
                            var picturePanel = new PIC1(reader, this);
                            AddPaneToTable(picturePanel);

                            SetPane(picturePanel, parentPane);
                            currentPane = picturePanel;
                            break;
                        case "txt1":
                            var textPanel = new TXT1(reader, this);
                            AddPaneToTable(textPanel);

                            SetPane(textPanel, parentPane);
                            currentPane = textPanel;
                            break;
                        case "bnd1":
                            var boundsPanel = new BND1(reader, this);
                            AddPaneToTable(boundsPanel);

                            SetPane(boundsPanel, parentPane);
                            currentPane = boundsPanel;
                            break;
                        case "wnd1":
                            var windowPanel = new WND1(this, reader);
                            AddPaneToTable(windowPanel);

                            SetPane(windowPanel, parentPane);
                            currentPane = windowPanel;
                            break;
                        case "cnt1":
                            break;
                        case "pas1":
                            if (currentPane != null)
                                parentPane = currentPane;
                            break;
                        case "pae1":
                            currentPane = parentPane;
                            parentPane = currentPane.Parent;
                            break;
                        case "grp1":
                            var groupPanel = new GRP1(reader, this);

                            if (!setGroupRoot)
                            {
                                RootGroup = groupPanel;
                                setGroupRoot = true;
                            }

                            SetPane(groupPanel, parentGroupPane);
                            currentGroupPane = groupPanel;
                            break;
                        case "grs1":
                            if (currentGroupPane != null)
                                parentGroupPane = currentGroupPane;
                            break;
                        case "gre1":
                            currentGroupPane = parentGroupPane;
                            parentGroupPane = currentGroupPane.Parent;
                            break;
                        case "usd1":
                            break;
                        //If the section is not supported store the raw bytes
                        default:
                            section.Data = reader.ReadBytes((int)SectionSize);
                            break;
                    }

                    section.SectionSize = SectionSize;

                    reader.SeekBegin(pos + SectionSize);
                }
            }

            private void SetPane(GroupPane pane, GroupPane parentPane)
            {
                if (parentPane != null)
                {
                    parentPane.Childern.Add(pane);
                    pane.Parent = parentPane;
                }
            }

            private void SetPane(BasePane pane, BasePane parentPane)
            {
                if (parentPane != null)
                {
                    parentPane.Childern.Add(pane);
                    pane.Parent = parentPane;
                }
            }

            public void Write(FileWriter writer)
            {
                RecalculateMaterialReferences();

                writer.SetByteOrder(IsBigEndian);
                writer.WriteSignature(Magic);
                if (Magic == "TYLR")
                    writer.ReverseMagic = true;
                writer.Write(ByteOrderMark);
                writer.Write((ushort)Version);
                writer.Write(uint.MaxValue); //Reserve space for file size later
                writer.Write(HeaderSize);
                writer.Write(ushort.MaxValue); //Reserve space for section count later

                int sectionCount = 1;
                WriteSection(writer, "lyt1", LayoutInfo, () => LayoutInfo.Write(writer, this));
                if (TextureList != null && TextureList.Textures.Count > 0)
                {
                    WriteSection(writer, "txl1", TextureList, () => TextureList.Write(writer, this));
                    sectionCount++;
                }
                if (FontList != null && FontList.Fonts.Count > 0)
                {
                    WriteSection(writer, "fnl1", FontList, () => FontList.Write(writer, this));
                    sectionCount++;
                }
                if (MaterialList != null && MaterialList.Materials.Count > 0)
                {
                    WriteSection(writer, "mat1", MaterialList, () => MaterialList.Write(writer, this));
                    sectionCount++;
                }

                WritePanes(writer, RootPane, this, ref sectionCount);
                WriteGroupPanes(writer, RootGroup, this, ref sectionCount);

                //Write the total section count
                using (writer.TemporarySeek(14, System.IO.SeekOrigin.Begin))
                {
                    writer.Write((ushort)sectionCount);
                }

                //Write the total file size
                using (writer.TemporarySeek(8, System.IO.SeekOrigin.Begin))
                {
                    writer.Write((uint)writer.BaseStream.Length);
                }
            }

            private void WritePanes(FileWriter writer, BasePane pane, LayoutHeader header, ref int sectionCount)
            {
                WriteSection(writer, pane.Signature, pane, () => pane.Write(writer, header));
                sectionCount++;

                if (pane is IUserDataContainer && ((IUserDataContainer)pane).UserData != null)
                {
                    var userData = ((IUserDataContainer)pane).UserData;
                    WriteSection(writer, "usd1", userData, () => userData.Write(writer, this));
                    sectionCount++;
                }

                if (pane.HasChildern)
                {
                    sectionCount += 2;

                    //Write start of children section
                    WriteSection(writer, "pas1", null);

                    foreach (var child in pane.Childern)
                        WritePanes(writer, child, header, ref sectionCount);

                    //Write pae1 of children section
                    WriteSection(writer, "pae1", null);
                }
            }

            private void WriteGroupPanes(FileWriter writer, GroupPane pane, LayoutHeader header, ref int sectionCount)
            {
                WriteSection(writer, pane.Signature, pane, () => pane.Write(writer, header));
                sectionCount++;

                if (pane.HasChildern)
                {
                    sectionCount += 2;

                    //Write start of children section
                    WriteSection(writer, "grs1", null);

                    foreach (var child in pane.Childern)
                        WriteGroupPanes(writer, child, header, ref sectionCount);

                    //Write pae1 of children section
                    WriteSection(writer, "gre1", null);
                }
            }
        }
    }
}
