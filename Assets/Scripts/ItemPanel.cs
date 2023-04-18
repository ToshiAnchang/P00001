using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemPanel : MonoBehaviour
{
    [SerializeField] Image itemImg;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text infoText;

    [SerializeField] Button purchaseBtn;
    [SerializeField] TMP_Text priceText;

    [SerializeField] GameObject purchasedPanelObj;



    public void Start()
    {
        //purchaseBtn = GetComponentInChildren<Button>(); // null 인 이유??? - ItemPanel이 false 상태여서
        purchaseBtn.onClick.AddListener(OnClickedPurchase);
    }

    public void Awake()
    {
        
    }

    ItemData itemData;
    public void SetItemData(ItemData _iData)
    {
        itemData = _iData;

        itemImg.sprite = _iData.sprite;
        nameText.text = _iData.name;
        infoText.text = _iData.info;

        priceText.text = _iData.price.ToString();

        //플레이어가 해당 아이템 가지고 있는지 확인하는 코드 추가

        PlayerItem _pItem = Player.Instance.GetPlayerItem(_iData.key);

        if (purchaseBtn != null)
        {
            purchaseBtn.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("purchaseBtn is not found.");
        }


        if (_pItem.own) //무기 보유
        {
            purchasedPanelObj.SetActive(true);
            purchaseBtn.gameObject.SetActive(false);
        }
        else
        {
            purchasedPanelObj.SetActive(false);
            purchaseBtn.gameObject.SetActive(true);
        }
    }

    public void OnClickedPurchase()
    {
        
        if (Player.Instance.GetWealth(WealthType.gold) < itemData.price)
            return;
        Player.Instance.AddPlayerItem(itemData.key);
        Player.Instance.AddWealth(WealthType.gold, -itemData.price);

        ShopMgr.Instance.UpdateShop();
    }

}

[System.Serializable]
public class ItemData
{
    public Sprite sprite;
    public string key;
    public string name;
    public string info;
    public int price;
    public float damage;
    public int bulletCount;
    public float reloadingSec;
}