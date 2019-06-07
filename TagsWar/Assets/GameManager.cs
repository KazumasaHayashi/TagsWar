using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
	public class GameManager : Photon.PunBehaviour
	{

		#region Public Properties
		static public GameManager Instance;
		#endregion

		#region Private Properties

		#endregion

		#region Public Variables
		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;
		

		#endregion

		#region Private Variables
		
		#endregion

		#region Photon Messages
		public override void OnLeftRoom()
		{
			SceneManager.LoadScene(0);
		}

		public override  void OnPhotonPlayerConnected(PhotonPlayer other)
		{
			Debug.Log("OnPhotonPlayerConnected() " + other.NickName);

		}

		public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
		{
			Debug.Log("OnPhotonPlayerDisconnected " + other.NickName);

			if(PhotonNetwork.isMasterClient)
			{
				Debug.Log("OnPhotonPlayerDisconnected isMasterClient " + PhotonNetwork.isMasterClient);
				LoadArena();
			}
		}
		#endregion

		#region Public Methods
		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}
		#endregion

		#region Private Methods	

		void LoadArena()
		{
			if(!PhotonNetwork.isMasterClient)
			{
				Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
			}
			Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
			PhotonNetwork.LoadLevel("Main");
		}

		void Awake ()
		{
			Debug.Log(PhotonNetwork.inRoom);
		}

		void Start () 
		{
			Instance = this;
			if(playerPrefab == null)
			{
				Debug.Log("We need set playerPrefab");
			}
			else
			{
				Debug.Log("We are instantiatingg LocalPlayer from "+ Application.loadedLevelName);
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
			}

			if(CharacterController.LocalPlayerInstance == null)
			{
				Debug.Log("We are Instantiating LocalPlayer from "+ Application.loadedLevelName);
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
			}
			else
			{
				Debug.Log("Ignoreing scene load for " + Application.loadedLevelName);
			}
		}
		
		
		void Update () 
		{
			
		}

		#endregion
	}
}

