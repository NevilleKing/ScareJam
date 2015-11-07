using UnityEngine;
using System.Collections;

public class AudioTimer : MonoBehaviour {

    public float timer_upper = 20.0f;
    public float timer_lower = 10.0f;

    private float timerVal;

    private AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        timerVal = Random.Range(timer_lower, timer_upper);
	}
	
	// Update is called once per frame
	void Update () {
	    if (timerVal < 0)
        {
            aSource.Play();
            timerVal = Random.Range(timer_lower, timer_upper);
        }
        else
        {
            timerVal -= Time.deltaTime;
        }
	}
}
