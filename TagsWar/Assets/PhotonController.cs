using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings(null);
	}
	
	void OnConnectedToServer()
	{
		
		Debug.Log("Enter");
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
