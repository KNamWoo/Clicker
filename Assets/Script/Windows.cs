using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windows : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Floating()
    {
        if(window.activeSelf == true) {
            window.SetActive(false);
        } else {
            window.SetActive(true);
        }
    }
}
