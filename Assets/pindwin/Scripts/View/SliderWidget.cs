using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace pindwin.Scripts.View
{
	public class SliderWidget : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private TMP_Text _sliderValue;

		public int Value => Mathf.RoundToInt(_slider.value);
		
		private void Awake()
		{
			_slider.onValueChanged.AddListener(OnSliderValueChanged);
		}

		private void OnSliderValueChanged(float value)
		{
			_sliderValue.text = Mathf.RoundToInt(value).ToString();
		}
	}
}