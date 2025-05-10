using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    [SerializeField] TMP_Text argent_conteur;
    [SerializeField] TMP_Text idleBonusTxt;
    [SerializeField] TMP_Text cliqueBonusText;

    public int prixProduction = 1;
    public double tauxDeProduction = 1;
    public int prixClique = 1;
    public double tauxDeClique = 1; 
    public int argent = 0;
    [SerializeField] int lieuDeProduction = 1;

    public float delay = 1;
    void Start()
    {
        InvokeRepeating("Idle", 1f, delay);
    }

    void Update()
    {       

        argent_conteur.text = math.floor(argent).ToString();
        idleBonusTxt.text = prixProduction.ToString();
        cliqueBonusText.text = prixClique.ToString();
    }

    public void IdleBonus()
    {
        if(argent >= prixProduction){
            argent -= prixProduction;
            tauxDeProduction *= 1.5f;
            prixProduction *= 2;       
        }
    }

    public void CliqueBonus()
    {
        if(argent >= prixClique){
            argent -= prixClique;
            tauxDeClique *= 1.5f;
            prixClique *= 2;
        }
    }

    public void Idle()
    {
        argent += (int)math.floor(tauxDeProduction);
    }

    public void Ajout(){
        argent += (int)math.floor(tauxDeClique);
    }

    public void Achat(int prix, float multiplicateur){
        if(argent >= prix){
            argent -= prix;
            tauxDeClique *= multiplicateur;
        }
    }
}