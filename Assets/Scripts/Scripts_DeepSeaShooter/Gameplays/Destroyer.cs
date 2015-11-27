using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    #region Main Methods
    void DestroyGameObject()
    {
        //This will destroy the animation a the last frame
        Destroy(gameObject); 
    } 
    #endregion
}
