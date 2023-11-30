using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    //int gold;

    public Text gold_text;
    public Text slime_text;

    //public SaveManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) {
            gold_text.text = "" + GameManager.instance.gold;
            slime_text.text = "size : " + GameManager.instance.slime_size;
        }
    }
}
