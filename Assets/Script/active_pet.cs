using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_pet : MonoBehaviour
{
    public GameObject petobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.pet_lv >= 1){
            petobj.SetActive(true);
        }
    }
}
