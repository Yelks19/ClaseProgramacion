using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public DataJSON misDatos;
    public Text T_Titulo;
    public InputField T_Jugador;
    public GameObject panelUI;
    // Start is called before the first frame update
    void Start()
    {
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            Debug.Log(s);
            Debug.Log(misDatos);
            Debug.Log(misDatos.nombre_juego);
            s = JsonUtility.ToJson(misDatos, true);
            Debug.Log(s);
            File.WriteAllText(filePat, s);
        }
        cargaDatos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
     {
         panelUI.SetActive(true);
     }
    }

    void cargaDatos ()
    {
        GameObject.Find("T_titulo").GetComponent<Text>().text = misDatos.nombre_juego;
        T_Titulo.text = misDatos.nombre_juego;
        T_Jugador.text = misDatos.nombre_jugador;
    }

    public void guardarDatos()
    {
        misDatos.nombre_jugador = T_Jugador.text;
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";
        string s = JsonUtility.ToJson(misDatos, true);
        File.WriteAllText(filePat, s);
    }

}
