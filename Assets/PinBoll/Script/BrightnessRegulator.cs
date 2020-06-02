using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

    private Material myMaterial;
    private float minEmission = 0.3f;　//　Emissionの最小値
    private float magEmission = 2.0f;　　//Emissionの強度
    private int degree = 0;　//角度
    private int speed = 10;　//発光速度
    Color defaultColor = Color.white; //ターゲットのデフォルトの色
	
	void Start ()
    {
        //タグによって光らせる色を変える
	if(tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }	
        else if(tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material ;
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
	}
	
	
	void Update ()
    {
	if(this.degree >= 0 )
        {
            //光の強度の計算
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            myMaterial.SetColor("_EmissionColor", emissionColor);
            this.degree -= this.speed;

        }	
	}

    private void OnCollisionEnter(Collision collision)
    {
        this.degree = 180;
    }
}
