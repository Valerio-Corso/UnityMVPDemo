using TMPro;
using UnityEngine;

namespace Demo.Scripts.ViewFactoryDemo
{
	public class CircleView : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI _text;
		public string Text { set => _text.text = value; }
	}
}