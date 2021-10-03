using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    [SerializeField] private Text curText;
    [SerializeField] private MusicManger musicManger;
    string[] musicList = { "2:23 AM" ,"10℃","You and Me","サンタは中央線でやってくる",
        "夢の中","悩む昼ごはん","極東の羊、テレキャスターと踊る"};
    private void Update()
    {
        curText.text = string.Format("{0}", musicList[musicManger.i]);
    }
}
