using System;
using System.Drawing;
using System.Windows.Forms;

public class ComboBoxWithHint : ComboBox
{
    private string hint;

    public string Hint
    {
        get { return hint; }
        set
        {
            hint = value;
            Invalidate();
        }
    }

    public ComboBoxWithHint()
    {
        DrawMode = DrawMode.OwnerDrawFixed;
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        base.OnDrawItem(e);

        if (e.Index < 0 && !string.IsNullOrEmpty(Hint) && !Focused)
        {
            e.Graphics.DrawString(Hint, Font, Brushes.Gray, e.Bounds);
        }
        else
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
                e.Graphics.DrawString(Items[e.Index].ToString(), Font, Brushes.Black, e.Bounds);
            }
        }
    }

    protected override void OnDropDown(EventArgs e)
    {
        base.OnDropDown(e);
        Invalidate();
    }

    protected override void OnDropDownClosed(EventArgs e)
    {
        base.OnDropDownClosed(e);
        Invalidate();
    }

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        Invalidate();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        Invalidate();
    }
}