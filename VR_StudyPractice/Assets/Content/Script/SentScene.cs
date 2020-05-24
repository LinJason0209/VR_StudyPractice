using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SentScene : MonoBehaviour
{
    //public Scene CurrentScene;
    public GameObject Player;
    public int NextSceneIndex;
    //public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Player.transform.position.z>1)
        {
            //sentDistanceGrab(NextScene);
            SceneManager.LoadScene(1);
        }*/
    }
    public void sentDistanceGrab(int setScenes)
    {
        SceneManager.LoadScene(setScenes);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == Player.name)
        {
            sentDistanceGrab(NextSceneIndex);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //sentDistanceGrab(NextScene);
        
    }
}
