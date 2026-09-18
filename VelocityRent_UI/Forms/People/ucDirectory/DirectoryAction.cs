using System;

namespace Velocity_Rent.Controls.Directory
{
    public sealed class DirectoryAction<T>
    {
        public string Key { get; private set; }
        public string Text { get; private set; }
        public int Width { get; private set; }
        public Func<T, bool> IsEnabled { get; private set; }

        private DirectoryAction() { }

        public static DirectoryAction<T> Button(
            string key,
            string text,
            int width = 64,
            Func<T, bool> isEnabled = null)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Action key is required.", "key");

            return new DirectoryAction<T>
            {
                Key = key,
                Text = text ?? key,
                Width = width,
                IsEnabled = isEnabled
            };
        }
    }
}
