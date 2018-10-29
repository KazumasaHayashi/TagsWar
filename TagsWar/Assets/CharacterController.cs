using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    static public float moveSpeed = 1.5f;
    public Joystick joystick;



	void Update () 
	{
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            // transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.Self);
        }   
		
		if(CameraController.yaw != 0){
			transform.eulerAngles = new Vector3(0.0f, CameraController.yaw, 0.0f);
		}
	}
}