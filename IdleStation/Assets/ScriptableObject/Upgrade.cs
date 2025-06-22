using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Objects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public enum TypeUpgrade
    {
        Clique,
        Idle
    }

    public string nom;
    public string description;
    public TypeUpgrade type;
    public int prixBase;
    public float multiplicateur;
}
