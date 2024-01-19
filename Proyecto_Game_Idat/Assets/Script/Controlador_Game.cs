using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Controlador_Game : MonoBehaviour
{
    public Image fadeout;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarGame()
    {
        fadeout.DOFade(0, 0.75f);
    }
}
