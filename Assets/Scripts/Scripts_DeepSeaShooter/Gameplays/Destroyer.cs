using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    #region Main Methods
    void DestroyGameObject()
    {
        Destroy(gameObject); //This will destroy the animation a the last frame
    } 
    #endregion
}
