using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Ptcl_Damage : MonoBehaviour
{
    public ParticleSystem ptcl_explosion;
    public Transform pos_personaje;
    public Transform pos_inc;
    public Transform[] pos_path_transform;
    public Vector3[] pos_path;
    public PathType pathType;
    public PathMode pathMode;

    // Start is called before the first frame update
    void Start()
    {
        
        //pos_path[3] = pos_personaje.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReturnPJ();
        }
    }

    public void ReturnPJ()
    {
        for (int i = 0; i < pos_path_transform.Length; i++)
        {
            pos_path[i] = pos_path_transform[i].position;
        }
        //transform.position = pos_inc.position;
        transform.DOPath(pos_path, 2, pathType, pathMode, 10).SetLoops(3);
        //transform.position = pos_inc.position;
        //transform.DOJump(pos_personaje.position, 3, 1, 1.25f);
        ptcl_explosion.Play();
    }
}
