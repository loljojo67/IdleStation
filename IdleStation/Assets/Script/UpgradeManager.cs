using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ClickManager cm;
    public List<Upgrade> upgrade = new List<Upgrade>();

    [SerializeField] TMP_Text nom;
    [SerializeField] TMP_Text desc;
    [SerializeField] TMP_Text prix_txt;

    [SerializeField] float multiplicateur = 1;

    [SerializeField] private int i = 0;
    float prix;
    float multPrix = 1.5f;

    void Start()
    {
        nom.text = upgrade[i].nom;
        desc.text = upgrade[i].description;
        prix_txt.text = upgrade[i].prixBase.ToString();
        multiplicateur = upgrade[i].multiplicateur;
    }

    void UpdateUpgrade()
    {
        multiplicateur *= upgrade[i].multiplicateur;
        multiplicateur = MathF.Round(multiplicateur);
        prix = upgrade[0].prixBase * MathF.Pow(multPrix, i);
        prix = Mathf.Round(prix);
    }

    void TextUpdate()
    {
        nom.text = upgrade[i].nom;
        desc.text = upgrade[i].description;
        prix_txt.text = prix.ToString();
        multiplicateur = upgrade[i].multiplicateur;
    }
    public void Upgrade()
    {
        if (cm.argent >= upgrade[i].prixBase)
        {

            cm.Achat(upgrade[i].prixBase, multiplicateur);
            i++;
            if (upgrade[i].nom == "Fini")
            {
                gameObject.GetComponent<Button>().interactable = false;
                prix_txt.gameObject.SetActive(false);
            }
            UpdateUpgrade();
            TextUpdate();

        }
        else
        {
            Debug.Log("Pas assez d'argent");
        }
    }


}
