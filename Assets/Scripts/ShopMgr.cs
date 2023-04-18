using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMgr : MonoBehaviour
{
    private static ShopMgr instance;
    public static ShopMgr Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] GameObject shopCanvasObj;

    public ItemData[] itemDatas;
    public ItemPanel[] itemPanels;
    [SerializeField] Button closeBtn;

    private void Start()
    {
        shopCanvasObj.SetActive(false);
        //closeBtn = shopCanvasObj.GetComponentInChildren<Button>();
        closeBtn.onClick.AddListener(CloseShop);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.Instance.AddWealth(WealthType.gold, 100); // 플레이어 골드 추가
            OpenShop(); //상점 열기
        }
    }

    public void UpdateShop()
    {
        for (int i = 0; i < itemPanels.Length; i++)
        {
            if (i >= itemDatas.Length) break;
            itemPanels[i].SetItemData(itemDatas[i]);
        }
    }


    public void OpenShop()
    {
        UpdateShop();
        shopCanvasObj.SetActive(true);
    }

    public void CloseShop()
    {
        shopCanvasObj.SetActive(false);
        UpdateShop();
    }


}