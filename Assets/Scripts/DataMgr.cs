using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;

public class DataMgr : MonoBehaviour
{
    [SerializeField] ItemData[] itemDatas;

    private static DataMgr instance;
    public static DataMgr Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        /*PlayerPrefs.SetInt("gold", 100);
        PlayerPrefs.SetString("item0", "true");
        PlayerPrefs.SetString("item1", "false");
        Debug.Log("저장완료");*/
        /*
                int _gold = PlayerPrefs.GetInt("gold", 0);
                string _item0 = PlayerPrefs.GetString("item0", "false");
                string _item1 = PlayerPrefs.GetString("item1", "false");

                Debug.Log("gold:" + _gold);
                Debug.Log("item0:" + _item0);
                Debug.Log("item1:" + _item1);
        */
        TextAsset tAsset = Resources.Load<TextAsset>("JSON/weapon");
        JSONObject jObj = JSONObject.Parse(tAsset.text);

        /*Debug.Log(jObj["weapon"]);
        Debug.Log(jObj.GetArray("weapon"));*/

        /*JSONArray jArr1 = jObj.GetArray("weapon");
        JSONArray jArr2 = JSONArray.Parse(jObj["weapon"].ToString());*/
        JSONArray jArr3 = jObj["weapon"].Array;

        itemDatas = new ItemData[jArr3.Length];

        for(int i=0;i<jArr3.Length; i++)
        {
            itemDatas[i] = new ItemData();

            itemDatas[i].key = jArr3[i].Obj.GetString("key");
            itemDatas[i].name = jArr3[i].Obj.GetString("name");
            itemDatas[i].info = jArr3[i].Obj.GetString("info");
            itemDatas[i].price = int.Parse(jArr3[i].Obj.GetString("price"));
            itemDatas[i].damage = float.Parse(jArr3[i].Obj.GetString("damage"));
            itemDatas[i].bulletCount = int.Parse(jArr3[i].Obj.GetString("bulletCount"));
            itemDatas[i].reloadingSec = float.Parse(jArr3[i].Obj.GetString("reloadingSec"));
        }
    }

    public ItemData GetItemData(string key)
    {
        for (int i = 0; i < itemDatas.Length; i++)
        {
            if(itemDatas[i] != null)
            return itemDatas[i];
        }

        return null;
    }

}
