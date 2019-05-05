using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CastellaNetManager : NetworkManager
{
    public override void Start(){
        base.Start();
    }

    public override void OnServerConnect(NetworkConnection conn){
        base.OnServerConnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn){
        Debug.Log("Client disconected");
        conn.playerController.GetComponent<ConnectionManager>().TargetDestroyCanvas(conn.playerController.connectionToClient);
    }
}
