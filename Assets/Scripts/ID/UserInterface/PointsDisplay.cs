using ID.Core;
using ID.Systems;
using TMPro;
using UnityEngine;

namespace ID.UserInterface
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PointsDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            PickUpSystem.OnPickUp += UpdatePointsDisplay;
            UpdatePointsDisplay(0);
        }

        private void OnDisable()
        {
            PickUpSystem.OnPickUp -= UpdatePointsDisplay;
        }

        void UpdatePointsDisplay(int points)
        {
            _textMeshPro.text = points.ToString();
        }
    } 
}

