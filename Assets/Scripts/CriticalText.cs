using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CriticalText : EnergyText
{
    public override void Show(Vector2 mousePosition, int dam)
    {
        long longplus = GameManager.Instance.CurrentUser.plusPercent;
        float floatplus = longplus;
        floatplus = (100 + floatplus) * 0.01f;

        float floatdam = 2 + (0.02f * dam);

        enrgyText = GetComponent<Text>();
        randomUser = Random.Range(0, doneName.Length);
        enrgyText.text = string.Format(doneName[randomUser] + "님이 {0}$ 후원!", GameManager.Instance.CurrentUser.ePc * floatdam * floatplus);

        transform.SetParent(Canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        gameObject.SetActive(true);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 50f;

        enrgyText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }
}
