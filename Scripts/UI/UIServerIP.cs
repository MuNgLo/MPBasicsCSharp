using Godot;
using System;
using System.Net;
[GlobalClass]
public partial class UIServerIP : FlowContainer
{
    [Export] private SpinBox value1;
    [Export] private SpinBox value2;
    [Export] private SpinBox value3;
    [Export] private SpinBox value4;

    [Export] private string IPasString { get => $"{value1.Value}.{value2.Value}.{value3.Value}.{value4.Value}"; set{ }}

    public IPAddress GetIPAddress(){
        return IPAddress.Parse(IPasString);
    }

    internal void SetFromIpPort(string ipPort)
    {
        GD.Print($"UIServerIP::SetFromIpPort({ipPort})");

        string ip;
        string[] parts = new string[0];
        if(ipPort.Contains(':')){ parts = ipPort.Split(':', 2); ip = parts[0]; }else{ip = ipPort; }
        if(IPAddress.TryParse(ip, out IPAddress address)){
            string[] ipValues = ip.Split('.', 4);
            if(ipValues.Length > 3){
                if(int.TryParse(ipValues[0], out int value)){ value1.SetValueNoSignal(value); }
                if(int.TryParse(ipValues[1], out value)){ value2.SetValueNoSignal(value); }
                if(int.TryParse(ipValues[2], out value)){ value3.SetValueNoSignal(value); }
                if(int.TryParse(ipValues[3], out value)){ value4.SetValueNoSignal(value); }
            }
        }
    }
}// EOF CLASS
