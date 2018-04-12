using System;

public static class CSharpUtiltiy
{
    public static void EventEmit(this EventHandler handler, object sender, EventArgs args = null)
    {
        if (args == null) args = EventArgs.Empty;

        if (handler != null)
            handler(sender, args);
    }
}

public delegate void TEventHandler<TEventArgs>(object sender, TEventArgs e);