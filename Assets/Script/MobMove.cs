using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour
{
    public bool movePos;
    public bool hitis;

    public float speed;
    public float backspeed;
    public GameObject mobobj;
    Animator animator;

    //public static MobMove mobmv;

    //private Rigidbody2D rBody2D;

    // Start is called before the first frame update
    void Start()
    {
        backspeed = 3f;
        hitis = false;
        //rBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("hit",false);
        animator.SetBool("dead",false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (mobmv == null) {
            mobmv = this;
        }else if(mobmv != this) {
            Destroy(gameObject);
        }*/

        if(movePos == true && hitis == false){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }else if(movePos == false && hitis == true){
            transform.Translate(backspeed*Time.deltaTime, 0, 0);
        }else{
            transform.Translate(0, 0, 0);
        }
        //rBody2D.AddForce(speed, 0, 0);//rigidbody2d가 필요함

        if(Mob.enemy.HP <= 0){
            Destroy(mobobj);
            SlimeAni.slan.attack = false;
            StartCoroutine(deadCoolTime(0.01f));
            Mob.enemy.kill_mob();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "slime"){
            StartCoroutine(hitCoolTime(0.1f));
            Mob.enemy.HP -= Mob.enemy.slimeStr;
        }

        if(collision.gameObject.tag == "pet"){
            StartCoroutine(petHit(1f));
            Mob.enemy.HP -= Mob.enemy.petStr;
        }
    }

    IEnumerator hitCoolTime (float cool){
        MusicSetting.muse.SFXAS.clip = MusicSetting.muse.attack_sfx;
        MusicSetting.muse.SFXAS.Play();
        SlimeAni.slan.attack = true;
        movePos = false;
        hitis = true;
        animator.SetBool("hit",true);
        animator.SetBool("dead",false);
        while(cool > 0.00f){
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        SlimeAni.slan.attack = false;
        movePos = true;
        hitis = false;
        animator.SetBool("hit",false);
        animator.SetBool("dead",false);
        SlimeAni.slan.attack = false;
    }

    IEnumerator petHit (float cool){
        MusicSetting.muse.SFXAS.clip = MusicSetting.muse.attack_sfx;
        movePos = false;
        hitis = true;
        Pet.pet.hit();
        animator.SetBool("hit",true);
        animator.SetBool("dead",false);
        transform.Translate(backspeed * Time.deltaTime, 0, 0);
        while(cool > 0.00f){
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        movePos = true;
        hitis = false;
        animator.SetBool("hit",false);
        animator.SetBool("dead",false);
    }
    
    IEnumerator deadCoolTime (float cool){
        movePos = false;
        animator.SetBool("hit",false);
        animator.SetBool("dead",true);
        transform.Translate(backspeed * Time.deltaTime, 0, 0);
        while(cool > 0.00f){
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
