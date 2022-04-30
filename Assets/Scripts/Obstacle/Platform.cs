#region

using UnityEngine;

#endregion

public class Platform : MonoBehaviour {

    [SerializeField] private GameObject _firstPos;
    [SerializeField] private GameObject _secondPos;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _onDelay = false;
    private bool _reverse = false;
    private float _time;
    private Vector3 position = new Vector3();


    void FixedUpdate() {
        if (_onDelay) {
            if (_time >= _delay) {
                _onDelay = false;
            } else if (_time < _delay) {
                _time += Time.deltaTime;
                return;
            }
        }

        MovePlatform();
    }

    private void MovePlatform() {
        if (!_reverse) {
            CalculateNextPosition(_firstPos.transform.position);
        } else {
            CalculateNextPosition(_secondPos.transform.position);
        }
        
        _rigidbody.MovePosition(position);
    }

    /// <summary>
    /// ¬ысчитываем положение в следующем кадре, если целева€ позици€ достигнута активируем задержку
    /// </summary>
    /// <param name="target"></param>
    private void CalculateNextPosition(Vector3 target) {
        if (transform.position != target) {
            position =
                Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }else {
            _onDelay = true;
            _time = 0;
            _reverse = !_reverse;
        }
    }
}

