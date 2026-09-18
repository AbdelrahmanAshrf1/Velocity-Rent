using System;

namespace Velocity_Rent.Controls.Directory
{
    public sealed class DirectoryRowActionEventArgs : EventArgs
    {
        public object Item { get; private set; }
        public string ActionKey { get; private set; }

        public DirectoryRowActionEventArgs(object item, string actionKey)
        {
            Item = item;
            ActionKey = actionKey;
        }

        public T GetItem<T>()
        {
            return (T)Item;
        }
    }
}
