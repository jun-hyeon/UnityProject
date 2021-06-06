using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnEvent : MonoBehaviour
{
    public GameObject btn;
    public FindEvent fe;
    // Start is called before the first frame update
    void Start()
    {
        btn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fe.count == 1) { 
        btn.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
