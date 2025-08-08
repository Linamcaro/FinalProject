using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Sombra, Fondo, flecha, fantasma;

    private Image FondoFade, FlechaFade;
    private RectTransform shadowRectTransform, TextRect;
    private Transform shadowTransform;
    private Vector2 sombraPosInicial;
    public Transform GhostInicial;
    private Transform GhostPos;
    public Transform GhostObjective;
    private Transform textoTransform;
    public Animator WallLeft, WallRight;

    private Vector2 textoPosInicial;
    private Vector3 GhostInitPoint;

    private void Start()
    {
        shadowRectTransform = Sombra.GetComponent<RectTransform>();
        shadowTransform = Sombra.GetComponent<Transform>();
        sombraPosInicial = shadowRectTransform.anchoredPosition;
        TextRect = GetComponent<RectTransform>();
        GhostPos = fantasma.GetComponent<Transform>();
        GhostInitPoint = GhostInicial.position;


        textoTransform = GetComponent<Transform>();
        textoPosInicial = textoTransform.position;

        FondoFade = Fondo.GetComponent<Image>();
        //  FlechaFade = flecha.GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        shadowTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).SetEase(Ease.InOutSine);
        shadowRectTransform.DOAnchorPosX(sombraPosInicial.x + 10f, 0.1f).SetEase(Ease.InOutSine);
        shadowRectTransform.DOAnchorPosY(sombraPosInicial.y - 10f, 0.1f).SetEase(Ease.InOutSine);
        GhostPos.DOMove(GhostObjective.position, 0.2f).SetEase(Ease.InOutSine);

        FondoFade.DOFade(0.3f, 0.1f).SetEase(Ease.InOutSine);
        // FlechaFade.DOFade(1, 0.1f).SetEase(Ease.InOutSine); 
        textoTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).SetEase(Ease.InOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        shadowTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutSine);
        shadowRectTransform.DOAnchorPos(sombraPosInicial, 0.1f).SetEase(Ease.InOutSine);
        FondoFade.DOFade(0, 0.1f).SetEase(Ease.InOutSine);
        GhostPos.DOMove(GhostInitPoint, 0.2f).SetEase(Ease.InOutSine);
        // FlechaFade.DOFade(0, 0.1f).SetEase(Ease.InOutSine);

        textoTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutSine);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TextRect.DOAnchorPosX(sombraPosInicial.x + 10f, 0.1f).SetEase(Ease.InOutSine);
        TextRect.DOAnchorPosY(sombraPosInicial.y - 10f, 0.1f).SetEase(Ease.InOutSine);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TextRect.DOAnchorPos(sombraPosInicial, 0.1f).SetEase(Ease.InOutSine);
    }

    public void Play()
    {
        StartCoroutine(PlayScene());
    }

    public IEnumerator PlayScene()
    {
        yield return new WaitForSeconds(0.4f);
        WallLeft.Play("WallLeftIn");
        WallRight.Play("WallRightIn");
        yield return new WaitForSeconds(1);
        GameManager.Instance.SetGameState(GameManager.GameState.waitingToStart);
        SceneManager.LoadScene("MainGameScene");
    }
}