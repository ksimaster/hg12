using UnityEngine;

namespace Controllers
{
    public class HeadBobController : MonoBehaviour
    {
        [SerializeField] bool _enableStabilizing = true;
        [SerializeField][Range(0f, 1f)] float _amplitudeWalking = 0.15f;
        [SerializeField][Range(0f, 30f)] float _freqWalking = 10f;
        [SerializeField][Range(0f, 1f)] float _amplitudeRunning = 0.15f;
        [SerializeField][Range(0f, 30f)] float _freqRunning = 10f;
        [SerializeField] Transform _camera;
        [SerializeField] Transform _cameraHolder;

        float _timeCounter;
        Vector3 _startPos;


        private void Awake()
        {
            _startPos = _camera.localPosition;

        }
 

        public void WalkingHeadBob()
        {
            if (_enableStabilizing)
                _cameraHolder.LookAt(FocusTarget());
            _camera.localPosition += FootStepMotion(_amplitudeWalking, _freqWalking) * Time.deltaTime;

        }
        public void RunningHeadBob()
        {
            if (_enableStabilizing)
                _cameraHolder.LookAt(FocusTarget());
            _camera.localPosition += FootStepMotion(_amplitudeRunning, _freqRunning) * Time.deltaTime;
        }
        public void ResetPosition()
        {
            
            if (_camera.localPosition == _startPos) return;
            _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, Time.smoothDeltaTime*5f);
            
            
            if (Mathf.Abs(Vector3.Distance(_startPos, _camera.localPosition)) < 0.01f)
                _camera.localPosition = _startPos;
            _timeCounter = 0;
        }
        private Vector3 FocusTarget()
        {
            Vector3 pos = _cameraHolder.position;
            pos += _cameraHolder.forward * 15f;
            return pos;
        }

        private Vector3 FootStepMotion(float amplitude, float freq)
        {
            _timeCounter += Time.deltaTime;
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Sin(_timeCounter * freq) * amplitude;
            pos.x += Mathf.Cos(_timeCounter * freq / 2) * amplitude * (-1.5f);
            return pos;
        }
    }

}
