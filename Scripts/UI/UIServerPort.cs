using Godot;
using System;

public partial class UIServerPort : HFlowContainer
{
    [Export] private LineEdit le;
    [Export] public int currentPort = 27020;

    public override void _Ready()
    {
        le.Text = currentPort.ToString();
        le.TextChanged += WhenTextChange;
        le.TextSubmitted += WhenTextSubmitted;
    }

    private void WhenTextSubmitted(string newText)
    {
        if (int.TryParse(newText, out int v)) { currentPort = v; }
        le.Text = currentPort.ToString();
    }

    private void WhenTextChange(string newText)
    {
        if (newText.Length > 0 && !int.TryParse(newText, out int v))
        {
            le.Text = currentPort.ToString();
        }
    }
}// EOF CLASS
