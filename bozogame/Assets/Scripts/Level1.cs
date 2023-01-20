using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{

        void Start ()   
    {

    }

    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }
    
    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }
    

}