using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 0.05f;

    private GameObject player;
    private Animator anim;

    private float timer = 3.0f;

    private bool enemyMoving = true;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyMoving)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, 0.0f, player.transform.position.z), enemySpeed);
            }
        }
	}

    // Check if the enemy is colliding
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Player" && enemyMoving)
        {
            enemyMoving = false;
            anim.SetBool("isRunning", false);
            Destroy(player.GetComponent<OVRPlayerController>());
            player.AddComponent<PlayerDead>();
        }
    }
}
