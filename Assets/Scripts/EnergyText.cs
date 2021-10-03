using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnergyText : MonoBehaviour
{   
    [SerializeField]
    protected Canvas Canvas = null;
    [SerializeField]
    protected Transform pool;

    protected Text enrgyText = null;

    protected string[] doneName = { "동탄고의전설","dumbass","groundpound","Y","애잔한애잔오","llliiilil","리때영","sakura","snrnsrk5","sssss",
        "ann","A","ciko","ako","kri","on","ayana","parapara","oooooh","zh9","James Oliver","ChunPo","MrAlexZz","Genta Genata","kukutttto",
        "Auto2","Brent James Caravana","Noi","MochaJm","Felix - KFP","Johnathon","H1t0r1","조현우","マメ・キャプテンアメリカ","Quib","ajsdklsad",
        "Zetarn Dezano","AimanSolork","Neighton","Caravana","Dark Flash","1+1","Auto2D","Moon Scented Hunter","129das","Humdinger","sas",
        "cheif","Johnomicon","TinyBeast","IronOnion","Noah Vollmer","Starcruiser","Spiderman","AKAsubtor","Kaboshi Reacts 2.0","DizNutz",
        "Khyree Rusydi","M.R. SMN","Eidespere","NUZIX CH","Migu","el amine","Zephyr W","현타온 시바견","Themadpotato","タスク・ボンバー","sfdko",
        "タスク・ボンバー","【雪花の狼】くーにゃ","1반짱김동윤이에용","ゆたんぽ","薬屋223[雪民]","べいりん","月下美人","Heroic Clover","アストワール十 反逆の暗黒騎士アスト 十",
        "サノ","漆黒の天使 エル","竜騎士まぐなす[雪民]","riryu【雪民】","凪リン『叩き割った小人』【雪民】【LNo.35】","はとおじさん","くろまめ","RIA【りあ】","LegendAss",
        "Otaku","DarkDragonMaster","Karino","성은니","ShibaTeacher","HeadhunterEgg","Sexy재엽","ahoy!","zzzz","zotgatne",
        "amelove","guralove","gggggura","shake","779848","1235","개쉐기야","4913544","1200005","05dldl","edsfedf","matoam","amee","oraror","oraoraora",
        "ㅋㅋㅋ","wwwwwwwwwww","우효요요요요욧","끼요요요욧","rlasdk","rankbnozze","aaame","gggguar","<>","***","inginging","opoppo","일짱zi존간zi민영ㅋ"
    };


    protected int randomUser = 0;
    public virtual void Show(Vector2 mousePosition, int dam)
    {
        long longplus = GameManager.Instance.CurrentUser.plusPercent;
        float floatplus = longplus;
        floatplus = (100 + floatplus) * 0.01f;
        int intplus = (int)Mathf.Round(floatplus);

        enrgyText = GetComponent<Text>();
        randomUser = Random.Range(0, doneName.Length);
        enrgyText.text = string.Format(doneName[randomUser] + "님이 {0}$ 후원!", GameManager.Instance.CurrentUser.ePc * floatplus);

        transform.SetParent(Canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        gameObject.SetActive(true);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 50f;

        enrgyText.DOFade(0f, 0.5f).OnComplete(()=> Despawn());
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }

    public void Despawn()
    {
        enrgyText.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }
}
