using UnityEngine;
using UnityEngine.UI;

public class CharacterController : Photon.MonoBehaviour 
{

    [SerializeField]
    static public float moveSpeed = 2.0f;
    public Joystick joystick;

    [Tooltip("The local player instance.")]
	public static GameObject LocalPlayerInstance;

    void Awake()
    {
        if(photonView.isMine)
			{
				CharacterController.LocalPlayerInstance = this.gameObject;
			}
		DontDestroyOnLoad(this.gameObject);

        GameObject joyStick = GameObject.Find("Floating Joystick");
        joystick = joyStick.GetComponent<FloatingJoystick>();

    }

	void Update () 
	{
        if(photonView.isMine == false && PhotonNetwork.connected == true)
        {
            return;    
        }
        
        if(photonView.isMine == true)
        {
            Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {
                // transform.rotation = Quaternion.LookRotation(moveVector);
                transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.Self);
            }   
            
            if(CameraController.yaw != 0)
            {
                transform.eulerAngles = new Vector3(0.0f, CameraController.yaw, 0.0f);
        
            }
        }
        else
        {
            Debug.Log("You cannot move this character");
        }
        // Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        // if (moveVector != Vector3.zero)
        // {
        //     // transform.rotation = Quaternion.LookRotation(moveVector);
        //     transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.Self);
        // }   
		
		// if(CameraController.yaw != 0)
        // {
		// 	transform.eulerAngles = new Vector3(0.0f, CameraController.yaw, 0.0f);
	
        // }
	}
}