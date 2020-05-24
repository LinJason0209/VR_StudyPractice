using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public GameObject rotate;
    public GameObject rotation;
    public GameObject look;
    public float speed=0.1f;
    public int headFinit = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runRotate(rotate);
        runRotation(rotation);
    }

    public void runRotate(GameObject rotate)
    {
        rotate.transform.Rotate(Vector3.up * 5);
    }
    public void runRotation(GameObject rotation)
    {
        //rotation.transform.rotation = Quaternion.Euler(Vector3.up * 5);
        if (look.transform.rotation.eulerAngles.y>headFinit || look.transform.rotation.eulerAngles.y < -headFinit)
        {
            //rotation.transform.rotation = Quaternion.Lerp(rotation.transform.rotation, look.transform.rotation, speed * Time.deltaTime * 10);
            rotation.transform.rotation = Quaternion.Lerp(rotation.transform.rotation,
                Quaternion.Euler(new Vector3(
                    rotation.transform.rotation.eulerAngles.x, 
                    look.transform.rotation.eulerAngles.y, 
                    rotation.transform.rotation.eulerAngles.z)), 
                    speed * Time.deltaTime * 10);
        }

       // rotation.transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), look.transform.rotation, finSpeed);
    }
}

