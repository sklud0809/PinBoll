using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;
    private int fingerId = -1;

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
        
    }


    void Update()
    {
        //Debug.Log(Input.touchCount);
        
       
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
               



                
               if(touch.phase == TouchPhase.Began)
                {

                   
                    if ( Input.GetMouseButton(0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {

                        fingerId = touch.fingerId;
                        Debug.Log(this.fingerId + "右");

                       
                            SetAngle(this.flickAngle);
                        state = State._flickAngle;

                    }
                    else if(Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        fingerId = touch.fingerId;
                        Debug.Log(this.fingerId + "左");
                        SetAngle(this.flickAngle);
                        state = State._flickAngle;
                    }

                }
               else if(touch.phase == TouchPhase.Ended)
                {
                    if(Input.GetMouseButtonUp(0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {

                        SetAngle(this.defaultAngle);
                        state = State._defaultAngle;
                    }
                    else if(Input.GetMouseButtonUp(0) && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                        state = State._defaultAngle;
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
