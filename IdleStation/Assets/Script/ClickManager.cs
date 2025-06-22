using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    [SerializeField] TMP_Text Argent_TXT;
    [SerializeField] TMP_Text Idle_TXT;
    public int argent = 0;
    public float idle;
    public double tauxIdle = 1;
    public double tauxClick = 1;

    [SerializeField] public float delay = 1f;

    private Coroutine idleCoroutine;
    void Start()
    {
        idleCoroutine = StartCoroutine(IdleLoop());
        /*Charger();*/
    }

    public void Click()
    {
        argent += (int)math.floor(tauxClick);
    }
    IEnumerator IdleLoop()
    {
        while (true)
        {
            argent += (int)math.floor(tauxIdle);
            yield return new WaitForSeconds(delay);
        }
    }

    public void ChangerDelay(float nouveauDelay)
    {
        delay = nouveauDelay;

        if (idleCoroutine != null)
        {
            StopCoroutine(idleCoroutine);
            idleCoroutine = StartCoroutine(IdleLoop());
        }
    }

    void Update()
    {
        idle = (float)tauxIdle;
        Idle_TXT.text = Math.Round(idle, 3).ToString() + "/s";
        Argent_TXT.text = math.floor(argent).ToString();
    }

    public void AchatClique(int prix, float multiplicateur)
    {
        if (argent >= prix)
        {
            argent -= prix;
            tauxClick *= multiplicateur;
        }
    }

    public void AchatIdle(int prix, float multiplicateur)
    {
        if (argent >= prix)
        {
            argent -= prix;
            tauxIdle *= multiplicateur;
        }
    }



    /*Sauvegarde Charge*/
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