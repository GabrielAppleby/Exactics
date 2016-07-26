using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour {

	private LevelLoader levelLoaderInstance;

	public void init() {
		levelLoaderInstance = this;
	}

	public void toCharacterScene() {
		SceneManager.LoadScene ("CharacterSelect", LoadSceneMode.Single);
	}

	public void toStartMenu() {
		SceneManager.LoadScene ("Start Menu", LoadSceneMode.Single);
	}
}
