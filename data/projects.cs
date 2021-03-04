using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ProjectGenerator.data
{
    public class Projects : INotifyPropertyChanged
    {
        private string _name = "";
        private string _desc = "";
        private string _script = "";
        private string _doc_url = "";

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Desc
        {
            get { return _desc; }
            set
            {
                if (value != _desc)
                {
                    _desc = value;
                    OnPropertyChanged("Desc");
                }
            }
        }

        public string Script
        {
            get { return _script; }
            set
            {
                if (value != _script)
                {
                    _script = value;
                    OnPropertyChanged("Script");
                }
            }
        }

        public string Doc_Url
        {
            get { return _doc_url; }
            set
            {
                if(value != _doc_url)
                {
                    _doc_url = value;
                    OnPropertyChanged("Doc_Url");
                }
            }
        }

        private Image Picture = Properties.Resources.winformsapp;
        private Font Font = new Font("Times New Roman", 14);

        public Projects(string name = "", string desc = "", string script = "", string doc_url = "")
        {
            Name = name;
            Desc = desc;
            Script = script;
            Doc_Url = doc_url;

            if(Name.Contains("Blazor"))
            {
                Picture = Properties.Resources.blazor;
            }
            else if (Name.Contains("ASP NET Core"))
            {
                if(Name.Contains("Angular"))
                {
                    Picture = Properties.Resources.aspnetcoreangular;
                }
                else
                {
                    Picture = Properties.Resources.aspnetcore;
                }
            }
            else if (Name.Contains("Console"))
            {
                Picture = Properties.Resources.consoleapp;
            }
            else if (Name.Contains("Angular"))
            {
                Picture = Properties.Resources.angular;
            }
            else if (Name.Contains("React"))
            {
                Picture = Properties.Resources.react;
            }
            else if (Name.Contains("Vue"))
            {
                Picture = Properties.Resources.vuejs;
            }
            else if (Name.Contains("NativeScript"))
            {
                Picture = Properties.Resources.nativescript;
            }
            else if (Name.Contains("Flutter"))
            {
                Picture = Properties.Resources.flutter;
            }
            else
            {
                Picture = Properties.Resources.winformsapp;
            }
        }

        private const int MarginWidth = 4;
        private const int MarginHeight = 4;
        private int Width, Height;
        private bool SizeCalculated = false;
        public void MeasureItem(MeasureItemEventArgs e)
        {
            // See if we've already calculated this.
            if (!SizeCalculated)
            {
                SizeCalculated = true;

                // See how much room the text needs.
                SizeF text_size = e.Graphics.MeasureString(Desc, Font);

                // The height is the maximum of the image height and text height.
                Height = 2 * MarginHeight +
                    (int)Math.Max(Picture.Height, text_size.Height);

                // The width is the sum of the image and text widths.
                Width = (int)(4 * MarginWidth + Picture.Width + text_size.Width);
            }

            e.ItemWidth = Width;
            e.ItemHeight = Height;
        }

        // Draw the item.
        public void DrawItem(DrawItemEventArgs e)
        {
            // Clear the background appropriately.
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
            }

            // Draw the image.
            float hgt = e.Bounds.Height - 2 * MarginHeight;
            float scale = hgt / Picture.Height;
            float wid = Picture.Width * scale;
            RectangleF rect = new RectangleF(
                e.Bounds.X + MarginWidth,
                e.Bounds.Y + MarginHeight,
                wid, hgt);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.DrawImage(Picture, rect);

            // Draw the text.
            // If we're drawing on the control,
            // draw only the first line of text.
            string visible_text = Desc;
            if (e.Bounds.Height < Picture.Height && Desc.IndexOf('\n') != -1)
                visible_text = Desc.Substring(0, Desc.IndexOf('\n'));

            // Make a rectangle to hold the text.
            wid = e.Bounds.Width - rect.Right - 3 * MarginWidth;
            rect = new RectangleF(
                rect.Right + 2 * MarginWidth, rect.Y,
                wid, hgt);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(visible_text, Font, Brushes.Black, rect, sf);
            }

            e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rect));

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
