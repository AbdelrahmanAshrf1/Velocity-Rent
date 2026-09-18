using System;
using System.Drawing;

namespace Velocity_Rent.Controls.Directory
{
    public enum DirectoryColumnType
    {
        Text,
        Image
    }

    public sealed class DirectoryColumn<T>
    {
        public string Key { get; private set; }
        public string HeaderText { get; private set; }
        public int Width { get; private set; }
        public DirectoryColumnType Type { get; private set; }
        public Func<T, object> Value { get; private set; }
        public Image PlaceholderImage { get; private set; }
        public int ImageSize { get; private set; }

        private DirectoryColumn() { }

        public static DirectoryColumn<T> Text(string key, string headerText, int width, Func<T, object> value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Column key is required.", "key");
            if (value == null) throw new ArgumentNullException("value");

            return new DirectoryColumn<T>
            {
                Key = key,
                HeaderText = headerText ?? string.Empty,
                Width = width,
                Type = DirectoryColumnType.Text,
                Value = value
            };
        }

        public static DirectoryColumn<T> Image(
            string key,
            string headerText,
            int width,
            Func<T, object> value,
            int imageSize = 46,
            Image placeholderImage = null)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Column key is required.", "key");
            if (value == null) throw new ArgumentNullException("value");

            return new DirectoryColumn<T>
            {
                Key = key,
                HeaderText = headerText ?? string.Empty,
                Width = width,
                Type = DirectoryColumnType.Image,
                Value = value,
                PlaceholderImage = placeholderImage,
                ImageSize = imageSize
            };
        }
    }
}
