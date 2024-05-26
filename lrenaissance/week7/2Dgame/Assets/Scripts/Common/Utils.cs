using UnityEngine.SceneManagement;

public enum SceneNames { Intro = 0, SelectLevel, Game, }
public static class Utils
{
    public static string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;//현재 scene 이름 반환
    }

    public static void LoadScene(string sceneName = "")
    {
        if (sceneName == "")
        {
            SceneManager.LoadScene(GetActiveScene());//현재 scene 로드
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void LoadScene(SceneNames sceneName)
    {
        //SceneNames 열거형으로 매개변수를 받아온 경우 ToString() 처리
        SceneManager.LoadScene(sceneName.ToString());
    }
}
