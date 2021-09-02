using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text energyText = null;
    [SerializeField]
    private Animator beakerAnimator = null;
    [SerializeField]
    private GameObject upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanels = new List<UpgradePanel>();

    private void Start()
    {
        UpdateEnergyPanel();
        CreatePanels();
    }

    private void CreatePanels()
    {
        GameObject newPanel = null;
        UpgradePanel newPanelComponent = null;
        foreach(Soldier soldier in GameManager.Instance.CurrentUser.soldiersList)
        {
            newPanel = Instantiate(upgradePanelTemplate, upgradePanelTemplate.transform.parent);
            newPanelComponent = newPanel.GetComponent<UpgradePanel>();
            newPanelComponent.SetValue(soldier);
            newPanel.SetActive(true);
            upgradePanels.Add(newPanelComponent);
        }
    }

    public void OncliCkBeaker()
    {
        GameManager.Instance.CurrentUser.energy += GameManager.Instance.CurrentUser.ePc;
        UpdateEnergyPanel();
        beakerAnimator.Play("Click");
    }

    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("{0} ¿¡³ÊÁö", GameManager.Instance.CurrentUser.energy);
    }
}
