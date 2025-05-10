using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Upgrade upgrade;
    [SerializeField] ClickManager cm;

    [SerializeField] TMP_Text prix;
    [SerializeField] TMP_Text nom;
    [SerializeField] TMP_Text desc;

    void Start()
    {
        prix.text = upgrade.prixBase.ToString();
        nom.text = upgrade.nom;
        desc.text = upgrade.description;
    }

    public void UpgradeAchat(){
        cm.Achat(upgrade.prixBase, upgrade.multiplicateur);
    }
}
