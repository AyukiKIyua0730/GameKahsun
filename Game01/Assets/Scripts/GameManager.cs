/*
 * シーン遷移を処理するスクリプト
 * シーンマネージャー
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }




    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
