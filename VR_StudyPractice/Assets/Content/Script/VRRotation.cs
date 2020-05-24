using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRRotation : MonoBehaviour
{
    //public GameObject PlayerHead;

   // private Vector3 OriginRotation; //原始軸值
   // private Vector3 CurrentRotation; //現在軸值
   // private Vector2 RightTumbStick;//存放右Touch gamepad軸值
    //private bool setRotation=false;//目前無用
   // public Text text;//Debug
    //public Text text2;//Debug
   // public Text text3;//Debug
    public GameObject Player;//玩家人物模型
    public GameObject Head;//頭控制器

    public float speed = 0.1f;//身體速度
    public int headFinit = 45;//頭轉極限

    //public Text text2;
    //private Vector3 set = new Vector3(0.1f, 0.1f,0.1f);

    // Start is called before the first frame update
    void Start()
    {
        //OriginRotation = headRotation.transform.rotation.eulerAngles;//以Player作為正向，或headRotation做正向，作為錨點
    }

    // Update is called once per frame
    void Update()
    {
        //CurrentRotation = headRotation.transform.rotation.eulerAngles;
        ///setVrRotationByHead();
        //setVrRotationByAxis();
        //test();
        VrRotation();
        
    }

   /* public void setVrRotationByThumb()//使用右手把軸做旋轉判斷
    {
        RightTumbStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);//取得軸值
       
        if (RightTumbStick.x > 0)//向右轉
        {
            text.text = "rotation:" + Player.transform.rotation.eulerAngles;
           // Player.transform.rotation =  Quaternion.Euler(0, (Player.transform.rotation.y + 25 ), 0);
            Player.transform.Rotate(0, 1, 0);
        }
        else if (RightTumbStick.x < 0)//向左轉
        {
            text.text = "rotation:" + Player.transform.rotation.eulerAngles;
            //Player.transform.rotation = Quaternion.Euler(0, (Player.transform.rotation.y - 10), 0);
            Player.transform.Rotate(0,-1,0);
        }
        else
        {
            //transform.rotation= transform.rotation;
        }
    }*/
    /*public void setVrRotationByHead()//用頭部轉動作旋轉判斷
    {
        text2.text = " setRotation:" + setRotation;       
        float targetSet = CurrentRotation.y - OriginRotation.y;
        text.text = "headset:" + targetSet;

        if (targetSet >= 45 || targetSet <= -45)
        {
            setRotation = true;
        }

        if (setRotation)
        {

            if (Player.transform.rotation.eulerAngles.y < CurrentRotation.y)
            {
                Player.transform.Rotate(0, 2, 0);
                text3.text = "Rotation:" + Player.transform.rotation.eulerAngles.y + "1";
            }
            else if (Player.transform.rotation.eulerAngles.y >= CurrentRotation.y)//當身體跟頭方向相同時
            {
                setRotation = false;
                OriginRotation = headRotation.transform.rotation.eulerAngles;

            }

            if (Player.transform.rotation.eulerAngles.y > CurrentRotation.y)
            {
                Player.transform.Rotate(0, -2, 0);
                text3.text = "Rotation:" + Player.transform.rotation.eulerAngles.y + "2";
            }
            else if (Player.transform.rotation.eulerAngles.y <= CurrentRotation.y)
            {
                setRotation = false;
                OriginRotation = headRotation.transform.rotation.eulerAngles;

            }
        }
        ////////////////////////////////////////////////////////////////////
       if (targetSet >= 45)//當游向右轉，頭部現在方向與人物(錨點頭部)正向的夾角 >? e.g: 45
        {
                if (Player.transform.rotation.eulerAngles.y < CurrentRotation.y)
                {
                    Player.transform.Rotate(0, 2, 0);
                OriginRotation = Player.transform.rotation.eulerAngles;
                text.text = "Rotation:" + Player.transform.rotation.eulerAngles.y + "1";
                }
        }
        else
        {
            //if (Player.transform.rotation.eulerAngles.y != CurrentRotation.y)//如果角度已非身體需旋轉角度，修正位置
            //{
            //    Player.transform.rotation = Quaternion.Euler(CurrentRotation);
            //}
            OriginRotation = headRotation.transform.rotation.eulerAngles;           
        }

        if (CurrentRotation.y - OriginRotation.y <= -45)//當頭向左轉
        {
                if (Player.transform.rotation.eulerAngles.y > CurrentRotation.y)
                {
                    Player.transform.Rotate(0, -2, 0);
                    text.text = "Rotation:" + Player.transform.rotation.eulerAngles + "2";
                }
        }
        else
        {
                    
                    //if (Player.transform.rotation.eulerAngles.y != CurrentRotation.y)//如果角度已非身體需旋轉角度，修正位置
                   // {
                     //   Player.transform.rotation = Quaternion.Euler(CurrentRotation); 
                   // }
            OriginRotation = headRotation.transform.rotation.eulerAngles;
        }
   

    } */
    /*public void setVrRotationByAxis()//使用板基做旋轉
    {
        float RightAxisL = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);//取得軸值
        float RightAxisR = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);//取得軸值

        if (RightAxisR != 0)//向右轉
        {
            text.text = "rotation:" + Player.transform.rotation.eulerAngles;
            // Player.transform.rotation =  Quaternion.Euler(0, (Player.transform.rotation.y + 25 ), 0);
            Player.transform.Rotate(0, 1, 0);
        }
        else if (RightAxisL != 0)//向左轉
        {
            text.text = "rotation:" + Player.transform.rotation.eulerAngles;
            //Player.transform.rotation = Quaternion.Euler(0, (Player.transform.rotation.y - 10), 0);
            Player.transform.Rotate(0, -1, 0);
        }
        else
        {
            //transform.rotation= transform.rotation;
        }
    }
    public void test()///無用
    {
        if (Player.transform.rotation.eulerAngles.y != headRotation.transform.rotation.eulerAngles.y)
        {
            float debug = Player.transform.rotation.eulerAngles.y - headRotation.transform.rotation.eulerAngles.y;
            if (headRotation.transform.rotation.eulerAngles.y > Player.transform.rotation.eulerAngles.y )
            {
               // Player.transform.Rotate();
                text3.text = "Rotation:" + Player.transform.rotation.eulerAngles.y + "1";
            }
            else if(Player.transform.rotation.eulerAngles.y < headRotation.transform.rotation.eulerAngles.y)
            {
                text3.text = "Rotation:" + Player.transform.rotation.eulerAngles.y + "2";
            }
        }
        Quaternion.Euler(new Vector3(0, headRotation.transform.rotation.eulerAngles.y, 0));
    }*/
    
    public void VrRotation()
    {
        if (Head.transform.rotation.eulerAngles.y > headFinit || Head.transform.rotation.eulerAngles.y < -headFinit)//當轉向大於限制時轉身
        {
           // Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Head.transform.rotation, speed * Time.deltaTime * 10);

            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, //設置當轉身時依照參照人物頭部的.y軸旋轉
               Quaternion.Euler(new Vector3(
                   Player.transform.rotation.eulerAngles.x,
                   Head.transform.rotation.eulerAngles.y,
                   Player.transform.rotation.eulerAngles.z)),
                   speed * Time.deltaTime * 10);
        }
    }
}
