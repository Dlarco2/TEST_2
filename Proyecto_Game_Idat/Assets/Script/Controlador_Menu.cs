using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Controlador_Menu : MonoBehaviour
{
    public Image fade;
    public Controlador_Game controlador_Game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEscena(string name_scene)
    {
        fade.DOFade(1, 0.5f).OnComplete(()=> 
        {
            controlador_Game.IniciarGame();
            SceneManager.LoadScene(name_scene);

        }  );
    }

  
}
