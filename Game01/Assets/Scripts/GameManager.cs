/*
 * �V�[���J�ڂ���������X�N���v�g
 * �V�[���}�l�[�W���[
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
