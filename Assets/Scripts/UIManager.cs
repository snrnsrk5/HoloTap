using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource done = null;
    [SerializeField]
    private Text energyText = null;
    [SerializeField]
    private Animator beakerAnimator = null;
    [SerializeField]
    private Animator beakerAnimator2 = null;
    [SerializeField]
    private Animator beakerAnimator3 = null;
    [SerializeField]
    private Animator beakerAnimator4 = null;
    [SerializeField]
    private Animator beakerAnimator5 = null;
    [SerializeField]
    private Animator beakerAnimator6 = null;

    [SerializeField]
    private GameObject upgradePanelTemplate = null;
    [SerializeField]
    private GameObject upgradePanelTemplate2 = null;
    [SerializeField]
    private GameObject upgradePanelTemplate3 = null;
    [SerializeField]
    private GameObject upgradePanelTemplate4 = null;
    [SerializeField]
    private GameObject upgradePanelTemplate5 = null;
    [SerializeField]
    private GameObject upgradePanelTemplate6 = null;
    [SerializeField]
    private EnergyText energyTextTemplate = null;
    [SerializeField]
    private EnergyText energyTextTemplate_Critical = null;
    [SerializeField]
    private Transform[] pool = null;

    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();

    private void Start()
    {
        UpdateEnergyPanel();
        CreatePanels();
    }
    private void CreatePanels()
    {
        //GameObject newPanel = null;
        //UpgradePanel newPanelComponent = null;

        Aaa(GameManager.Instance.CurrentUser.soldiersList, upgradePanelTemplate);
        Aaa(GameManager.Instance.CurrentUser.soldiersList2, upgradePanelTemplate2);
        Aaa(GameManager.Instance.CurrentUser.soldiersList3, upgradePanelTemplate3);
        Aaa(GameManager.Instance.CurrentUser.soldiersList4, upgradePanelTemplate4);
        Aaa(GameManager.Instance.CurrentUser.soldiersList5, upgradePanelTemplate5);
        Aaa(GameManager.Instance.CurrentUser.soldiersList6, upgradePanelTemplate6);
    }
    private void Aaa(List<Soldier> list, GameObject panel)
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;
        foreach (Soldier soldier in list)
        {
            newPanel = Instantiate(panel, panel.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(soldier);
            newPanel.SetActive(true);
            upgradePanels.Add(newPanelComponent);
        }
    }

    public void OncliCkBeaker(int per, int dam)
    {
        float ePc = GameManager.Instance.CurrentUser.ePc;
        float fdam = 2 + (0.02f * dam);
        float eP = (100 + GameManager.Instance.CurrentUser.plusPercent) * 0.01f;
        long hdePc = (long)Mathf.Round(ePc * fdam * eP);
        long hePc = (long)Mathf.Round(ePc * eP);

        int a = Random.Range(0, 1001);
        if (a-(per+5) <= 0)
        {
            done.Play();

            GameManager.Instance.CurrentUser.energy += hdePc;
            EnergyText newText = null;

            if (pool[1].childCount > 0)
            {
                newText = pool[1].GetChild(0).GetComponent<EnergyText>();
            }
            else
            {
                newText = Instantiate(energyTextTemplate_Critical, energyTextTemplate_Critical.transform.parent);
            }

            newText.Show(Input.mousePosition, dam);
        }
        else
        {
            GameManager.Instance.CurrentUser.energy += hePc;
            EnergyText newText = null;

            if (pool[0].childCount > 0)
            {
                newText = pool[0].GetChild(0).GetComponent<EnergyText>();
            }
            else
            {
                newText = Instantiate(energyTextTemplate, energyTextTemplate.transform.parent);
            }

            newText.Show(Input.mousePosition, dam);
        }
        UpdateEnergyPanel();
        beakerAnimator.Play("Click");
        beakerAnimator2.Play("Click");
        beakerAnimator3.Play("Click");
        beakerAnimator4.Play("Click");
        beakerAnimator5.Play("Click");
        beakerAnimator6.Play("Click");
    }

    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("$ {0}", GameManager.Instance.CurrentUser.energy);
    }
}