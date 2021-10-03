using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager = null;
    [SerializeField]
    private Text soldierNameText = null;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text amountText = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Image purchaseButton2 = null; //금액이 안맞을때 작동안될려고
    [SerializeField]
    private Image soldierImage = null;
    [SerializeField]
    private Sprite[] soldierSprite = null;
    [SerializeField]
    private Sprite[] musicButton = null;
    int numlist = 2;
    [SerializeField]
    private MusicManger musicManger = null;
    [SerializeField] private bool isText;
    [SerializeField] private HoloGif holoGif = null;
    [SerializeField]
    private GameObject[] holoGifs = null;

    bool play = true;

    private Soldier soldier = null;
    public void SetValue(Soldier soldier) //솔져는 컴포넌트가 아닌 클래스 컴포넌트는 MonoBehavior를 상속받아야만 그거다.
    {

        this.soldier = soldier; //이거
        UpdateUI();
        PBD();
        HoloBuy();
    }

        public void UpdateUI()
    {
        soldierNameText.text = soldier.soldierName;
        priceText.text = string.Format("$ {0}", soldier.price);
        amountText.text = string.Format("LV {0}", soldier.amount); //개수
        soldierImage.sprite = soldierSprite[soldier.soldierNumber];
        purchaseButton2.sprite = musicButton[soldier.soldierNumber];
    }

    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.energy < soldier.price)  //현재에너지
        {
            return;
        }
        //holoGif.SetAct(soldier.soldierNumber);
        soldier.isHoloBuy = true;
        holoGif.SetAct(soldier.soldierNumber);
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        soldier.price = (long)(soldier.price * 1.25f);
        soldier.amount++;
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
        
    }

    public void OnClickPurchaseEPC()//클릭당 돈 을 soldier 의 EPS 만큼 올림
    {
        if (GameManager.Instance.CurrentUser.energy < soldier.price)  //현재에너지
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        if(soldier.isepcUp)
        {
        GameManager.Instance.CurrentUser.ePc += soldier.ePs;
        }
        soldier.price = (long)(soldier.price * 1.25f);
        soldier.amount++;
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }
    public void OnClickPurchaseEPS()//클릭당 돈 을 soldier 의 EPS 만큼 올림
    {
        if (GameManager.Instance.CurrentUser.energy < soldier.price)  //현재에너지
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        if (soldier.isepcUp)
        {
            GameManager.Instance.CurrentUser.ePc += soldier.ePs; ;//soldier.ePs;
        }
        soldier.price = (long)(soldier.price * 1.25f);
        soldier.amount++;
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }
    public void OnClickPurchaseItem()
    {

        if (GameManager.Instance.CurrentUser.energy < soldier.price)  //현재에너지
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        GameManager.Instance.CurrentUser.plusPercent += soldier.ePs;
        soldier.isBuy = true;
        soldier.amount++;
        purchaseButton.gameObject.SetActive(false);
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }

    public void OnClickPurchaseMusic()
    {
        if (soldier.soldierNumber == 0)
        {
            musicManger.Back();
        }
        if (soldier.soldierNumber == 1)
        {
            if(play == false)
            {
                musicManger.Play();
                play = true;
                purchaseButton2.sprite = musicButton[1];
            }
            else
            {
                musicManger.Pause();
                play = false;
                purchaseButton2.sprite = musicButton[3];
            }
        }
        if (soldier.soldierNumber == 2)
        {
            musicManger.Next();
        }
    }

    public void OnClickPurchaseGame()
    {

        if (GameManager.Instance.CurrentUser.energy < soldier.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        GameManager.Instance.CurrentUser.ePsPlusPercent += soldier.ePs;
        soldier.isBuy = true;
        soldier.amount++;
        purchaseButton.gameObject.SetActive(false);
        UpdateUI();
        GameManager.Instance.UI.UpdateEnergyPanel();
    }

    public void OnClickPurchaseOption()
    {

        if (soldier.soldierNumber == 0)
        {
            gameManager.OptionSave();
        }
        if (soldier.soldierNumber == 1)
        {
            Application.Quit();
        }
        if (soldier.soldierNumber == 2)
        {
            GameManager.Instance.CurrentUser.energy += 100000000000;
        }

    }

    public void HoloBuy()
    {
        if(soldier.isHoloBuy == true)
        {
            holoGifs[soldier.soldierNumber].SetActive(true);
        }
    }

    public void PBD()
    {
        if(soldier.isBuy == true)
        {
            purchaseButton.gameObject.SetActive(false);
        }
    }

}