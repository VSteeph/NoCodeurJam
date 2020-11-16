using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool once;
    private int ind;

    public void LoadScene(int SceneIndex)
    {
        if(!once)
        {
            anim.SetBool("Open", false);
            Invoke("Scene",1);
            once = true;
            ind = SceneIndex;
        }
        
    }

    void Scene()
    {
        once = false;
        SceneManager.LoadScene(ind);
        anim.SetBool("Open", true);
    }

}
