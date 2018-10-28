using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField]float rotateSpeed;

	public Joystick cameraJoystick;


    float yaw,pitch;

    private void Start()
    {
        rotateSpeed = 1;
    }

    void Update () {

        //プライヤー位置を追従する
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z); 

        yaw +=  cameraJoystick.Horizontal * rotateSpeed; //横回転入力
        pitch -= cameraJoystick.Vertical * rotateSpeed; //縦回転入力

        pitch = Mathf.Clamp(pitch, -80, 60); //縦回転角度制限する

        transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f); //回転の実行
    }
}