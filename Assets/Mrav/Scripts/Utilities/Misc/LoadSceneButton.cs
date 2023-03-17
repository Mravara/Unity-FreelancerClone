using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
	public string NewSceneName;

	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		SceneManager.LoadScene(NewSceneName);
	}
}
