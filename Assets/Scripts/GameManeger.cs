using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour {

// gyrocospe
    Gyroscope gyro;


//gameplay
    GameObject gate1;
    GameObject gate2;
    GameObject gate3;
    bool gateOpen;



    //---------
    // UI --- settings
    Text debugText;


    bool fireAxisInUse = false;
    void Start () {

        //UI
        debugText = GameObject.FindGameObjectWithTag("UI").GetComponent<Text>();
        //gameplay
        gate1 = GameObject.Find("JetStreamBotton");
        gate2 = GameObject.Find("JetStreamRight");
        gate3 = GameObject.Find("JetStreamLeft");
    }

    // Update is called once per frame
void Update () {

#region fire
if (Input.GetAxis("Fire1") !=0)
{
    if (fireAxisInUse == false)
        {
        ExplosionDamage(gate1.transform.position, 1000f);
        ExplosionDamage(gate2.transform.position, 1000f);
        ExplosionDamage(gate3.transform.position, 1000f);

        //  gate.SetActive(false);
        fireAxisInUse = true;
                debugText.text = "fired";
        }
}
    if (Input.GetAxisRaw("Fire1") == 0)
    {
       fireAxisInUse = false;
            debugText.text = "noppp";
    }
        #endregion

        ChangeGravity();
        InitMobileConf();
        
}


    void ExplosionDamage(Vector3 center, float radius)
    {



        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Ring")
            {

        
                hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(390f,center,150f);
       
            }
            i++;
        }
    }

   
    void InitMobileConf()
    {
        if (SystemInfo.supportsGyroscope == true)
        {
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;
            Debug.Log("hueuhe");
        }
    }

    void ChangeGravity()
    {
        Physics.gravity = Input.gyro.gravity * 10;
    }
    
}
