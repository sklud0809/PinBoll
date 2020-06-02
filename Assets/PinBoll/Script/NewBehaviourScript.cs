using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    int fingerId = -1;

    // Use this for initialization
    void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update () {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2 && tag == "RightFripperTag")
                {
                    fingerId = t.fingerId;
                    Debug.LogFormat("fingerId: {0} の指で右側をタッチした", this.fingerId);

                }
                else if (t.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
                {
                    fingerId = t.fingerId;
                    Debug.LogFormat("fingerId: {0} の指で左側をタッチした", this.fingerId);

                }

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

    void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;

    }

}
