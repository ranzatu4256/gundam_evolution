using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Red_player: Agent {
    Rigidbody rb;
    float X = 180f;
    public GameObject Blue1;
    public GameObject Blue2;
    public GameObject Blue3;
    public GameObject Blue4;
    public GameObject Blue5;
    public GameObject Blue6;

    int lastCheckPoint; // 最終チェックポイント
    int checkPointCount; // チェックポイント通過数

    // 初期化時に呼ばれる
    public override void Initialize() {
        rb = GetComponent<Rigidbody>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(this.transform.localRotation);
    }

    // 行動実行時に呼ばれる
    public override void OnActionReceived(ActionBuffers actions) {
        Vector3 dirToGo = Vector3.zero;

        int action = actions.DiscreteActions[0];
        if (action == 1) dirToGo = transform.forward;
        if (action == 2) dirToGo = transform.forward * -1.0f;
        if (action == 3) X += 1.0f;
        if (action == 4) X -= 1.0f;
        if (action == 5) dirToGo = transform.right;
        if (action == 6) dirToGo = transform.right * -1.0f;
        this.rb.AddForce(dirToGo * 0.2f, ForceMode.VelocityChange);
    }

    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
 
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = X;
        worldAngle.y = 90.0f; // ワールド座標を基準に、y軸を軸にした回転を90度に変更
        worldAngle.z = 90.0f; // ワールド座標を基準に、z軸を軸にした回転を90度に変更
        myTransform.eulerAngles = worldAngle; // 回転角度を設定

        rb.velocity = Vector3.zero;

        Vector3 pos = myTransform.position;
        pos.z = 0.0f;
        myTransform.position = pos;

        Vector3 direction = transform.forward;
        Ray ray = new Ray(this.transform.localPosition, direction); // Rayを生成
        //Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 1.0f); // 長さ３０、赤色で５秒間可視化
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) // もしRayを投射して何らかのコライダーに衝突したら
        {
            if(hit.collider.CompareTag("Blue"))
            {
                string name = hit.collider.gameObject.name; // 衝突した相手オブジェクトの名前を取得
                if(name=="Blue1")
                    {
                        Blue1.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
                if(name=="Blue2")
                    {
                        Blue2.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
                if(name=="Blue3")
                    {
                        Blue3.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
                if(name=="Blue4")
                    {
                        Blue4.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
                if(name=="Blue5")
                    {
                        Blue5.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
                if(name=="Blue6")
                    {
                        Blue6.transform.localPosition = new Vector3(-34f, 0.0f, 0.0f);
                    }
            }
        }
    }

    // チェックポイントに衝突時に呼ばれる
    public void EnterCheckPoint(int checkPoint) {
        // 次のチェックポイントに衝突
        if (checkPoint == (lastCheckPoint + 1) % 12) {
            // チェックポイント毎の報酬
            AddReward(-1.0f);
            checkPointCount++;

            // ゴール
            if (checkPointCount >= 12) {
                // エピソード毎の報酬
                AddReward(-1.0f);
                EndEpisode();
            }
        }
        // 前のチェックポイントに衝突
        else {
            // チェックポイント毎の報酬
            AddReward(1.0f);
            checkPointCount--;
        }

        // 最終チェックポイントの更新
        lastCheckPoint = checkPoint;
    }

    // ヒューリスティックモードの行動決定時に呼ばれる
    public override void Heuristic(in ActionBuffers actionsOut) {
        var actions = actionsOut.DiscreteActions;
        actions[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow)) actions[0] = 1;
        if (Input.GetKey(KeyCode.DownArrow)) actions[0] = 2;
        if (Input.GetKey(KeyCode.LeftArrow)) actions[0] = 3;
        if (Input.GetKey(KeyCode.RightArrow)) actions[0] = 4;
    } 
}

//mlagents-learn config/gun_evo.yaml --run-id=gun_evo --env=apps/gun_evo --force
//mlagents-learn config/gun_evo.yaml --run-id=gun_evo --env=apps/gun_evo --height=900 --width=1600 --force
//mlagents-learn config/gun_evo.yaml --run-id=gun_evo --env=apps/gun_evo --height=450 --width=800 --force
//mlagents-learn config/gun_evo.yaml --run-id=gun_evo --env=apps/gun_evo --num-envs 16 --no-graphics --force