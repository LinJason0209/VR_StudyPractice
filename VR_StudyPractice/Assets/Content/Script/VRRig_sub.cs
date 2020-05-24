using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 

public class VRRig_sub : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstaint;
    public Vector3 headBodyoffset;
    //public int turnSmootness;
    // Start is called before the first frame update
    void Start()
    {
        headBodyoffset = transform.position - headConstaint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headConstaint.position + headBodyoffset;
        //transform.forward = Vector3.Lerp(transform.position, Vector3.ProjectOnPlane(headConstaint.up, Vector3.up).normalized, Time.deltaTime * turnSmootness);
        transform.forward = Vector3.ProjectOnPlane(headConstaint.up, Vector3.up).normalized;
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
