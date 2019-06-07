using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
	public class Launcher : Photon.PunBehaviour
	{

	#region Public Properties

	public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

	#endregion

	#region Public Variables

	[Tooltip("The maximum number of players per room")]
	public byte MaxPlayersPerRoom = 5;

	[Tooltip("The UI Panel to let the user enter name, decide the number of players, connect and play")]
	public GameObject controlPanel;

	[Tooltip("The UI Lavel to inform the user that the connection is progress")]
	public GameObject progressLabel;

	#endregion

	#region Private Variables

	string _gameVersion = "1";

	bool isConnecting;
	
	#endregion

	#region Photon Messages

	#endregion

	#region Public Methods
	
	public void Connect()
	{
		isConnecting = true;

		progressLabel.SetActive(true);
		controlPanel.SetActive(false);

		if(PhotonNetwork.connected)
		{
			PhotonNetwork.JoinRandomRoom();
			Debug.Log("JoinRandomRoom() was called");
			Debug.Log("The number of players in room: " + PhotonNetwork.countOfPlayersInRooms);
		}
		else
		{
			PhotonNetwork.ConnectUsingSettings(_gameVersion);
		}

		

		Debug.Log(PhotonNetwork.countOfPlayersInRooms);
		Invoke("MoveScene", 5);
		

	}

	public void CreateRoom()
	{
		PhotonNetwork.CreateRoom(null, new RoomOptions() {MaxPlayers = MaxPlayersPerRoom}, null);
	}

	public void SendMaxplayer(Dropdown dropdown)
	{
		switch(dropdown.value)
		{
			case 0:
				MaxPlayersPerRoom = 2;
				break;
			case 1:
				MaxPlayersPerRoom = 3;
				break;
			case 2:
				MaxPlayersPerRoom = 4;
				break;
			case 3:
				MaxPlayersPerRoom = 5;
				break;
			// case 4:
			// 	MaxPlayersPerRoom = 6;
			// 	break;
			

		}
		
		

	}

	public void MoveScene()
	{
		Debug.Log("MoveScene() was called");
		if(PhotonNetwork.countOfPlayersInRooms == MaxPlayersPerRoom)
		
		{
			Debug.Log(MaxPlayersPerRoom + "画面遷移！" + PhotonNetwork.inRoom);
			
			PhotonNetwork.LoadLevel(1);

		}
		else
		{
			Debug.Log("Cannot use MoveScene()");
		}
	}

	public override void OnConnectedToMaster() 
	{
		Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
		Debug.Log(isConnecting);
		// if(isConnecting)
		// {
		// 	PhotonNetwork.JoinRandomRoom();
		// }
		PhotonNetwork.JoinRandomRoom();
		// Debug.Log("JoinRandomRoom cannot be called");
	}

	public override void OnDisconnectedFromPhoton()
	{
		progressLabel.SetActive(false);
		controlPanel.SetActive(true);
		UnityEngine.Debug.LogWarning(("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN"));

	}

	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
	{
		Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. NO random room available so we create one.");
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
		PhotonNetwork.LoadLevel("Main");
	}


	

	#endregion

	

	#region Private Methods	

	void Awake ()
	{
		PhotonNetwork.autoJoinLobby = false;

		PhotonNetwork.automaticallySyncScene = true;

		PhotonNetwork.logLevel = Loglevel;
	}

	void Start () 
	{
		progressLabel.SetActive(false);
		controlPanel.SetActive(true);
	}
	
	
	void Update () 
	{
		Debug.Log("Maxプレイヤー数" + MaxPlayersPerRoom);
		Debug.Log("プレイヤー数" + PhotonNetwork.countOfPlayersInRooms);
		// Invoke("MoveScene",5);
	}

	#endregion

	}
}
