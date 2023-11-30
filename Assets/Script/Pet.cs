using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public static Pet pet;

    SpriteRenderer spRe;

    public Sprite petstop;
    public Sprite petmove;
    public Sprite pethit;

    public bool movePos;
    public bool ismove;
    public bool ishit;

    public float disx;//distance x x거리
    public float disy;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        spRe = GetComponent<SpriteRenderer>();
        movePos = true;
        ismove = false;
        ishit = false;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        disx = Mob.enemy.transform.position.x - transform.position.x;
        disy = Mob.enemy.transform.position.y - transform.position.y;

        if (pet == null) {
            pet = this;
        }else if(pet != this) {
            Destroy(gameObject);
        }

        if(movePos == true && disx > 0){
            transform.Translate(speed * Time.deltaTime, 0, 0);
            ismove = true;
        }else if(movePos == true && disx < 0){
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            ismove = true;
        }

        if(movePos == true && disy > 0){
            transform.Translate(0, -speed * Time.deltaTime, 0);
            ismove = true;
        }else if(movePos == true && disy < 0){
            transform.Translate(0, speed * Time.deltaTime, 0);
            ismove = true;
        }

        if(ismove == false && ishit == false){
            spRe.sprite = petstop;
        }else if(ismove == true && ishit == true){
            spRe.sprite = pethit;
        }else if(ismove == true && ishit == false){
            spRe.sprite = petmove;
        }
    }

    public void hit(){
        ishit = true;
        StartCoroutine(hit(10.0f));
    }

    IEnumerator hit (float cool){
        print("쿨");
        movePos = false;
        ismove = false;
        ishit = false;
        transform.position = new Vector3(-1, 0, 0);
        while(cool > 0.00f){
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        movePos = true;
    }
}
