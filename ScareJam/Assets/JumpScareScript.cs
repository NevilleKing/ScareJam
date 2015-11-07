using UnityEngine;
using System.Collections;

public class JumpScareScript : MonoBehaviour {

    public GameObject jumpScareGhoul;
    private AudioSource audioS;

    private bool trig = false;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider c)
    {
        trig = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(trig)
        {
            audioS.Play();
            trig = false;
            Instantiate(jumpScareGhoul, new Vector3(-12.886f, 0.09155834f, 19.416f), Quaternion.Euler(new Vector3(0.0f, 145.6614f, 0.0f)));
            Destroy(jumpScareGhoul, 1000);
            Destroy(gameObject, 10);
        }
	}
}
