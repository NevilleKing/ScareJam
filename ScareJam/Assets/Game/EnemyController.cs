using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 0.05f;

    private GameObject player;
    private Animator anim;

    private float timer = 3.0f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("isRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
        }
	}
}
