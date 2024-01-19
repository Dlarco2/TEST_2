using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class Controlador_Popup : MonoBehaviour
{
    public GameObject popup1;
    public List<GameObject> obj_img;
    public Text txt_Arma;
    public string description;


    // Start is called before the first frame update
    void Start()
    {
        popup1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AparecerPopup();
        }

    }

    public void AparecerPopup()
    {
        //if (popup1.activeSelf == true)
        //{
        //    popup1.transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InFlash).OnComplete(() => popup1.SetActive(false));
        //}
        //else
        //{
        //    popup1.SetActive(true);
        //    popup1.transform.localScale = Vector3.zero;
        //    popup1.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic);


        //}
        popup1.SetActive(true);
        popup1.transform.localScale = Vector3.zero;
        popup1.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic);
        popup1.transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InFlash).OnComplete(() => 
        {
            print("pasaron los 3 segundos");
            popup1.SetActive(false);

        }).SetDelay(3);

    }

    public void AparecerImgInventario(int var, string nombre_arma)
    {
        obj_img[var].SetActive(true);
        switch (nombre_arma)
        {
            case "Macana":
                description = "esto es una arma de CORTO alcance";
                break;
            case "Beretta":
                description = "esto es una arma de MEDIANO alcance";
                break;
            case "Fusil":
                description = "esto es una arma de LARGO alcance";
                break;
            default:
                break;
        }
        txt_Arma.text = nombre_arma + " \n" + description;
    }
}
