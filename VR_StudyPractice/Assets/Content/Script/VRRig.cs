using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class VRMap 
{
    public Transform vrTarget; //VR控制器
    public Transform rigTarget; //IK控制器
    public Vector3 trackingPositionOffset; //位置調正
    public Vector3 trackingRotationOffset; //旋轉調整

    public void Map() 
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset); //將VR控制器的座標位置轉成世界座標後同步IK位置
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset); //將VR控制器的座標軸向轉成世界座標後同步IK軸向
    }
}
public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstaint; //頭部IK控制器
    public Vector3 headBodyoffset; //頭部IK位置初始化
    public int turnSmootness; //平滑值
    // Start is called before the first frame update
    void Start()
    {
        headBodyoffset = transform.position - headConstaint.position; //取得人物模型與頭部IK控制器的位置差
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headConstaint.position + headBodyoffset; //將人物模型與頭部IK控制器的位置差補上(同步化)
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstaint.up, Vector3.up).normalized, Time.deltaTime*turnSmootness); //blue 軸 = z 軸 = 物件世界坐標通常的正前方。這裡是實作腳步
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
