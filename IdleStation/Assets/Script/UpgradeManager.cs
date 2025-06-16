using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] List<Upgrade> upgrade = new List<Upgrade>();
    [SerializeField] ClickManager cm;

    [SerializeField] TMP_Text prix;
    [SerializeField] TMP_Text nom;
    [SerializeField] TMP_Text desc;

    [SerializeField] int i = 0; // index de l'upgrade actuel

    private void Start()
    {
        AfficherUpgrade();
    }

    public void UpgradeAchat()
    {
        if (i >= upgrade.Count || upgrade[i].nom == "Fini")
        {
             return;
        }

        float prixActuel = CalculerPrix(upgrade[i], i);

        if (cm.argent >= prixActuel)
        {
            cm.argent -= Convert.ToInt32(prixActuel);
            cm.Achat(upgrade[i].prixBase, upgrade[i].multiplicateur);

            i++; // passe à l’upgrade suivante
            if (i < upgrade.Count)
                AfficherUpgrade();
        }
        else
        {
            Debug.Log("Pas assez d'argent !");
        }
    }

    private float CalculerPrix(Upgrade upgrade, int niveau)
    {
        return upgrade.prixBase * Mathf.Pow(upgrade.multiplicateur, niveau);
    }

    private void AfficherUpgrade()
    {
        if (i >= upgrade.Count || upgrade[i].nom == "Fini")
        {
            prix.text = "Fini";
            nom.text = "Tous les upgrades sont débloqués !";
            desc.text = "";
            return;
        }

        float prixActuel = CalculerPrix(upgrade[i], i);
        prix.text = Mathf.RoundToInt(prixActuel).ToString();
        nom.text = upgrade[i].nom;
        desc.text = upgrade[i].description;
    }
}
