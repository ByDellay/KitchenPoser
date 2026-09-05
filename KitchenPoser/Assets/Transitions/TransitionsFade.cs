using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionsFade : MonoBehaviour
{
    int FadeTime = 1;
    public Animator CrossFade;

    public IEnumerator LoadNewScene(string Scene)
    {
        CrossFade.SetTrigger("Start");
        
        yield return new WaitForSeconds(FadeTime);

        SceneManager.LoadScene(Scene);
    }
}
