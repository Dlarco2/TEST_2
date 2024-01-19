using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scrip_Time : MonoBehaviour
{
    public Image img_Circle;
    public float time_complete = 1;
    public List<Color> colors;
    public int var_color;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reiniciar());
   
    }

    IEnumerator Reiniciar()
    {
        //var_color = Random.Range(0, colors.Count);
        img_Circle.DOColor(colors[var_color], 0.25f);
        img_Circle.fillAmount = 0;
        img_Circle.DOFillAmount(1, time_complete);
        yield return new WaitForSeconds(time_complete);
        var_color++;
        if (var_color == colors.Count)
            var_color = 0;
        StartCoroutine(Reiniciar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
