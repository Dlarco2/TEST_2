using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemigo_Script : MonoBehaviour
{
    public int hp;
    public Ptcl_Damage ptcl_Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bala")
        {
            gameObject.GetComponent<SpriteRenderer>().DOColor(Color.red, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.1f).SetDelay(0.1f);
            print(collision.collider.name);
            hp--;
            Destroy(collision.collider);
            if (hp == 0)
            {
                ptcl_Damage.ReturnPJ();
                gameObject.SetActive(false);
            }

        }
        
    }
}
