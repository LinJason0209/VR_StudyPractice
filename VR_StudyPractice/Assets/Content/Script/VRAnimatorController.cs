using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    public float speedTreshold = 0.1f;
    [Range(0,1)]
    public float smoothing = 1;
    private Animator animator;
    private Vector3 previousPos;
    private VRRig vrRig;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        previousPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        ///計算速度
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previousPos) / Time.deltaTime;
        headsetSpeed.y = 0;
        ///將算出來的值轉成local座標下的速度
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        //設定 Animator 的值來判斷動畫
        float previousDirctionX = animator.GetFloat("DirectionX");
        float previousDirctionY = animator.GetFloat("DirectionY");
        animator.SetBool("isMove",headsetLocalSpeed.magnitude > speedTreshold);
        animator.SetFloat("DirectionX", Mathf.Lerp(previousDirctionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1),smoothing));
        animator.SetFloat("DirectionY", Mathf.Lerp(previousDirctionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1),smoothing));

    }
}
