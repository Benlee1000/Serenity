using UnityEngine.SceneManagement;

public static class Loader
{
    private static int currentScene = 0;

    // Name of scenes
    public enum Scene {
        StartScreen,
        DialogueScreen,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
    }

    // Loads the scene based on the stringified enum value.
    public static void Load(Scene scene)
    {
        currentScene = (int)scene;
        SceneManager.LoadScene(scene.ToString());
    }

    public static int GetCurrentScene()
    {
        return currentScene;
    }
}
