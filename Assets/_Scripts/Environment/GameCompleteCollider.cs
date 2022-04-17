using System;
using _Scripts.Player;
using UnityEngine;
using static _Scripts.GameFlow.ResultManager;

namespace _Scripts.Environment
{
    public class GameCompleteCollider : MonoBehaviour
    {
        [SerializeField] private Result result;

        public static event Action<Result> CompleteGame;

        private void OnTriggerEnter(Collider other)
        {
            print("S");
            if (other.TryGetComponent(out PlayerMovementController _))
            {
                CompleteGame?.Invoke(result);
            }
        }
    }
}
