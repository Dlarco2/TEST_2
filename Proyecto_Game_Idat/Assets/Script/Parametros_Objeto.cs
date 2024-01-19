using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametros_Objeto : MonoBehaviour
{
    public string nombre_item;
    public string id_item;
    public ObjetoCura objetoCura;
    public ObjetoDamage objetoDamage;
    public ObjetoRecarga objetoRecarga;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = nombre_item;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class ObjetoCura
    {
        public int cura_Porcentual;
        public int id_Cura;
        public Color cura_Color;
        public string description;
    }
    [System.Serializable]
    public class ObjetoDamage
    {
        public int damage;
        public int id_Damage;
        public Color cura_Color;
        public string description;
    }
    [System.Serializable]
    public class ObjetoRecarga
    {
        public int recarga;
        public int id_Arma;
        public Color cura_Color;
        public string description;
    }


}
