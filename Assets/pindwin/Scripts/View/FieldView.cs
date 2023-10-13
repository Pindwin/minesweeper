using pindwin.development;
using pindwin.umvr.Command;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace pindwin.Scripts.View
{
	public class FieldView : MonoBehaviour, IPointerClickHandler
	{
		[SerializeField] private TMP_Text _text;
		[SerializeField] private Image _frontImage;
		[SerializeField] private Image _backImage;
		
		[SerializeField] private Color _failColor;
		[SerializeField] private Color _neutralColor;

		private ICommand<Vector3Int> _reportClickCommand;

		[Inject]
		private void Inject(ICommand<Vector3Int> reportClickCommand)
		{
			_reportClickCommand = reportClickCommand.AssertNotNull();
		}
		
		public string Text
		{
			set => _text.text = value;
		}

		public bool IsHidden
		{
			set
			{
				_text.enabled = !value;
				_frontImage.enabled = value;
			}
		}

		public bool IsFailed
		{
			set => _backImage.color = value ? _failColor : _neutralColor;
		}

		public Vector3Int Payload { private get; set; }
		
		public void OnPointerClick(PointerEventData eventData)
		{
			_reportClickCommand.Execute(Payload);
		}

		public void Reset()
		{
			IsFailed = false;
			IsHidden = true;
		}
	}
}