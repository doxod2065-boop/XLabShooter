using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image m_loading;

    private string _nameScene;
    private static Loading m_instance;

    private void Awake()
    {
        if (m_instance is not null)
        {

            if (m_instance.GetEntityId() == GetEntityId())
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
            DontDestroyOnLoad(this);
            gameObject.SetActive(false);

            ServiceLocator.Register(this);
        }
    }
    public void LoadScene(string nameScene)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadSceneAsync(nameScene));
    }

    private IEnumerator LoadSceneAsync(string nameScene)
    {
        m_loading.fillAmount = 0;

        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        yield return operation;

        m_loading.fillAmount = 0;

        const int steps = 10;
        var delta += 1 - m_loading.fillAmount;

        for (var i = 0; 1 < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            m_loading.fillAmount += delta / steps;
        }

        gameObject.SetActive(false);
    }
}
