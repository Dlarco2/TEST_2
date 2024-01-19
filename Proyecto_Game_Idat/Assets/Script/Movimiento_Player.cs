using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movimiento_Player : MonoBehaviour
{
    public ParticleSystem ptcl_rayo;
    public float move_Input;
    public float speed;
    public Rigidbody2D rgbd2d;
    public List<GameObject> obj_armas;
    public GameObject obj_fusil;
    public Transform ref_mano;
    public float var_Temblor = 3;

    public float tiempo;
    public Controlador_Popup controlador_Popup;
    public int id_objeto;

    public Text cartuchos_txt;
    public Text puntaje_txt;
    public int cartuchos_totales = 0;
    public int puntaje = 0;

    public GameObject popup_muerto;
    public bool heMuerto = false;

    public GameObject bala_prefab;

    public bool is_combo;
    public int nivel_combo;

    public Queue<KeyCode> inputCombo;
    public KeyCode keyToDetect = KeyCode.W;
    public List<string> letras_presionadas;


    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(TemblarConTiempo());
        inputCombo = new Queue<KeyCode>();
    }
    IEnumerator TemblarConTiempo()
    {
        yield return new WaitForSeconds(var_Temblor);
        ptcl_rayo.Play();
        Camera.main.transform.DOShakePosition(1, 10, 10,90 ).SetDelay(1.25f).OnComplete(()=> StartCoroutine(TemblarConTiempo()));
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        //print(tiempo);
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    tiempo = 0;
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReiniciarEscena();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala_prefab, gameObject.transform.GetChild(0).position , Quaternion.identity );
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            tiempo = 0;
            is_combo = true;
         
            //keyToDetect = Event.current.keyCode;
            //print(Event.current.keyCode);
            //inputCombo.Enqueue(Input.anyKey));

        }
        if (Input.anyKey && is_combo)
        {
            var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
            foreach (var key in allKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    Debug.Log(key + " was pressed.");
                    letras_presionadas.Add(key.ToString());
                    inputCombo.Enqueue(key);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.N) && is_combo == false)
        {
            StartCoroutine(DequeueInputs());
        }
       
        //if (Input.anyKey && is_combo)
        //{
        //    Event e = Event.current;
        //    print(e);
        //    var c = Input.inputString;
        //    Debug.Log(c);
        //    if (Input.inputString != "")
        //    {
        //        KeyCode key1 = (KeyCode)Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
        //        letras_presionadas.Add(Input.inputString);
        //        print(key1);
        //        inputCombo.Enqueue(key1);
        //        //Debug.Log(c);
        //    }
        //}

        //if ( Input.GetKeyDown(KeyCode.G) && is_combo && nivel_combo ==0)
        //{
            

        //    nivel_combo = 1;
        //    tiempo = 0;
        //    print("combo 1");
          
        //}
        //if (Input.GetKeyDown(KeyCode.H) && is_combo && nivel_combo == 1)
        //{
        //    nivel_combo = 2;
        //    tiempo = 0;
        //    print("combo 2");

        //}
        //if (Input.GetKeyDown(KeyCode.J) && is_combo && nivel_combo == 2)
        //{
        //    nivel_combo = 3;
        //    tiempo = 0;
        //    print("COMBO FINAL");

        //}
        if (is_combo)
        {
            if(tiempo < 3)
            {
                print("estoy en combo");
            }
            else
            {
                print("acabo combo");
                is_combo = false;
            }
        }


    }
    //public class Test : MonoBehaviour { private void OnGUI() { if (Event.current.isKey) { Debug.Log(Event.current.keyCode); } } }
    IEnumerator DequeueInputs()
    {
        if(inputCombo.Count > 0)
        {
            Debug.Log(inputCombo.Peek());
            inputCombo.Dequeue();
            yield return new WaitForSeconds(1);
        }
        else
        {
            print("no hay en cola");
        } 
       

    }
    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        if(heMuerto == false)
        {
            move_Input = Input.GetAxisRaw("Horizontal");
            rgbd2d.velocity = new Vector2(move_Input * speed, rgbd2d.velocity.y);
        }
  


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "item")
        {
            controlador_Popup.AparecerPopup();
            print(collision.name);
            if(collision.name != "Fusil")
                collision.gameObject.SetActive(false);
          

            switch (collision.name)
            {
                case "Fusil":
                    id_objeto = 2;
                    obj_fusil.transform.parent = transform;
                    obj_fusil.transform.DOMove(ref_mano.position, 0.15f);
                    obj_fusil.transform.DOScale(1, 0.15f);
                    for (int i = 0; i < obj_armas.Count; i++)
                    {
                        obj_armas[i].SetActive(false);
                    }
                    break;

                case "Macana":
                    
                case "Beretta":
                    if(collision.name == "Macana")
                        id_objeto = 0;
                    else
                        id_objeto = 1;

                    for (int i = 0; i < obj_armas.Count; i++)
                    {
                        if (obj_armas[i].name == collision.name)
                            obj_armas[i].SetActive(true);
                        else
                            obj_armas[i].SetActive(false);

                    }
                    break;
                case "Cartuchos":
                    puntaje += 1;
                    cartuchos_totales += 20;
                    cartuchos_txt.text = cartuchos_totales.ToString();
                    puntaje_txt.text = puntaje.ToString();
                    return;
                default:
                    print("no se cual es");
                    break;
            }

            controlador_Popup.AparecerImgInventario(id_objeto, collision.name);
        }
        else if (collision.tag == "Enemigos")
        {
            puntaje -= 1;
            puntaje_txt.text = puntaje.ToString();
            print(collision.name);
            if(puntaje <= 0)
            {
                heMuerto = true;
                popup_muerto.SetActive(true);
                popup_muerto.transform.DOScale(1, 0.25f);
                print("he muerto");
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                puntaje = 0;
                puntaje_txt.text = puntaje.ToString();
                print(gameObject.transform.childCount);
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(gameObject.transform.GetChild(i).transform.tag != "MainCamera")
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }

            }
        }
        else if (collision.tag == "Final")
        {

        }
        else
        {
            print("no es un item");
        }

    }
}
