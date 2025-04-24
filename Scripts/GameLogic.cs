using Godot;
using System;
using System.Threading.Tasks;

public partial class GameLogic : Node
{
    [Export] private bool debug = true;
    [Export] private GDLobby.LobbyManager lobby;
    [Export] private GDLobby.LobbyEvents lobbyEvents;
    [ExportCategory("UI references")]
    [Export] private Button btnProbeNet;
    [Export] private Button btnHostStart;
    [Export] private Button btnHostStop;
    [Export] private Button btnHostJoin;
    [Export] private Button btnHostleave;
    [Export] private UIServerIP serverIP;
    [Export] private UIServerPort serverport;


    public override void _Ready()
    {
        lobbyEvents.OnHostSetupReady += WhenHostSetupReady;
        lobbyEvents.OnHostClosed += WhenHostClosed;

        lobbyEvents.OnConnectedToServer += WhenConnectedToHost;
        lobbyEvents.OnLeavingHost += WhenLeavingHost;

        lobbyEvents.OnServerDisconnected += WhenServerDisconnected;

        btnProbeNet.Pressed += BtnProbeNetwork;
        btnHostStart.Pressed += BtnHostStart;
        btnHostStop.Pressed += BtnHostStop;
        btnHostJoin.Pressed += BtnHostJoin;
        btnHostleave.Pressed += BtnHostLeave;

        btnHostStop.Hide();
        btnHostleave.Hide();
    }

    private void WhenLeavingHost(object sender, EventArgs e)
    {
        btnHostStart.Show();
        btnHostStop.Hide();
        btnHostJoin.Show();
        btnHostleave.Hide();
    }

    private void WhenConnectedToHost(object sender, EventArgs e)
    {
        btnHostStart.Hide();
        btnHostStop.Hide();
        btnHostJoin.Hide();
        btnHostleave.Show();
    }

    private void WhenServerDisconnected(object sender, EventArgs e)
    {
        btnHostStart.Show();
        btnHostStop.Hide();
        btnHostJoin.Show();
        btnHostleave.Hide();
    }

    private void WhenHostClosed(object sender, EventArgs e)
    {
        btnHostStart.Show();
        btnHostStop.Hide();
        btnHostJoin.Show();
        btnHostleave.Hide();
    }

    private void WhenHostSetupReady(object sender, EventArgs e)
    {
        btnHostStart.Hide();
        btnHostStop.Show();
        btnHostJoin.Hide();
        btnHostleave.Hide();
    }

    private void BtnHostStop()
    {
        if (debug) { GD.Print($"GameLogic::BtnHostStop() PRESSED"); }
        lobby.StopHost();
    }

    private void BtnHostLeave()
    {
        if (debug) { GD.Print($"GameLogic::BtnHostLeave() PRESSED"); }
        lobby.LeaveHost();
    }

    public async void BtnProbeNetwork()
    {
        if (debug) { GD.Print($"GameLogic::BtnProbeNetwork() PRESSED"); }
        string ipPort = await lobby.ProbeNetworkForInfo(serverport.currentPort);
        serverIP.SetFromIpPort(ipPort);
    }
    public void BtnHostStart()
    {
        if (debug) { GD.Print($"GameLogic::BtnHostStart() PRESSED"); }
        lobby.StartHost(serverport.currentPort);
    }
    public void BtnHostJoin()
    {
        if (debug) { GD.Print($"GameLogic::BtnHostJoin() PRESSED"); }
        lobby.JoinHost(serverIP.GetIPAddress(), serverport.currentPort);
    }
}// EOF CLASS
