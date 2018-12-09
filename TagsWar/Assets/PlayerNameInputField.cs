using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
	[RequireComponent(typeof(InputField))]
	public class PlayerNameInputField : MonoBehaviour 
	{

		#region Public Properties

		#endregion

		#region Private Properties

		static string playerNamePrefKey = "PlayerName";

		#endregion

		#region Public Variables

		#endregion

		#region Private Variables
		
		#endregion

		#region Photon Messages

		#endregion

		#region Public Methods

		public void SetPlayerName(string value)
		{
			PhotonNetwork.playerName = value + " ";

			PlayerPrefs.SetString(playerNamePrefKey, value);
		}

		#endregion

		#region Private Methods	

		void Awake ()
		{
			
		}

		void Start () 
		{
			string defaultName = "";
			InputField _inputField = this.GetComponent<InputField>();
			if (_inputField != null)
			{
				if(PlayerPrefs.HasKey(playerNamePrefKey))
				{
					defaultName = PlayerPrefs.GetString(playerNamePrefKey);
					_inputField.text = defaultName;
				}
			}

			PhotonNetwork.playerName = defaultName;
		}
		

		
		void Update () 
		{
			
		}

		#endregion
	}
}

