using pindwin.development;
using pindwin.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace pindwin.Scripts.View
{
	public class GameSessionView : MonoBehaviour
	{
		[SerializeField] private Button _restartGameButton;
		[SerializeField] private Button _quitGameButton;

		private SwitchSceneCommand _switchSceneCommand;

		[Inject]
		private void Inject(SwitchSceneCommand switchSceneCommand)
		{
			_switchSceneCommand = switchSceneCommand.AssertNotNull();
		}
		
		private void Awake()
		{
			_restartGameButton.onClick.AddListener(OnRestartGameClicked);
			_quitGameButton.onClick.AddListener(OnQuitGameClicked);
		}

		private void OnRestartGameClicked()
		{
			_switchSceneCommand.Execute("GameScene");
		}
		
		private void OnQuitGameClicked()
		{
			_switchSceneCommand.Execute("MainMenuScene");
		}
	}
}