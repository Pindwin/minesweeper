using pindwin.development;
using pindwin.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace pindwin.Scripts.View
{
	public class MainMenuView : MonoBehaviour
	{
		[SerializeField] private SliderWidget _widthWidget;
		[SerializeField] private SliderWidget _heightWidget;
		[SerializeField] private SliderWidget _bombsWidget;
		[SerializeField] private Button _startButton;
		[SerializeField] private Button _quitButton;

		private ApplicationSettings _applicationSettings;
		private SwitchSceneCommand _switchSceneCommand;
		
		[Inject]
		private void Inject(ApplicationSettings applicationSettings, SwitchSceneCommand switchSceneCommand)
		{
			_applicationSettings = applicationSettings.AssertNotNull();
			_switchSceneCommand = switchSceneCommand.AssertNotNull();
		}
		
		private void Awake()
		{
			_startButton.onClick.AddListener(OnStartButtonClicked);
			_quitButton.onClick.AddListener(OnQuitButtonClicked);
		}

		private void OnStartButtonClicked()
		{
			_applicationSettings.BoardSize = new Vector2Int(_widthWidget.Value, _heightWidget.Value);
			_applicationSettings.Mines = _bombsWidget.Value;
			_switchSceneCommand.Execute("GameScene");
		}

		private void OnQuitButtonClicked()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.ExitPlaymode();
			#else
			Application.Quit();
			#endif
		}
	}
}