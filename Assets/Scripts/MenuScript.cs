using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ToMenu1()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMenu2()
    {
        SceneManager.LoadScene(2);
    }

    public void ToMenu3()
    {
        SceneManager.LoadScene(3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
