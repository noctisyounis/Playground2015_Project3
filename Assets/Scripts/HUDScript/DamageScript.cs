using UnityEngine;
using System.Collections;


public class DamageScript : MonoBehaviour {

    public int DamageOnAttack = 20;
    GameObject Player;
    HungryScript Hunger;

    #region Debug
    void OnGUI()
    {
        if (GUILayout.Button("damage"))
        {
            GameObject.Find("Hugh_Jackman").GetComponent<HungryScript>().TakeDamage(DamageOnAttack);
        }
    } 
    #endregion
}
