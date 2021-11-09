using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Coursework.AuxForms;

namespace Coursework
{
	enum EDrawType
	{
		Select,
		Pen,
		Marker,
		Erazer,
		Pointer,
		Line,
		Object
	}

	public partial class Form1 : Form
	{
		static int selectCircleSize = 10;

		int circleOffset = selectCircleSize / 2;

		class CanvasObject
		{
			protected bool m_bTransformationDirty = false;

			protected GraphicsPath m_ObjectPath; // Initial object reference, always located at 0;0 and has it's original width/height, 0 rotation
			protected GraphicsPath m_ObjectPathTransformed; // Current state of the object with all the transformations applied

			public float m_flAbsRotation; // 0-359 rotation value, applied right at the Get'ter

			public RectangleF m_CurrentRectRotated; // ABS translated path rotated bounds
			public RectangleF m_CurrentRect; // ABS translated path bounds
			public RectangleF m_InitialRect; // State stored before transformation

			public bool m_bDrawEdge = true;
			public Pen m_Pen;
			public Pen m_PenOutline;

			public CanvasObject(Pen pen, Pen outlinePen)
			{
				this.m_Pen = pen;
				this.m_PenOutline = outlinePen;
				this.m_ObjectPath = CreateObject();
				//this.m_CurrentRect = this.m_ObjectPath.GetBounds();
			}

			//public PointF GetCollisionBoundsCenter()
			//{
			//	return new PointF( m_InitialRect.X + m_InitialRect.Width * 0.5f, m_InitialRect.Y + m_InitialRect.Height * 0.5f );
			//	//return new PointF( m_CurrentRect.X + m_CurrentRect.Width * 0.5f, m_CurrentRect.Y + m_CurrentRect.Height * 0.5f );
			//}

			public void UpdateObjectTransformations()
			{
				if (m_bTransformationDirty)
				{
					m_bTransformationDirty = false;

					/*
					* Specifically to allow negative scaling:
					* - m_CurrentRect needs to be adjusted every time there is either of negative sides
					* - X/Y will be translated and W/H will be forced positive since we do not care about path layout
					*/
					PointF vecAbsTranslate = new PointF(m_CurrentRect.X, m_CurrentRect.Y);

					if (m_CurrentRect.Width < 0f)
						vecAbsTranslate.X += m_CurrentRect.Width;

					if (m_CurrentRect.Height < 0f)
						vecAbsTranslate.Y += m_CurrentRect.Height;

					// Make a copy and LETS GOOO
					m_ObjectPathTransformed = (GraphicsPath) m_ObjectPath.Clone();

					Matrix rgTransform = new Matrix();

					// Move it
					rgTransform.Translate(vecAbsTranslate.X, vecAbsTranslate.Y);

					// Remap ABCD scaling
					PointF flScale = new PointF();
					RectangleF bbox = m_ObjectPath.GetBounds();
					flScale.X = m_CurrentRect.Width / bbox.Width;
					flScale.Y = m_CurrentRect.Height / bbox.Height;
					rgTransform.Scale(flScale.X, flScale.Y);

					// Apply it
					//m_ObjectPath.Transform( rgTransform );
					m_ObjectPathTransformed.Transform(rgTransform);
					rgTransform.Reset();

					// Correct scaling translation offset (why)
					bbox = m_ObjectPathTransformed.GetBounds();
					rgTransform.Translate(vecAbsTranslate.X - bbox.X, vecAbsTranslate.Y - bbox.Y);
					m_ObjectPathTransformed.Transform(rgTransform);
					rgTransform.Reset();

					if (m_flAbsRotation != 0f)
					{
						rgTransform.RotateAt(m_flAbsRotation, new PointF(m_CurrentRect.X + m_CurrentRect.Width * 0.5f,m_CurrentRect.Y + m_CurrentRect.Height * 0.5f));
						m_ObjectPathTransformed.Transform(rgTransform);
						rgTransform.Reset();
					}

					m_CurrentRectRotated = m_ObjectPathTransformed.GetBounds();

					rgTransform.Dispose();
				}
			}

			public RectangleF GetUntransformedRect()
			{
				return m_ObjectPath.GetBounds();
			}

			public GraphicsPath GetPath()
			{
				UpdateObjectTransformations();
				return m_ObjectPathTransformed;
			}

			public void CommitTransformations()
			{
				m_CurrentRect = m_CurrentRectRotated;
				m_ObjectPath = m_ObjectPathTransformed;
				m_flAbsRotation = 0f;

				if (m_CurrentRect.Width < 0f)
				{
					m_CurrentRect.X += m_CurrentRect.Width;
					m_CurrentRect.Width = -m_CurrentRect.Width;
				}

				if (m_CurrentRect.Height < 0f)
				{
					m_CurrentRect.Y += m_CurrentRect.Height;
					m_CurrentRect.Height = -m_CurrentRect.Height;
				}
			}

			public void SetPos(float X, float Y)
			{
				m_CurrentRect.X = X;
				m_CurrentRect.Y = Y;
				m_bTransformationDirty = true;
			}

			public void SetPosX(float X)
			{
				m_CurrentRect.X = X;
				m_bTransformationDirty = true;
			}

			public void SetPosY(float Y)
			{
				m_CurrentRect.Y = Y;
				m_bTransformationDirty = true;
			}

			public void SetSize(float W, float H)
			{
				m_CurrentRect.Width = W;
				m_CurrentRect.Height = H;
				m_bTransformationDirty = true;
			}

			public void SetWidth(float W)
			{
				SetSize(W, m_CurrentRect.Height);
			}

			public void SetHeight(float H)
			{
				SetSize(m_CurrentRect.Width, H);
			}

			public void SetRotation(float flRotation)
			{
				m_flAbsRotation = flRotation;
				m_bTransformationDirty = true;
			}

			static GraphicsPath CreateObject()
			{
				// LESS GO
				//   🎩
				// 👉😄👈
				//
				int spacing = 30;
				GraphicsPath myPath = new GraphicsPath();
				int figureone_width;


				//Figure 1
				//   1	   
				//  ._______  ->
				//  /		|
				// /		|
				//3|		| 2
				// \		|
				//  \		|
				//   \------|
				//


				myPath.StartFigure();

				int part1 = 40;
				int part2 = 190;
				int part3 = 64;
				figureone_width = part1 + 80;
				//
				//   ->
				//   _______
				//   
				// 
				//
				// 
				// 
				//  
				//
				Point start = new Point(80, 150);
				Point end = new Point(start.X + part1, start.Y);

				myPath.AddLine(start, end);
				//
				//   ->
				//   _______
				//		  |
				//		  |
				//		  |
				//		  |
				//		  |
				//		  |
				//
				start = end;
				end = new Point(start.X, start.Y + part2);
				myPath.AddLine(start, end);
				//
				//   ->
				//   _______
				//		  |
				//		  |
				//		  |
				//		  |
				//		  |
				//		  |
				//   -------|
				start = end;
				end = new Point(start.X - part1, start.Y);
				myPath.AddLine(start, end);
				//Figure 1
				//		  
				//   _______  
				//  /	   | 
				// /		|
				// |		| 
				// \		|
				//  \	   |
				//   \------|
				//
				start = end;
				end = new Point(start.X, start.Y - part2);

				Point[] points = new Point[]
				{
					start,
					new Point(start.X - part3 + (part3 / 5), start.Y + ((end.Y - start.Y) / 2) + (part2 / 5)), // lower

					new Point(start.X - part3, start.Y + ((end.Y - start.Y) / 2)), // center

					new Point(start.X - part3 + (part3 / 5), start.Y + ((end.Y - start.Y) / 2) - (part2 / 5)), // upper

					end
				};
				myPath.AddCurve(points, 0.5f);

				myPath.CloseFigure();

				//Rectangle
				//  ____1___
				// |		|
				// |		|
				// |		|2
				// |		|
				// |		|
				// |________|
				//
				myPath.StartFigure();
				part1 = 80;
				part2 = 190;
				int figuretwo_width = part1;
				myPath.AddRectangle(new Rectangle(figureone_width + spacing, 150, part1, part2));
				myPath.CloseFigure();


				//Arrow Parts
				//	 -->	
				//	1   2>|\
				// |.-------| \ <3
				//4 \		  \
				//  /		  /
				// |--------| / 
				//		  |/
				//
				//

				//	  
				// -----
				//
				// 
				myPath.StartFigure();

				part1 = 175;
				part2 = 90;
				part3 = 356;
				int part4 = 190;
				start = new Point(figureone_width + spacing + figuretwo_width + spacing, 150);
				end = new Point(start.X + part1, start.Y);
				myPath.AddLine(start, end);
				//	  |
				// -----| 
				//
				// 
				start = end;
				end = new Point(start.X, start.Y - part2);
				myPath.AddLine(start, end);
				//	  |\
				// -----| \
				//
				//
				start = end;
				end = new Point(start.X + part3, (start.Y + (part4 / 2) + part2));
				myPath.AddLine(start, end);
				//	  |\
				// -----| \
				//		/
				//	   /
				start = end;
				end = new Point(start.X - part3, (start.Y + (part4 / 2)) + part2);
				myPath.AddLine(start, end);
				//	  |\
				// -----| \
				//	  | /
				//	  |/
				start = end;
				end = new Point(start.X, (start.Y - part2));
				myPath.AddLine(start, end);
				//	  |\
				// -----| \
				// -----| /
				//	  |/
				start = end;
				end = new Point(start.X - part1, start.Y);
				myPath.AddLine(start, end);
				//	  |\
				// \----| \ UP!
				// /----| /
				//	  |/
				start = end;
				end = new Point(start.X, start.Y - part4);


				myPath.AddCurve(new Point[] {start, new Point(start.X + (part1 / 4), start.Y + ((end.Y - start.Y) / 2)), end}, 0.5f);
				myPath.CloseFigure();
				return myPath;
			}
		}

		private static int nMaxLayerId = 0;

		class CanvasLayer
		{
			public CanvasLayer()
			{
				numid = nMaxLayerId++;
			}

			public Bitmap bitmap;
			public List<CanvasObject> objects = new List<CanvasObject>();
			private int numid = 0;

			public override string ToString()
			{
				return "Layer " + numid;
			}
		}

		enum MoveTypeMask_t : int
		{
			MOVETYPE_DRAGDROP = 0,
			MOVETYPE_LEFT = (1 << 0),
			MOVETYPE_RIGHT = (1 << 1),
			MOVETYPE_UP = (1 << 2),
			MOVETYPE_DOWN = (1 << 3),
			MOVETYPE_ROTATE = (1 << 4)
		};

		static class PicCanvasSettings
		{
			public static int W;
			public static int H;
			public static List<CanvasLayer> Layers = new List<CanvasLayer>();
			public static EDrawType m_nSelectedTool = EDrawType.Pen;
			public static Point m_PrevMousePos;
			public static bool m_bIsMouseHeld = false;
			public static int CurrentLayerId = 0;
			public static bool ShouldRedraw = true;
			public static Color color1 = Color.Black;
			public static Color color2 = Color.White;
			public static Point m_InitialMouse = new Point(0, 0);
			public static float m_flInitialAngle = 0.0f;
			public static Bitmap framebuffer;
			public static MoveTypeMask_t m_nMoveType = MoveTypeMask_t.MOVETYPE_DRAGDROP;
			public static CanvasObject SelectedObject { get; set; } // Latest selected object
			public static bool Debug { get; set; }

			public static void ClearFramebuffer()
			{
				using (Graphics gh = Graphics.FromImage(framebuffer))
				{
					gh.Clear(Color.Transparent);
				}
			}

			public static CanvasObject AddObject(Pen pen, Pen outlinePen)
			{
				CanvasObject obj = new CanvasObject(pen, outlinePen);
				GetCurrentLayer().objects.Add(obj);
				return obj;
			}
		}

		public Form1()
		{
			InitializeComponent();
			KeyPreview = true;
			InitCanvas(600, 600);
		}

		static CanvasLayer GetCurrentLayer()
		{
			return PicCanvasSettings.Layers[PicCanvasSettings.CurrentLayerId];
		}

		enum EMouseType
		{
			CLICK,
			UNCLICK,
			MOVE
		}

		void HandleDrawing(MouseEventArgs e, EMouseType mouseType)
		{
			if (PicCanvasSettings.m_bIsMouseHeld)
			{
				Bitmap currentBitMap = GetCurrentLayer().bitmap;
				Graphics graphics = Graphics.FromImage(currentBitMap);
				var optgraphics = Graphics.FromImage(PicCanvasSettings.framebuffer);
				optgraphics.Clear(Color.Transparent);

				switch (PicCanvasSettings.m_nSelectedTool)
				{
					case EDrawType.Pointer:

						if (mouseType == EMouseType.CLICK)
						{
							PicCanvasSettings.SelectedObject = null;
							PicCanvasSettings.m_nMoveType = MoveTypeMask_t.MOVETYPE_DRAGDROP;

							int mousehitsize = 30;

							//trace and set selected item
							for (int i = GetCurrentLayer().objects.Count - 1; i >= 0; i--)
							{
								CanvasObject layerobject = GetCurrentLayer().objects[i];
								RectangleF objectbounds = layerobject.m_CurrentRectRotated;

								if (objectbounds.IntersectsWith(new RectangleF(e.X - mousehitsize, e.Y - mousehitsize,mousehitsize * 2, mousehitsize * 2)))
								{
									PicCanvasSettings.SelectedObject = layerobject;
									PicCanvasSettings.SelectedObject.m_InitialRect = PicCanvasSettings.SelectedObject.m_CurrentRectRotated;
									RectangleF RectBBox = PicCanvasSettings.SelectedObject.m_InitialRect;
									PointF vecBBoxCenter = new PointF(RectBBox.X + RectBBox.Width * 0.5f,RectBBox.Y + RectBBox.Height * 0.5f);
									PointF vecCursor = new PointF(e.X - vecBBoxCenter.X, e.Y - vecBBoxCenter.Y);
									PointF zeroLine = new PointF(1f, 0f);
									PicCanvasSettings.m_flInitialAngle = -layerobject.m_flAbsRotation + (float) (Math.Atan2(vecCursor.Y * zeroLine.X - vecCursor.X * zeroLine.Y, vecCursor.X * zeroLine.X + vecCursor.Y * zeroLine.Y) * (180f / Math.PI));

									//UPDATE UI
									track_pen_thickness.Value = (int) layerobject.m_PenOutline.Width;
									btn_color1.ForeColor = layerobject.m_Pen.Color;
									btn_color2.ForeColor = layerobject.m_PenOutline.Color;
									txt_object_x.Text = layerobject.m_CurrentRectRotated.X.ToString();
									txt_object_y.Text = layerobject.m_CurrentRectRotated.Y.ToString();
									txt_object_w.Text = ((int) layerobject.m_CurrentRectRotated.Width).ToString();
									txt_object_h.Text = ((int) layerobject.m_CurrentRectRotated.Height).ToString();
									txt_object_rot.Text = ((int) layerobject.m_flAbsRotation).ToString();


									cb_drawedge.Checked = layerobject.m_bDrawEdge;
									
									if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X - circleOffset, objectbounds.Y - circleOffset,selectCircleSize, selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_LEFT | MoveTypeMask_t.MOVETYPE_UP;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width / 2) - circleOffset,objectbounds.Y - circleOffset, selectCircleSize, selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_UP;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,objectbounds.Y - circleOffset, selectCircleSize, selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_RIGHT | MoveTypeMask_t.MOVETYPE_UP;
									}
									else if (new RectangleF(e.X - (mousehitsize / 2), e.Y - (mousehitsize / 2), mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,	objectbounds.Y - circleOffset + (objectbounds.Height / 2), selectCircleSize,selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_RIGHT;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize, selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_RIGHT | MoveTypeMask_t.MOVETYPE_DOWN;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width / 2) - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize,selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_DOWN;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize,	selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |=MoveTypeMask_t.MOVETYPE_LEFT | MoveTypeMask_t.MOVETYPE_DOWN;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height / 2), selectCircleSize,selectCircleSize)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_LEFT;
									}
									else if (new RectangleF(e.X, e.Y, mousehitsize, mousehitsize).IntersectsWith(new RectangleF(objectbounds.X + (objectbounds.Width),objectbounds.Y + (objectbounds.Height), selectCircleSize * 3,selectCircleSize * 3)))
									{
										PicCanvasSettings.m_nMoveType |= MoveTypeMask_t.MOVETYPE_ROTATE;
									}

									break;
								}
							}
						}
						
						else if (mouseType == EMouseType.MOVE)
						{
							if (PicCanvasSettings.SelectedObject != null)
							{
								if (PicCanvasSettings.m_nMoveType == MoveTypeMask_t.MOVETYPE_DRAGDROP)
								{
									PicCanvasSettings.SelectedObject.SetPos(e.X + ((int) (PicCanvasSettings.SelectedObject.m_InitialRect.X - PicCanvasSettings.m_InitialMouse.X)), e.Y + ((int) (PicCanvasSettings.SelectedObject.m_InitialRect.Y - PicCanvasSettings.m_InitialMouse.Y)));
								}
								else if (PicCanvasSettings.m_nMoveType == MoveTypeMask_t.MOVETYPE_ROTATE)
								{
									RectangleF RectBBox = PicCanvasSettings.SelectedObject.m_InitialRect;
									PointF vecBBoxCenter = new PointF(RectBBox.X + RectBBox.Width * 0.5f, RectBBox.Y + RectBBox.Height * 0.5f);
									PointF vecCursor = new PointF(e.X - vecBBoxCenter.X, e.Y - vecBBoxCenter.Y);
									PointF zeroLine = new PointF(1f, 0f);
									float flAngleDiff = (float) (Math.Atan2(vecCursor.Y * zeroLine.X - vecCursor.X * zeroLine.Y, vecCursor.X * zeroLine.X + vecCursor.Y * zeroLine.Y) * (180f / Math.PI));
									PicCanvasSettings.SelectedObject.SetRotation(flAngleDiff - PicCanvasSettings.m_flInitialAngle);
								}
								else
								{
									float flDeltaX = 0f;
									float flDeltaY = 0f;

									if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_LEFT) != 0)
									{
										flDeltaX = PicCanvasSettings.m_InitialMouse.X - e.X;
									}
									else if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_RIGHT) != 0)
									{
										flDeltaX = e.X - PicCanvasSettings.m_InitialMouse.X;
									}

									if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_UP) != 0)
									{
										flDeltaY = PicCanvasSettings.m_InitialMouse.Y - e.Y;
									}
									else if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_DOWN) != 0)
									{
										flDeltaY = e.Y - PicCanvasSettings.m_InitialMouse.Y;
									}

									if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_LEFT) != 0)
									{
										PicCanvasSettings.SelectedObject.SetPosX(PicCanvasSettings.SelectedObject.m_InitialRect.X - flDeltaX);
										PicCanvasSettings.SelectedObject.SetWidth(PicCanvasSettings.SelectedObject.m_InitialRect.Width + flDeltaX);
									}
									else if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_RIGHT) != 0)
									{
										PicCanvasSettings.SelectedObject.SetWidth(PicCanvasSettings.SelectedObject.m_InitialRect.Width + flDeltaX);
									}

									if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_UP) != 0)
									{
										flDeltaY = PicCanvasSettings.m_InitialMouse.Y - e.Y;
										PicCanvasSettings.SelectedObject.SetPosY(PicCanvasSettings.SelectedObject.m_InitialRect.Y - flDeltaY);
										PicCanvasSettings.SelectedObject.SetHeight(PicCanvasSettings.SelectedObject.m_InitialRect.Height + flDeltaY);
									}
									else if ((PicCanvasSettings.m_nMoveType & MoveTypeMask_t.MOVETYPE_DOWN) != 0)
									{
										PicCanvasSettings.SelectedObject.SetHeight(PicCanvasSettings.SelectedObject.m_InitialRect.Height + flDeltaY);
									}
								}
							}
						}

						if (PicCanvasSettings.SelectedObject != null)
						{
							//Draw rectangle!
							//		-> -> -> -> -> -> ->
							//  1///////////////////////////2
							//  /////////////////////////////
							//  /////////////////////////////
							//  4///////////////////////////3
							//1
							GraphicsPath linepath = new GraphicsPath();
							linepath.StartFigure();
							RectangleF objectbounds = PicCanvasSettings.SelectedObject.m_CurrentRectRotated;
							PointF start = new PointF(objectbounds.X, objectbounds.Y);
							PointF end = new PointF(start.X + objectbounds.Width, start.Y);

							linepath.AddLine(start, end);
							if (PicCanvasSettings.Debug)
							{
								optgraphics.DrawString($"p1 X = {(int) start.X} Y = {(int) start.Y}",	new Font("Arial", 12), Brushes.Black, start);
								optgraphics.DrawString($"p2 X = {(int) end.X} Y = {(int) end.Y}", new Font("Arial", 12),Brushes.Black, end);
							}

							//2 
							start = end;
							end = new PointF(start.X, start.Y + objectbounds.Height);
							linepath.AddLine(start, end);
							if (PicCanvasSettings.Debug)
							{
								optgraphics.DrawString($"p3 X = {(int) end.X} Y = {(int) end.Y}", new Font("Arial", 12),Brushes.Black, end);
							}

							//3
							start = end;
							end = new PointF(start.X - objectbounds.Width, start.Y);
							if (PicCanvasSettings.Debug)
							{
								optgraphics.DrawString( $"p4 X = {(int) end.X} Y = {(int) end.Y}", new Font( "Arial", 12 ), Brushes.Black, end );
							}

							linepath.AddLine(start, end);

							//4 -> 1
							start = end;
							end = new PointF(start.X, start.Y - objectbounds.Height);
							linepath.AddLine(start, end);
							linepath.CloseFigure();

							optgraphics.DrawPath(new Pen(Color.FromArgb(128, Color.Gray)), linepath);
							//Draw rectangles

							int circleOffset = selectCircleSize / 2;
							RectangleF[] rectangles = new RectangleF[]
							{
								new RectangleF(objectbounds.X - circleOffset, objectbounds.Y - circleOffset,selectCircleSize, selectCircleSize), //1
								new RectangleF(objectbounds.X + (objectbounds.Width / 2) - circleOffset,objectbounds.Y - circleOffset, selectCircleSize, selectCircleSize), //1.5
								new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,objectbounds.Y - circleOffset, selectCircleSize, selectCircleSize), //2
								new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height / 2), selectCircleSize,selectCircleSize), //2.5
								new RectangleF(objectbounds.X + (objectbounds.Width) - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize,selectCircleSize), //3
								new RectangleF(objectbounds.X + (objectbounds.Width / 2) - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize,selectCircleSize), //3.5
								new RectangleF(objectbounds.X - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height), selectCircleSize,selectCircleSize), //4
								new RectangleF(objectbounds.X - circleOffset,objectbounds.Y - circleOffset + (objectbounds.Height / 2), selectCircleSize,selectCircleSize) //4.5
							};
							foreach (var rect in rectangles)
							{
								optgraphics.DrawEllipse(new Pen(Color.FromArgb(128, Color.Gray), selectCircleSize / 4), rect);
							}

							optgraphics.DrawArc(new Pen(Color.Gray, selectCircleSize / 3),new RectangleF(objectbounds.X + (objectbounds.Width),objectbounds.Y + (objectbounds.Height), selectCircleSize * 3, selectCircleSize * 3),0, 90);
							if(PicCanvasSettings.Debug)
							{
								optgraphics.DrawString( $"Rotation = {PicCanvasSettings.SelectedObject.m_flAbsRotation}", new Font( "Arial", 14 ), Brushes.Black, objectbounds.X + ( objectbounds.Width ), objectbounds.Y + ( objectbounds.Height ) + 30 );
								optgraphics.DrawString( $"BboxX = {objectbounds.X}, RectY = {objectbounds.Y}", new Font( "Arial", 14 ), Brushes.Black, objectbounds.X, objectbounds.Y + objectbounds.Height + 30 );
								optgraphics.DrawString( $"BboxW = {objectbounds.Width}, BboxH = {objectbounds.Height}", new Font( "Arial", 14 ), Brushes.Black, objectbounds.X, objectbounds.Y + objectbounds.Height + 30 + 30 );
							}
						}

						break;

					case EDrawType.Line:
						if (mouseType == EMouseType.UNCLICK)
						{
							PicCanvasSettings.ClearFramebuffer();
							graphics.DrawLine(new Pen(PicCanvasSettings.color1, track_pen_thickness.Value), e.X, e.Y,PicCanvasSettings.m_InitialMouse.X, PicCanvasSettings.m_InitialMouse.Y);
						}
						else if (mouseType == EMouseType.MOVE)
						{
							optgraphics.Clear(Color.Transparent);
							optgraphics.DrawLine(new Pen(PicCanvasSettings.color1, track_pen_thickness.Value), e.X, e.Y,PicCanvasSettings.m_InitialMouse.X, PicCanvasSettings.m_InitialMouse.Y);
						}

						break;
					case EDrawType.Object:
						if (mouseType == EMouseType.CLICK)
						{
							PicCanvasSettings.ClearFramebuffer();

							Color objectcolor;

							if ((e.Button & MouseButtons.Left) != 0)
							{
								objectcolor = PicCanvasSettings.color1;
							}
							else
							{
								break;
							}

							PicCanvasSettings.SelectedObject = PicCanvasSettings.AddObject(new Pen(objectcolor),new Pen(PicCanvasSettings.color2, (float) track_pen_thickness.Value));
							PicCanvasSettings.SelectedObject.SetPos(PicCanvasSettings.m_InitialMouse.X,	PicCanvasSettings.m_InitialMouse.Y);
						}
						else if (mouseType == EMouseType.MOVE)
						{
							if (PicCanvasSettings.SelectedObject != null)
							{
								float W = e.X - PicCanvasSettings.m_InitialMouse.X;
								float H = e.Y - PicCanvasSettings.m_InitialMouse.Y;

								if (ModifierKeys == Keys.Shift)
								{
									W = H = (float) (Math.Sqrt((double) (W * W + H * H)) / 2);

									RectangleF UntransformedRect =PicCanvasSettings.SelectedObject.GetUntransformedRect();

									if (UntransformedRect.Width > UntransformedRect.Height)
									{
										W *= UntransformedRect.Width / UntransformedRect.Height;
									}
									else
									{
										H *= UntransformedRect.Height / UntransformedRect.Width;
									}
								}

								PicCanvasSettings.SelectedObject.SetSize(W, H);
							}
						}

						break;
					case EDrawType.Pen:
						if (mouseType != EMouseType.MOVE)
						{
							break;
						}

						Color color;
						if ((e.Button & MouseButtons.Left) != 0)
						{
							color = PicCanvasSettings.color1;
						}
						else if ((e.Button & MouseButtons.Right) != 0)
						{
							color = PicCanvasSettings.color2;
						}
						else
						{
							break;
						}

						graphics.DrawLine(	new Pen(color, track_pen_thickness.Value)	{EndCap = LineCap.Round, StartCap = LineCap.Round}, PicCanvasSettings.m_PrevMousePos.X,PicCanvasSettings.m_PrevMousePos.Y, e.X, e.Y);
						break;
					case EDrawType.Erazer:
						if (mouseType != EMouseType.MOVE)
						{
							break;
						}

						if ((e.Button & MouseButtons.Left) == 0)
						{
							break;
						}
						int nThickness = track_pen_thickness.Value;
						for (int startx = Math.Abs(e.X - (nThickness / 2));startx < e.X + (nThickness / 2);++startx)
						{
							for (int starty = Math.Abs(e.Y - (nThickness / 2));	starty < e.Y + (nThickness / 2);	++starty)
							{
								if (starty <= PicCanvasSettings.H - 1 && startx <= PicCanvasSettings.W - 1)
								{
									currentBitMap.SetPixel(startx, starty, Color.Transparent);
								}
							}
						}

						break;
					case EDrawType.Marker:

						if (mouseType != EMouseType.MOVE)
						{
							break;
						}

						Color markercolor;
						if ((e.Button & MouseButtons.Left) != 0)
						{
							markercolor = PicCanvasSettings.color1;
						}
						else if ((e.Button & MouseButtons.Right) != 0)
						{
							markercolor = PicCanvasSettings.color2;
						}
						else
						{
							break;
						}

						graphics.DrawLine(new Pen(Color.FromArgb(80, markercolor), track_pen_thickness.Value)	{EndCap = LineCap.Round, StartCap = LineCap.Round}, PicCanvasSettings.m_PrevMousePos.X, PicCanvasSettings.m_PrevMousePos.Y, e.X, e.Y);

						break;
				}

				PicCanvasSettings.ShouldRedraw = true;
				graphics.Dispose();
				picture_canvas.Invalidate();
			}
			else
			{
				PicCanvasSettings.m_nMoveType = MoveTypeMask_t.MOVETYPE_DRAGDROP;
			}
		}

		void CreateNewLayer(Color color)
		{
			CanvasLayer layer = new CanvasLayer();
			layer.bitmap = new Bitmap(PicCanvasSettings.W, PicCanvasSettings.H);
			layer.bitmap.MakeTransparent(Color.Transparent);
			Graphics g = Graphics.FromImage(layer.bitmap);
			g.Clear(color);
			g.Dispose();
			PicCanvasSettings.Layers.Add(layer);
			combo_layers.Items.Add(layer);
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewFileForm form = new NewFileForm();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				InitCanvas((int) form.num_height.Value, (int) form.num_width.Value);
			}
		}

		void InitCanvas(int h, int w)
		{
			foreach (var layer in PicCanvasSettings.Layers)
			{
				layer.bitmap.Dispose();
			}

			PicCanvasSettings.Layers.Clear();

			picture_canvas.Width = PicCanvasSettings.W = h;
			picture_canvas.Height = PicCanvasSettings.H = w;
			//for debug
			//picture_canvas.ForeColor = Color.Red;
			CreateChessBoard();
			PicCanvasSettings.framebuffer = new Bitmap(w, h);
			PicCanvasSettings.framebuffer.MakeTransparent(Color.Transparent);
			CreateNewLayer(Color.White);
			combo_layers.SelectedIndex = 0;
		}

		void CreateChessBoard()
		{
			CanvasLayer chesslayer = new CanvasLayer();
			chesslayer.bitmap = new Bitmap(PicCanvasSettings.W, PicCanvasSettings.H);
			Graphics g = Graphics.FromImage(chesslayer.bitmap);
			g.Clear(Color.White);
			using (SolidBrush whiteBrush = new SolidBrush(Color.White))
			using (SolidBrush grayBrush = new SolidBrush(Color.Gray))
			{
				for (int x = 0; x < PicCanvasSettings.W; x += 8)
				{
					for (int y = 0; y < PicCanvasSettings.H; y += 8)
					{
						g.FillRectangle(((x & 8) ^ (y & 8)) != 0 ? whiteBrush : grayBrush, x, y, 8, 8);
					}
				}
			}

			g.Dispose();
			PicCanvasSettings.Layers.Add(chesslayer);
		}

		void Redraw()
		{
			if (PicCanvasSettings.ShouldRedraw)
			{
				Bitmap result = new Bitmap(PicCanvasSettings.W, PicCanvasSettings.H);

				using (Graphics g = Graphics.FromImage(result))
				{
					foreach (var layer in PicCanvasSettings.Layers)
					{
						g.DrawImage(layer.bitmap, Point.Empty);

						foreach (CanvasObject curobject in layer.objects)
						{
							//curobject.m_Pen
							g.FillPath(new SolidBrush(curobject.m_Pen.Color), curobject.GetPath());

							if (curobject.m_bDrawEdge)
								g.DrawPath(curobject.m_PenOutline, curobject.GetPath());
						}
					}

					g.DrawImage(PicCanvasSettings.framebuffer, Point.Empty);
				}

				if (picture_canvas.Image != null)
				{
					picture_canvas.Image.Dispose();
				}

				picture_canvas.Image = result;
			}

			PicCanvasSettings.ShouldRedraw = false;
		}

		private void picture_canvas_MouseDown(object sender, MouseEventArgs e)
		{
			PicCanvasSettings.m_bIsMouseHeld = true;
			PicCanvasSettings.m_InitialMouse = e.Location;
			HandleDrawing(e, EMouseType.CLICK);
		}

		private void picture_canvas_MouseUp(object sender, MouseEventArgs e)
		{
			HandleDrawing(e, EMouseType.UNCLICK);
			PicCanvasSettings.m_bIsMouseHeld = false;

			if (PicCanvasSettings.SelectedObject != null)
				PicCanvasSettings.SelectedObject.CommitTransformations();
		}

		private void picture_canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (PicCanvasSettings.Layers.Count > 0)
			{
				if (e.X != PicCanvasSettings.m_PrevMousePos.X || e.X != PicCanvasSettings.m_PrevMousePos.X)
				{
					HandleDrawing(e, EMouseType.MOVE);

					PicCanvasSettings.m_PrevMousePos.X = e.X;
					PicCanvasSettings.m_PrevMousePos.Y = e.Y;
				}
			}
		}

		private void picture_canvas_Paint(object sender, PaintEventArgs e)
		{
			if (PicCanvasSettings.Layers.Count > 0)
			{
				Redraw();
			}
		}

		private void btn_pointer_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Pointer;
		}

		private void btn_pen_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Pen;
			lbl_edge_thickness.Text = "Pen Size";
		}

		private void btn_line_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Line;
			lbl_edge_thickness.Text = "Line Thickness";
		}

		private void btn_erazer_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Erazer;
			lbl_edge_thickness.Text = "Erazer Size";
		}

		private void btn_form_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Object;
			lbl_edge_thickness.Text = "Edge Thickness";
		}

		private void btn_marker_Click(object sender, EventArgs e)
		{
			PicCanvasSettings.m_nSelectedTool = EDrawType.Marker;
		}

		private void btn_color1_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.ShowDialog(this);
			PicCanvasSettings.color1 = dialog.Color;
			btn_color1.ForeColor = dialog.Color;
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				PicCanvasSettings.SelectedObject.m_Pen.Color = dialog.Color;
				picture_canvas.Invalidate();
				PicCanvasSettings.ShouldRedraw = true;
			}
		}

		private void btn_color2_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.ShowDialog(this);
			PicCanvasSettings.color2 = dialog.Color;
			btn_color2.ForeColor = dialog.Color;
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				PicCanvasSettings.SelectedObject.m_PenOutline.Color = dialog.Color;
				picture_canvas.Invalidate();
				PicCanvasSettings.ShouldRedraw = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CreateNewLayer(Color.Transparent);
			combo_layers.SelectedIndex = combo_layers.Items.Count - 1;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (combo_layers.Items.Count <= 1)
			{
				return;
			}

			if (PicCanvasSettings.Layers.IndexOf((CanvasLayer) combo_layers.SelectedItem) ==
			    PicCanvasSettings.Layers.Count - 1)
			{
				PicCanvasSettings.CurrentLayerId = 1;
			}

			PicCanvasSettings.Layers.Remove(((CanvasLayer) combo_layers.SelectedItem));
			((CanvasLayer) combo_layers.SelectedItem).bitmap.Dispose();
			combo_layers.Items.RemoveAt(combo_layers.SelectedIndex);
			combo_layers.SelectedIndex = 0;
			picture_canvas.Invalidate();
			PicCanvasSettings.ShouldRedraw = true;
			Redraw();
		}

		private void combo_layers_SelectedIndexChanged(object sender, EventArgs e)
		{
			PicCanvasSettings.CurrentLayerId =
				PicCanvasSettings.Layers.IndexOf((CanvasLayer) combo_layers.SelectedItem);
		}

		private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "PNG Image (*.png)|*.png";
			dialog.DefaultExt = "png";
			dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + ".png";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				picture_canvas.Image.Save(dialog.FileName);
			}
		}

		private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void track_pen_thickness_Scroll(object sender, EventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				PicCanvasSettings.SelectedObject.m_PenOutline.Width = track_pen_thickness.Value;
				picture_canvas.Invalidate();
				PicCanvasSettings.ShouldRedraw = true;
			}
		}

		private void cb_drawedge_CheckedChanged(object sender, EventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				PicCanvasSettings.SelectedObject.m_bDrawEdge = cb_drawedge.Checked;
				picture_canvas.Invalidate();
				PicCanvasSettings.ShouldRedraw = true;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
				{
					GetCurrentLayer().objects.Remove(PicCanvasSettings.SelectedObject);
					PicCanvasSettings.ClearFramebuffer();
					PicCanvasSettings.SelectedObject = null;
					PicCanvasSettings.ShouldRedraw = true;
					picture_canvas.Invalidate();
				}
			}
		}

		private void txt_object_x_KeyUp(object sender, KeyEventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				int value;
				if (Int32.TryParse(txt_object_x.Text, out value))
				{
					PicCanvasSettings.SelectedObject.SetPosX(value);
					PicCanvasSettings.ClearFramebuffer();

					picture_canvas.Invalidate();
					PicCanvasSettings.ShouldRedraw = true;
				}
			}
		}

		private void txt_object_y_KeyUp(object sender, KeyEventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				int value;
				if (Int32.TryParse(txt_object_y.Text, out value))
				{
					PicCanvasSettings.SelectedObject.SetPosY(value);
					PicCanvasSettings.ClearFramebuffer();

					picture_canvas.Invalidate();
					PicCanvasSettings.ShouldRedraw = true;
				}
			}
		}


		private void txt_object_rot_KeyUp(object sender, KeyEventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				int value;
				if (Int32.TryParse(txt_object_rot.Text, out value))
				{
					PicCanvasSettings.SelectedObject.SetRotation(value);
					PicCanvasSettings.ClearFramebuffer();

					picture_canvas.Invalidate();
					PicCanvasSettings.ShouldRedraw = true;
				}
			}
		}

		private void txt_object_h_KeyUp(object sender, KeyEventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				int value;
				if (Int32.TryParse(txt_object_h.Text, out value))
				{
					PicCanvasSettings.SelectedObject.SetHeight(value);
					PicCanvasSettings.ClearFramebuffer();

					picture_canvas.Invalidate();
					PicCanvasSettings.ShouldRedraw = true;
				}
			}
		}

		private void txt_object_w_KeyUp(object sender, KeyEventArgs e)
		{
			if (PicCanvasSettings.SelectedObject != null && PicCanvasSettings.m_nSelectedTool == EDrawType.Pointer)
			{
				int value;
				if (Int32.TryParse(txt_object_w.Text, out value))
				{
					PicCanvasSettings.SelectedObject.SetWidth(value);
					PicCanvasSettings.ClearFramebuffer();
					picture_canvas.Invalidate();
					PicCanvasSettings.ShouldRedraw = true;
				}
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image file (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";


			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(dialog.FileName))
				{
					Bitmap bmp = new Bitmap(dialog.FileName);
					InitCanvas(bmp.Width, bmp.Height);
					Graphics gh = Graphics.FromImage(PicCanvasSettings.Layers[1].bitmap);
					gh.DrawImage(bmp, Point.Empty);
				}
			}
		}

		private void chk_debug_CheckedChanged(object sender, EventArgs e)
		{
			PicCanvasSettings.Debug = chk_debug.Checked;
		}
	}
}