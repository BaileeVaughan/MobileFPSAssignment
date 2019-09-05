using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputType : MonoBehaviour
{
    public GameObject droppyCube;
    public Rigidbody rigid;
    public float speed;

    void OnTouchDown()
    {
        rigid.velocity = Vector3.up * speed;
        Debug.Log("Down");
    }
    void OnTouchStay()
    {
        Debug.Log("Stay");
    }
    void OnTouchUp()
    {
        Debug.Log("Up");
    }
    void OnTouchExit()
    {
        Debug.Log("Exit");
    }
}
