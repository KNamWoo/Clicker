using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_Scene : MonoBehaviour
{
    //public int SceneNumber;

    public void homeload(){
        LoadingSceneManager.LoadScene("Home");
    }
    public void dungeonload() {
        LoadingSceneManager.LoadScene("Dungeon");
    }
}