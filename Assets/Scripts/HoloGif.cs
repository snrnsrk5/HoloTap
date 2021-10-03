using UnityEngine;

public class HoloGif : MonoBehaviour
{
    [SerializeField]
    private GameObject[] holoGif = null;
    [SerializeField] private UpgradePanel upgradePanel = null;

    public void SetAct(int a)
    {
        holoGif[a].SetActive(true);
    }
}
