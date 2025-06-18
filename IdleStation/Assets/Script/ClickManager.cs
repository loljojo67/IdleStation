using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    [SerializeField] TMP_Text Argent_TXT;
    public int argent = 0;

    public double tauxIdle = 1;
    public double tauxClick = 1;

    public float delay = 1;
    void Start()
    {
        /*Charger();*/
        InvokeRepeating("Idle", 1f, delay);
    }

    void Update()
    {
        Argent_TXT.text = math.floor(argent).ToString();
    }


    public void Idle()
    {
        argent += (int)math.floor(tauxIdle);
    }

    public void Click()
    {
        argent += (int)math.floor(tauxClick);
    }

    public void Achat(int prix, float multiplicateur)
    {
        if (argent >= prix)
        {
            argent -= prix;
            tauxClick *= multiplicateur;
        }
    }


    /*Sauvegarde/Charge*/
/*
    public void Sauvegarder()
    {
        PlayerPrefs.SetString("argent", argent.ToString());
        PlayerPrefs.SetString("tauxDeProduction", tauxDeProduction.ToString());
        PlayerPrefs.SetString("tauxDeClique", tauxDeClique.ToString());
        PlayerPrefs.SetString("prixClique", prixClique.ToString());
        PlayerPrefs.SetString("prixProduction", prixProduction.ToString());
        PlayerPrefs.Save();
    }

    public void Charger()
    {
        argent = int.Parse(PlayerPrefs.GetString("argent", "0"));
        tauxDeProduction = double.Parse(PlayerPrefs.GetString("tauxDeProduction", "1"));
        tauxDeClique = double.Parse(PlayerPrefs.GetString("tauxDeClique", "1"));
        prixProduction = int.Parse(PlayerPrefs.GetString("prixProduction", "1"));
        prixClique = int.Parse(PlayerPrefs.GetString("prixClique", "1"));
    }

    void OnApplicationQuit()
    {
        Sauvegarder();
    }*/
}