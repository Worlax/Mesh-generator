using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
#pragma warning disable 0649

	[SerializeField] int minValue;
	[SerializeField] int maxValue;
	[SerializeField] Slider slider;
	[SerializeField] Text output;

#pragma warning restore 0649

	// Events
	private void SliderValueChanged(float value)
	{
		output.text = ((int)value).ToString();
	}

	// Unity
	private void Start()
	{
		slider.minValue = minValue;
		slider.maxValue = maxValue;
		slider.value = ((maxValue - minValue) / 2) + minValue;
		SliderValueChanged(slider.value);

		slider.onValueChanged.AddListener(SliderValueChanged);
	}
}