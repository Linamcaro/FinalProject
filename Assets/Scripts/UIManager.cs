using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Texto1, Texto2, Texto3;
    public Image Panel;
    public TMP_Text Perdiste;
    public Button restart, volver;
    public Animator transition, transition2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BeginCount());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += ManejarCambioEstado;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= ManejarCambioEstado;
    }

    public IEnumerator BeginCount()
    {
        Texto1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Texto1.SetActive(false);
        Texto2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Texto2.SetActive(false);
        Texto3.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Texto3.SetActive(false);
        Panel.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SetGameState(GameManager.GameState.Playing);
    }

    private void ManejarCambioEstado(GameManager.GameState nuevoEstado)
    {
        if (nuevoEstado == GameManager.GameState.EndGame)
        {
            Panel.DOFade(1, 0.7f);
            Perdiste.DOFade(1, 1.5f);
            Perdiste.transform.DOScale(new Vector3(1, 1, 1), 3f).SetEase(Ease.OutBack);
            restart.transform.DOScale(new Vector3(1, 1, 1), 4f).SetEase(Ease.OutBack);
            volver.transform.DOScale(new Vector3(1, 1, 1), 4f).SetEase(Ease.OutBack);

        }
    }

    public void Reiniciar()
    {
        transition.Play("WallLeftIn");
        transition2.Play("WallRightIn");
        StartCoroutine(Restart());
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

    }

    public IEnumerator MenuBack()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenu()
    {
        transition.Play("WallLeftIn");
        transition2.Play("WallRightIn");
        StartCoroutine(MenuBack());
    }

}
