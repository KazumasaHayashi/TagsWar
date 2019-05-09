using UnityEngine;
using UnityEngine.UI;

public class CameraController : Photon.MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField]float rotateSpeed;

	public Joystick cameraJoystick;


    public static float yaw,pitch;

    private void Start()
    {
        rotateSpeed = 2;

        GameObject Camerajoystick = GameObject.Find("Camera Joystick");
        cameraJoystick = Camerajoystick.GetComponent<FloatingJoystick>();
    }

    void Update () {

        // if(photonView.isMine == false && PhotonNetwork.connected == true)
        // {
        //     return;    
        // }

        if(photonView.isMine == true)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z); 

            yaw +=  cameraJoystick.Horizontal * rotateSpeed; //横回転入力
            pitch -= cameraJoystick.Vertical * rotateSpeed; //縦回転入力

            pitch = Mathf.Clamp(pitch, -80, 60); //縦回転角度制限する

            transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f); //回転の実行

            if(cameraJoystick.Horizontal == 0 & cameraJoystick.Vertical == 0){
                
            }
        }

        //プライヤー位置を追従する
        // transform.position = new Vector3(player.position.x, transform.position.y, player.position.z); 

        // yaw +=  cameraJoystick.Horizontal * rotateSpeed; //横回転入力
        // pitch -= cameraJoystick.Vertical * rotateSpeed; //縦回転入力

        // pitch = Mathf.Clamp(pitch, -80, 60); //縦回転角度制限する

        // transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f); //回転の実行

        // if(cameraJoystick.Horizontal == 0 & cameraJoystick.Vertical == 0){
            
        // }
    }
}