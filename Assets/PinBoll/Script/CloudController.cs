using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {


    private float minimum = 1.0f;　//最小サイズ
    private float magSpeed = 10.0f; //拡大縮小スピード
    private float magnification = 0.07f; //拡大率


    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this. magSpeed) * this.magnification);	
	}
}
