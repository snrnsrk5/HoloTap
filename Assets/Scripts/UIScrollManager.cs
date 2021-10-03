using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemList = null;

    [SerializeField]
    private GameObject[] aniList = null;

    public void ViewGura()
    {
        aniList[0].SetActive(true);
        aniList[1].SetActive(false);
        aniList[2].SetActive(false);
        aniList[3].SetActive(false);
        aniList[4].SetActive(false);
        aniList[5].SetActive(false);

        itemList[0].SetActive(true);
        itemList[1].SetActive(false);
        itemList[2].SetActive(false);
        itemList[3].SetActive(false);
        itemList[4].SetActive(false);
        itemList[5].SetActive(false);
    }

    public void ViewHolo()
    {
        aniList[0].SetActive(false);
        aniList[1].SetActive(true);
        aniList[2].SetActive(false);
        aniList[3].SetActive(false);
        aniList[4].SetActive(false);
        aniList[5].SetActive(false);

        itemList[0].SetActive(false);
        itemList[1].SetActive(true);
        itemList[2].SetActive(false);
        itemList[3].SetActive(false);
        itemList[4].SetActive(false);
        itemList[5].SetActive(false);
    }

    public void ViewItem()
    {
        aniList[0].SetActive(false);
        aniList[1].SetActive(false);
        aniList[2].SetActive(true);
        aniList[3].SetActive(false);
        aniList[4].SetActive(false);
        aniList[5].SetActive(false);

        itemList[0].SetActive(false);
        itemList[1].SetActive(false);
        itemList[2].SetActive(true);
        itemList[3].SetActive(false);
        itemList[4].SetActive(false);
        itemList[5].SetActive(false);
    }

    public void ViewMusic()
    {
        aniList[0].SetActive(false);
        aniList[1].SetActive(false);
        aniList[2].SetActive(false);
        aniList[3].SetActive(true);
        aniList[4].SetActive(false);
        aniList[5].SetActive(false);

        itemList[0].SetActive(false);
        itemList[1].SetActive(false);
        itemList[2].SetActive(false);
        itemList[3].SetActive(true);
        itemList[4].SetActive(false);
        itemList[5].SetActive(false);
    }

    public void ViewGame()
    {
        aniList[0].SetActive(false);
        aniList[1].SetActive(false);
        aniList[2].SetActive(false);
        aniList[3].SetActive(false);
        aniList[4].SetActive(true);
        aniList[5].SetActive(false);

        itemList[0].SetActive(false);
        itemList[1].SetActive(false);
        itemList[2].SetActive(false);
        itemList[3].SetActive(false);
        itemList[4].SetActive(true);
        itemList[5].SetActive(false);
    }

    public void ViewOption()
    {
        aniList[0].SetActive(false);
        aniList[1].SetActive(false);
        aniList[2].SetActive(false);
        aniList[3].SetActive(false);
        aniList[4].SetActive(false);
        aniList[5].SetActive(true);

        itemList[0].SetActive(false);
        itemList[1].SetActive(false);
        itemList[2].SetActive(false);
        itemList[3].SetActive(false);
        itemList[4].SetActive(false);
        itemList[5].SetActive(true);
    }
}