using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour
    {
        private InputMaster _uiInput;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _uiInput = new InputMaster();

            _uiInput.UI.GotoMenu.performed += _ => _button.onClick.Invoke();
        }

        private void OnEnable()
        {
            _uiInput.Enable();
        }
        private void OnDisable()
        {
            _uiInput.Disable();
        }
    }
}
