using UnityEngine.SceneManagement;

public static class Loader
{
    // Name of scenes
    public enum Scene {
        StartScreen,
        MainGame,
        DialogueScreen,
    }

    // Loads the scene based on the stringified enum value.
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}