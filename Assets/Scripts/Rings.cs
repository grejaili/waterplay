using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
//new Vector3(-14, Mathf.Clamp(yPos, -7, 7), 0);
float yMinimumPos;
Vector3 ringPos;
// Update is called once per frame
void Update()
{
    yMinimumPos = transform.position.y;
    ringPos = new Vector3(this.transform.position.x, Mathf.Clamp(yMinimumPos, 171.4f, 215), this.transform.position.z);
    gameObject.transform.position = ringPos;
}

}
//asdaasdads