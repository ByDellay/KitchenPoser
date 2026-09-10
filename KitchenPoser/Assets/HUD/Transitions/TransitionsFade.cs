using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionsFade : MonoBehaviour
{
    public static TransitionsFade Instance;
    int FadeTime = 1;
    public Animator CrossFade;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public IEnumerator LoadNewScene(string Scene)
    {
        CrossFade.SetTrigger("Start");
        
        yield return new WaitForSeconds(FadeTime);

        SceneManager.LoadScene(Scene);
    }
}
