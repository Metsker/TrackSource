using System.Collections.Generic;
using _Scripts.Environment;
using UnityEngine;

namespace _Scripts.GameFlow
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> stateDependantScripts;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform startPos;
    
        private Rigidbody _playerRb;
        public static float gameStartTime { get; private set; }

        private void Awake()
        {
            _playerRb = player.GetComponent<Rigidbody>();
        
            var position = startPos.position;
            startPos.position = new Vector3(position.x, player.transform.position.y, position.z);
        }

        private void OnEnable()
        {
            GameCompleteCollider.CompleteGame += OnGameComplete;
        }

        private void OnDisable()
        {
            GameCompleteCollider.CompleteGame -= OnGameComplete;
        }

        public void OnGameStart()
        {
            player.transform.position = startPos.position;

            gameStartTime = Time.time;
        
            foreach (var s in stateDependantScripts)
            {
                s.enabled = true;
            }
        }
        public void OnGameComplete(ResultManager.Result _)
        {
            foreach (var s in stateDependantScripts)
            {
                s.enabled = false;
            }
        }
    }
}
