using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Reporting.Chart.WebForms.Borders3D
{
	internal class EmbossBorder : IBorderType
	{
		public float defaultRadiusSize = 15f;

		public float resolution = 96f;

		protected float[] cornerRadius = new float[8]
		{
			15f,
			15f,
			15f,
			15f,
			15f,
			15f,
			15f,
			15f
		};

		public virtual string Name => "Emboss";

		public virtual float Resolution
		{
			set
			{
				resolution = value;
				float num = defaultRadiusSize = 15f * value / 96f;
				cornerRadius = new float[8]
				{
					num,
					num,
					num,
					num,
					num,
					num,
					num,
					num
				};
			}
		}

		public virtual RectangleF GetTitlePositionInBorder()
		{
			return RectangleF.Empty;
		}

		public virtual void AdjustAreasPosition(ChartGraphics graph, ref RectangleF areasRect)
		{
			SizeF size = new SizeF(defaultRadiusSize / 2f, defaultRadiusSize / 2f);
			size = graph.GetRelativeSize(size);
			if (size.Width < 30f)
			{
				areasRect.X += size.Width;
				areasRect.Width -= Math.Min(areasRect.Width, size.Width * 2.5f);
			}
			if (size.Height < 30f)
			{
				areasRect.Y += size.Height;
				areasRect.Height -= Math.Min(areasRect.Height, size.Height * 2.5f);
			}
			if (areasRect.X + areasRect.Width > 100f)
			{
				areasRect.X -= 100f - areasRect.Width;
			}
			if (areasRect.Y + areasRect.Height > 100f)
			{
				areasRect.Y -= 100f - areasRect.Height;
			}
		}

		public virtual void DrawBorder(ChartGraphics graph, BorderSkinAttributes borderSkin, RectangleF rect, Color backColor, ChartHatchStyle backHatchStyle, string backImage, ChartImageWrapMode backImageMode, Color backImageTranspColor, ChartImageAlign backImageAlign, GradientType backGradientType, Color backGradientEndColor, Color borderColor, int borderWidth, ChartDashStyle borderStyle)
		{
			RectangleF rectangleF = graph.Round(rect);
			RectangleF rectangleF2 = rectangleF;
			float num = 0.2f + 0.4f * (float)(borderSkin.PageColor.R + borderSkin.PageColor.G + borderSkin.PageColor.B) / 765f;
			Color centerColor = Color.FromArgb((int)((float)(int)borderSkin.PageColor.R * num), (int)((float)(int)borderSkin.PageColor.G * num), (int)((float)(int)borderSkin.PageColor.B * num));
			if (borderSkin.PageColor == Color.Transparent)
			{
				centerColor = Color.FromArgb(60, 0, 0, 0);
			}
			num += 0.2f;
			Color centerColor2 = Color.FromArgb((int)((float)(int)borderSkin.PageColor.R * num), (int)((float)(int)borderSkin.PageColor.G * num), (int)((float)(int)borderSkin.PageColor.B * num));
			float val = defaultRadiusSize;
			val = Math.Max(val, 2f * resolution / 96f);
			val = Math.Min(val, rect.Width / 2f);
			val = Math.Min(val, rect.Height / 2f);
			val = (float)Math.Ceiling(val);
			graph.FillRectangle(new SolidBrush(borderSkin.PageColor), rect);
			rectangleF2 = rectangleF;
			rectangleF2.Width -= val * 0.3f;
			rectangleF2.Height -= val * 0.3f;
			graph.DrawRoundedRectShadowAbs(rectangleF2, cornerRadius, val + 1f * resolution / 96f, centerColor2, borderSkin.PageColor, 1.4f);
			rectangleF2 = rectangleF;
			rectangleF2.X = rectangleF.X + val / 3f;
			rectangleF2.Y = rectangleF.Y + val / 3f;
			rectangleF2.Width -= val / 3.5f;
			rectangleF2.Height -= val / 3.5f;
			graph.DrawRoundedRectShadowAbs(rectangleF2, cornerRadius, val, centerColor, borderSkin.PageColor, 1.3f);
			rectangleF2 = rectangleF;
			rectangleF2.X = rectangleF.X + 3f * resolution / 96f;
			rectangleF2.Y = rectangleF.Y + 3f * resolution / 96f;
			rectangleF2.Width -= val * 0.75f;
			rectangleF2.Height -= val * 0.75f;
			GraphicsPath graphicsPath = graph.CreateRoundedRectPath(rectangleF2, cornerRadius);
			graph.DrawPathAbs(graphicsPath, backColor, backHatchStyle, backImage, backImageMode, backImageTranspColor, backImageAlign, backGradientType, backGradientEndColor, borderColor, borderWidth, borderStyle, PenAlignment.Inset);
			graphicsPath?.Dispose();
			Region region = new Region(graph.CreateRoundedRectPath(new RectangleF(rectangleF2.X - val, rectangleF2.Y - val, rectangleF2.Width + val - val * 0.25f, rectangleF2.Height + val - val * 0.25f), cornerRadius));
			region.Complement(graph.CreateRoundedRectPath(rectangleF2, cornerRadius));
			graph.Clip = region;
			graph.DrawRoundedRectShadowAbs(rectangleF2, cornerRadius, val, Color.Transparent, Color.FromArgb(128, Color.Gray), 0.5f);
			graph.Clip = new Region();
		}
	}
}
