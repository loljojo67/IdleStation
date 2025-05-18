using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] List<Upgrade> upgrade = new List<Upgrade>();

    [SerializeField] ClickManager cm;

    [SerializeField] TMP_Text prix;
    [SerializeField] TMP_Text nom;
    [SerializeField] TMP_Text desc;

    public List<Upgrade> Upgrade;
    [SerializeField] bool upgarder = false;

    

    public void UpgradeAchat(){
        for (int i = 0; i < upgrade.Count; i++ ){
            if (upgarder == true){

            }

            cm.Achat(upgrade.prixBase, Upgrade.multiplicateur);
        }

    }
}
