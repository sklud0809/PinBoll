using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;
    private int fingerId = -1;

    float RightScreenMax = 0.0f;
    float RightScreenMin = 0.0f;
    
    float LeftScreenMax = 0.0f;
    float LeftScreenMin = 0.0f;
    

    enum State
    {
        _defaultAngle,
        _flickAngle
    }
    State state;
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
        state = State._defaultAngle;


        //タッチのｘ座標の範囲指定
        RightScreenMax = Screen.width;
        RightScreenMin = Screen.width / 2;

        LeftScreenMax = Screen.width / 2;
        LeftScreenMin = 0.0f;
   
    
    }


    void Update()
    {
        //Debug.Log(Input.touchCount);
       
       
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {




                　//右スクリーンタップ時にフリッパーが上がる
                if (RightScreenMax >= touch.position.x && RightScreenMin <= touch.position.x && tag == "RightFripperTag")
                {

                    　　//タッチしている間フリッパーが上がる
                    if (touch.phase == TouchPhase.Began)
                    {

                        fingerId = touch.fingerId;
                        Debug.Log(this.fingerId + "右");

                       
                            SetAngle(this.flickAngle);
                        state = State._flickAngle;

                    }
                    //タッチ状態から話すと、フリッパーが下がる
                   else if (touch.phase == TouchPhase.Ended)
                    {
                        if (  RightScreenMax >= touch.position.x &&  RightScreenMin <= touch.position.x && tag == "RightFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                            state = State._defaultAngle;
                        }
                    }

                }
               else if (LeftScreenMax >= touch.position.x && LeftScreenMin <= touch.position.x && tag == "LeftFripperTag") 
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        fingerId = touch.fingerId;
                        Debug.Log(this.fingerId + "左");
                        SetAngle(this.flickAngle);
                        state = State._flickAngle;

                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        if (LeftScreenMax >= touch.position.x &&  LeftScreenMin <= touch.position.x && tag == "LeftFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                            state = State._defaultAngle;
                        }
                    }
                }
            }　　　　
        }
        else if (state == State._flickAngle)
        {
            //Debug.Log("タッチなし");
            if(tag  == "RightFripperTag" || tag == "LeftFripperTag")
            {
                SetAngle(defaultAngle);
               
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);

        }
    }
    public void SetAngle(float angle)
    {
        JointSpring joinspr = this.myHingeJoint.spring;
        joinspr.targetPosition = angle;
        this.myHingeJoint.spring = joinspr;
    }

   

    
}
