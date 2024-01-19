using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Vector3 dir_bala;
    public float Speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir_bala * Time.deltaTime * Speed;


    }
}
