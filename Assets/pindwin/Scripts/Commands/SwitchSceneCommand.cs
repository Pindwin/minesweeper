using pindwin.umvr.Command;
using UnityEngine.SceneManagement;

namespace pindwin.Scripts.Commands
{
	public class SwitchSceneCommand : ConditionalCommand<string>
	{
		public override bool CanExecute()
		{
			return true;
		}

		protected override void ExecuteImpl(string param)
		{
			SceneManager.LoadScene(param);
		}

		public override bool IsValid(string payload)
		{
			return SceneManager.GetSceneByName(payload).IsValid();
		}
	}
}