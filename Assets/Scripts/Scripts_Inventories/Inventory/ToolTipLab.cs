using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTipLab : MonoBehaviour {

    private Item m_item;
    private string m_data;
    public GameObject m_toolTipLab;
    

    void Start()
    {
        
        if (m_toolTipLab == null) Debug.Break();
        m_toolTipLab.SetActive(false);

    }

    void Update()
    {
        //if (m_toolTipLab.activeSelf)
        //{
        //    m_toolTipLab.transform.position = Input.mousePosition;
        //}

    }

    private string SettingTooltip(Item item)
    {
        string dataTmp = "";


        dataTmp += "Name: " + item.Name + "\n" + " Type: " + item.TypeItem.ToString() + "\n\n";
        dataTmp += "Description: \n" + item.Description + "\n\n";
        dataTmp += "Intensity: " + item.Intensity + "\n\n";

        dataTmp += "Rarety level: ";

        switch (item.LevelRarity)
        {
            case e_itemRarity.None:
                break;
            case e_itemRarity.Normal:
                //Grey
                dataTmp += "<color=#9A9A9A>Normal";
                break;
            case e_itemRarity.Unusual:
                //Green
                dataTmp += "<color=#23C902>Unusual";
                break;
            case e_itemRarity.Rare:
                //Blue
                dataTmp += "<color=#024EC9>Rare";
                break;
            case e_itemRarity.Epic:
                //Mauve
                dataTmp += "<color=#A102C9>Epic";
                break;
            default:
                break;
        }

        dataTmp += "</color>";

        return dataTmp;
    }

    public void Activate(Item item)
    {
        m_item = item;
        CreateTooltip();
        m_toolTipLab.SetActive(true);
    }

    public void Desactivate()
    {
        m_toolTipLab.SetActive(false);
    }

    public void CreateTooltip()
    {
        string DataTmp = "";

        DataTmp = SettingTooltip(m_item);

        m_data = DataTmp;

        m_toolTipLab.transform.GetChild(0).GetComponent<Text>().text = m_data;
    }
}
