using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour
{
    public bool movePos;

    public float speed;
    public GameObject mobobj;

    //private Rigidbody2D rBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movePos == true){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }else{
            transform.Translate(0, 0, 0);
        }
        //rBody2D.AddForce(speed, 0, 0);//rigidbody2d가 필요함

        if(Mob.enemy.HP <= 0){
            Destroy(mobobj);
            Mob.enemy.kill_mob();
        }
    }
}
