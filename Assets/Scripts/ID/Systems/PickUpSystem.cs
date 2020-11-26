using System;
using Sirenix.OdinInspector;

namespace ID.Systems
{
    [Serializable]
    public class PickUpSystem
    {
        [ShowInInspector] public int points;

        public static event Action<int> OnPickUp;

        public void AddPoints(int value)
        {
            points += value;
            OnPickUp?.Invoke(points);
        }

        public void Reset()
        {
            points = 0;
        }
    }
}