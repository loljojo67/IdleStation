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
    [SerializeField] int i = 0;
    private void Start()
    {
        prix.text = upgrade[i].prixBase.ToString();
        nom.text = upgrade[i].nom;
        desc.text = upgrade[i].description;
    }

    public void UpgradeAchat()
    {
        if (upgrade[i].nom != "Fini")
        {
            i++;
            cm.Achat(upgrade[i].prixBase, upgrade[i].multiplicateur);
            prix.text = upgrade[i].prixBase.ToString();
            nom.text = upgrade[i].nom;
            desc.text = upgrade[i].description;
        }
    }
}
