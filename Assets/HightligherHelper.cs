using UnityEngine;
using VRTK.Highlighters;

public class HightligherHelper : MonoBehaviour
{
    public Color touchHighlightColor = Color.yellow;
    protected VRTK_BaseHighlighter objectHighlighter;

    public virtual void InitialiseHighlighter()
    {
        if (touchHighlightColor != Color.clear && objectHighlighter == null)
        {
            objectHighlighter = VRTK_BaseHighlighter.GetActiveHighlighter(gameObject);
            if (objectHighlighter == null)
            {
                objectHighlighter = gameObject.AddComponent<VRTK_MaterialColorSwapHighlighter>();
            }
            objectHighlighter.Initialise(touchHighlightColor);
        }
    }

    public void Highlight()
    {
        objectHighlighter.Highlight(touchHighlightColor);
    }

    public void Unhighlight()
    {
        objectHighlighter.Unhighlight();
    }
}