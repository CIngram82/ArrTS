using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {
    public void MyStartHost()
    {
        StartHost();

        Debug.Log(Time.realtimeSinceStartup + " : Starting Host" );
        
    }

    public override void OnStartHost()
    {
        Debug.Log(Time.realtimeSinceStartup + " : Host Started");
    }
    public override void OnStartClient(NetworkClient myClient)
    {
        base.OnStartClient(myClient);
        Debug.Log(Time.realtimeSinceStartup + " : Start Client Request");
        InvokeRepeating("PrintDots", 0f,.5f);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log(Time.realtimeSinceStartup + " : Client Connected to :" + conn.address);
        CancelInvoke();
    }
    private void PrintDots()
    {
         Debug.Log(".");
    }

}
