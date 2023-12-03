using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAni : MonoBehaviour
{
    public GameObject mobobj;
    Animator ani;

    public static SlimeAni slan;

    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (slan == null) {
            slan = this;
        }else if(slan != this) {
            Destroy(gameObject);
        }

        ani.SetBool("attack", attack);
    }
}
