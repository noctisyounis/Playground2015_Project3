using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class ItemManager : MonoBehaviour
{
    #region PublicVariable
    public List<Item> Models
    {
        get
        {
            return m_itemModels;
        }
    }

    public string m_pathJSon = @"/Resources/StreamingAssets/Items.json";
    #endregion

    #region MainMethods

    
    void Start()
    {
        InitialiseModels();
    }

    private void InitialiseModels()
    {
        // Initialise the list of the model's item
        m_itemModels = new List<Item>();
        string readAllTxt = File.ReadAllText(Application.dataPath + m_pathJSon);
        m_itemJSData = JsonMapper.ToObject(readAllTxt);

        //Getting the models in the file JSON
        m_itemModels.AddRange(ItemsToFileJSon(m_itemJSData));
    }

    public Item SearchById(int id)
    {
        Item itemToSearched = null;
        int lengthModels = Models.Count;

        for (int i = 0; i < lengthModels; i++)
        {
            if (Models[i].Id == id)
            {
                itemToSearched = Models[i];
                break;
            }
        }

        return itemToSearched;
    }
    #endregion

    #region Utils
    private List<Item> ItemsToFileJSon(JsonData sourceData)
    {
        int LengthData = sourceData.Count;
        List<Item> itemsToGetted = new List<Item>();

        for (int i = 0; i < LengthData; i++)
        {
            Item itemGettedTmp = new Item()
            {
                Id = (int)sourceData[i]["Id"],
                Name = sourceData[i]["Name"].ToString(),
                Description = sourceData[i]["Description"].ToString(),
                Intensity = (int)sourceData[i]["Intensity"],
                TypeItem = (e_itemType)((int)sourceData[i]["Type"]),
                ElementTarget = (e_element)((int)sourceData[i]["Element"]),
                LevelRarity = (e_itemRarity)((int)sourceData[i]["Rarity"]),
                IsStackable = (bool)sourceData[i]["Stackable"],
                Sprite = Item.AssignResources(sourceData[i]["Sprite"].ToString())
            }; 

            itemsToGetted.Add(itemGettedTmp);
        }

        return itemsToGetted;
    }
    #endregion

    #region PrivateProtectedVariable
    private List<Item> m_itemModels;
    private JsonData m_itemJSData;
    #endregion
}
