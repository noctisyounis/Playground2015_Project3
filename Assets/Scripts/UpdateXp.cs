using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateXp : MonoBehaviour
{

    #region Public Variable
    public Creature creature;
    #endregion

    #region Main Methodes
    void Start()
    {
        xpSlider = GetComponent<Slider>();
        xpSlider.maxValue = creature.m_xpMax;
    }

    void Update()
    {
        xpSlider.value = creature.UpdateXP();
    }
    #endregion

    #region Utils

    #endregion

    #region Private & Protected Variables
    Slider xpSlider;
    #endregion
}
