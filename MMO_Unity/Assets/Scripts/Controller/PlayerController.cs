using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        //Managers.Resource.instantiate("UI/UI_Button");
        //Managers.UI.ShowPopupUI<UI_Button>();
    }

    public enum PlayerState
    {
        Die = 0,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    //float wait_run_ratio = 0.0f;

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        // �̵�ó��
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            //if(moveDist >= dir.magnitude)
            //{
            //    moveDist = dir.magnitude; 
            //}

            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            //transform.LookAt(_destPos);
        }

        // �̵� �ִϸ��̼� ó��
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        // ���� ���� ���¿� ���� ������ �Ѱ��ش�
        anim.SetFloat("speed", _speed);


        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("RUN");
    }

    void UpdateIdle()
    {
        // idle �ִϸ��̼� ó��
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT");
    }

    void Update()
    {
        // �÷��̾��� ���¿� ���� ó��
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    //bool _moveToDest = false;
    Vector3 _destPos;
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if( _state == PlayerState.Die )
        {
            return; 
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        // ���̾�� �����ɽ��� ����ȭ
        int mask = LayerMask.GetMask("Wall");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            //Debug.Log($"Raycase Camera @ {hit.collider.gameObject.name}");
        }
    }
}

//    float _yAngle = 0.0f;
//    void OnKeyboard()
//    {
//        // ȸ������
//        _yAngle += Time.deltaTime * 100.0f;
//        // ȸ�� ���밪
//        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

//        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

//        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

//        // Local -> World
//        //transform.TransformDirection

//        // World -> Local
//        //transform.InverseTransformDirection

//        if (Input.GetKey(KeyCode.W))
//        {
//            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
//            // Translate : �ִ��� �ڱⰡ �ٶ󺸴� ������ �������� �������. �� �ڵ�� ���� ���
//            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);

//            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
//            transform.position += Vector3.forward * Time.deltaTime * _speed;
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            //transform.rotation = Quaternion.LookRotation(Vector3.back);
//            //transform.Translate(Vector3.back * Time.deltaTime * _speed);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
//            transform.position += Vector3.back * Time.deltaTime * _speed;
//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            //transform.rotation = Quaternion.LookRotation(Vector3.left);
//            //transform.Translate(Vector3.left * Time.deltaTime * _speed);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
//            transform.position += Vector3.left * Time.deltaTime * _speed;
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            //transform.rotation = Quaternion.LookRotation(Vector3.right);
//            //transform.Translate(Vector3.right * Time.deltaTime * _speed);
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
//            transform.position += Vector3.right * Time.deltaTime * _speed;
//        }

//        _moveToDest = false;
//    }
//}
