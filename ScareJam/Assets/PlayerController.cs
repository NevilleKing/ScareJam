/*
PlayerController.cs
Controls player movement & handles keyboard input
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float velocity = 2.0f;

    private GameObject player;
    private Rigidbody myRigidBody;

	void Start () {
        player = gameObject; // get the player object
        myRigidBody = player.GetComponent<Rigidbody>(); // get the rigidbody of the player
	}
	
	void Update () {
        float h = Input.GetAxis("Horizontal"); // get Horizontal movement
        float v = Input.GetAxis("Vertical"); // get Vertical movement

        SetMovement(h, v);
    }

    void SetMovement(float horizontal, float vertical)
    {
        // if there is some input
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical); // set the direction the player will move in
            Debug.Log(direction);
            transform.Translate(direction * velocity * Time.deltaTime);
        }
    }
}
