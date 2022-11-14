using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] int nextScene = 0;
    public void ChargeNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
