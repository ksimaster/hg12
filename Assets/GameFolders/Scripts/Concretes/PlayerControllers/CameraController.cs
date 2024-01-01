
using UnityEngine;
namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [Header("Sensitivity")]
        [SerializeField][Range(0f, 350f)] float _mouseXSensitivity;
        [SerializeField][Range(0f, 350f)] float _mouseYSensitivity;
        [Header("Vertical Clamp")]
        [SerializeField] float MinVerticalAngle;
        [SerializeField] float MaxVerticalAngle;
        bool _disableInput;

        float _yRotation;

        public void MouseSensitivityReturn()
        {
            _mouseXSensitivity = 130;
            _mouseYSensitivity = 120;
        }

        public void MouseSensitivityZero()
        {
            _mouseXSensitivity = 0;
            _mouseYSensitivity = 0;
        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameManager.Instance.OnGameOver += HandleOnGameOver;

        }
        private void HandleOnGameOver()
        {
            _disableInput= true;
        }
        private void LateUpdate()
        {
            if (_disableInput) return;
            float vertical = Input.GetAxis("Mouse Y") * _mouseYSensitivity * Time.fixedDeltaTime;
            float horizontal = Input.GetAxis("Mouse X") * _mouseXSensitivity * Time.fixedDeltaTime;

            _yRotation -= vertical;
            _yRotation = Mathf.Clamp(_yRotation, MinVerticalAngle, MaxVerticalAngle);

            transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
            _player.Rotate(Vector3.up * horizontal);
        }
    }
}

