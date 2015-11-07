using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

    private GameObject enemy;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //transform.parent.LookAt(enemy.transform);
        anim.enabled = true;
        anim.SetTrigger("Die");
    }
}
