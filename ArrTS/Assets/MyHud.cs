using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyHud : MonoBehaviour {
    private NetworkManager networkManager;
	// Use this for initialization
	void Start () {
        networkManager = GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void MyStartHost()
    {
        networkManager.StartHost();

        Debug.Log("Starting Houst @ : " + Time.realtimeSinceStartup);
    }

    void OnStartHost()
    {
        Debug.Log("Host Started @ : " + Time.realtimeSinceStartup);
    }
}
