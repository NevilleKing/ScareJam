/*
PlayerController.cs
Controls player movement & handles keyboard input
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 2.0f;
    public float camSpeed = 2.0f;

    private GameObject player;
    private Rigidbody myRigidBody;
    private Camera cam;

    private Vector3 direction;
    private Vector3 velocity;

    private Vector3 rotation;

	void Start () {
        player = gameObject; // get the player object
        myRigidBody = player.GetComponent<Rigidbody>(); // get the rigidbody of the player
        cam = player.GetComponentInChildren<Camera>();
	}
	
	void Update () {
        // Player Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // get Horizontal movement
        float moveVertical = Input.GetAxisRaw("Vertical"); // get Vertical movement

        SetMovement(moveHorizontal, moveVertical);

        // Camera Movement

        float camHorizontal = -Input.GetAxisRaw("Mouse Y"); // get Horizontal movement
        float camVertical = Input.GetAxisRaw("Mouse X"); // get Vertical movement

        SetCameraMovement(camHorizontal, camVertical);
    }

    void SetMovement(float horizontal, float vertical)
    {
        // if there is some input
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            direction = new Vector3(horizontal, 0.0f, vertical); // set the direction the player will move in
            velocity = direction.normalized * speed; // multiply by the speed
            myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime); // apply the movement to the player
        }
    }

    void SetCameraMovement(float horizontal, float vertical)
    {
        // if there is some input
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            horizontal *= camSpeed;
            vertical *= camSpeed;
            cam.transform.Rotate(horizontal, vertical, 0.0f);

            cam.transform.Rotate(0.0f, 0.0f, -cam.transform.eulerAngles.z);
        }
    }
}
