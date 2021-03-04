using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ProjectGenerator.data;

namespace ProjectGenerator.features
{
    public static class ComboBoxTools
    {
        // Margins around owner drawn ComboBoxes.
        private const int MarginWidth = 4;
        private const int MarginHeight = 4;

        #region Display Images

        // Set up the ComboBox to display images.
        public static void DisplayImages(this ComboBox cbo, Image[] images)
        {
            // Make the ComboBox owner-drawn.
            cbo.DrawMode = DrawMode.OwnerDrawVariable;

            // Add the images to the ComboBox's items.
            cbo.Items.Clear();
            foreach (Image image in images) cbo.Items.Add(image);

            // Subscribe to the DrawItem event.
            cbo.MeasureItem += cboDrawImage_MeasureItem;
            cbo.DrawItem += cboDrawImage_DrawItem;
        }

        // Measure a ComboBox item that is displaying an image.
        private static void cboDrawImage_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get this item's image.
            ComboBox cbo = sender as ComboBox;
            Image img = (Image)cbo.Items[e.Index];
            e.ItemHeight = img.Height + 2 * MarginHeight;
            e.ItemWidth = img.Width + 2 * MarginWidth;
        }

        // Draw a ComboBox item that is displaying an image.
        private static void cboDrawImage_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Clear the background appropriately.
            e.DrawBackground();

            // Draw the image.
            ComboBox cbo = sender as ComboBox;
            Image img = (Image)cbo.Items[e.Index];

            float hgt = e.Bounds.Height - 2 * MarginHeight;
            float scale = hgt / img.Height;
            float wid = img.Width * scale;
            
            RectangleF rect = new RectangleF(
                e.Bounds.X + MarginWidth,
                e.Bounds.Y + MarginHeight,
                wid, hgt);

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.DrawImage(img, rect);

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        #endregion Display Images

        #region Images and Text

        // Set up the ComboBox to display images with text.
        public static void DisplayImagesAndText(this ComboBox cbo, Projects[] values)
        {
            // Make the ComboBox owner-drawn.
            //cbo.DrawMode = DrawMode.OwnerDrawFixed;
            cbo.DrawMode = DrawMode.OwnerDrawFixed;

            // Add the images to the ComboBox's items.
            cbo.Items.Clear();
            cbo.Items.AddRange(values);
            cbo.DisplayMember = "Name";
            cbo.ValueMember = "Script";
            cbo.DataSource = values;

            // Subscribe to the DrawItem event.
            cbo.MeasureItem += cboDrawImageAndText_MeasureItem;
            cbo.DrawItem += cboDrawImageAndText_DrawItem;
        }

        // Measure a ComboBox item that is displaying an image.
        private static void cboDrawImageAndText_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item.
            ComboBox cbo = sender as ComboBox;
            Projects item = (Projects)cbo.Items[e.Index];

            // Make the item measure itself.
            item.MeasureItem(e);
        }

        // Draw a ComboBox item that is displaying an image.
        private static void cboDrawImageAndText_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item.
            ComboBox cbo = sender as ComboBox;
            Projects item = (Projects)cbo.Items[e.Index];

            // Make the item draw itself.
            item.DrawItem(e);
        }

        #endregion Images and Text
    }
}
