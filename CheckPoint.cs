using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// チェックポイント
public class CheckPoint : MonoBehaviour {
    public Blue_player blue1;
    public Blue_player blue2;
    public Blue_player blue3;
    public Blue_player blue4;
    public Blue_player blue5;
    public Blue_player blue6;

    public Red_player red1;
    public Red_player red2;
    public Red_player red3;
    public Red_player red4;
    public Red_player red5;
    public Red_player red6;

    public int checkPointId;

    // 他のオブジェクトとの接触時に呼ばれる
    void OnTriggerEnter(Collider other) {
        //接触した
        if (other.gameObject.tag == "CheckPoint") {
            blue1.EnterCheckPoint(checkPointId);
            blue2.EnterCheckPoint(checkPointId);
            blue3.EnterCheckPoint(checkPointId);
            blue4.EnterCheckPoint(checkPointId);
            blue5.EnterCheckPoint(checkPointId);
            blue6.EnterCheckPoint(checkPointId);

            red1.EnterCheckPoint(checkPointId);
            red2.EnterCheckPoint(checkPointId);
            red3.EnterCheckPoint(checkPointId);
            red4.EnterCheckPoint(checkPointId);
            red5.EnterCheckPoint(checkPointId);
            red6.EnterCheckPoint(checkPointId);
        }

        else if (other.gameObject.tag == "mCP1") {
            blue1.EnterCheckPoint(checkPointId);
        }
        else if (other.gameObject.tag == "mCP2") {
            blue2.EnterCheckPoint(checkPointId);
        }
        else if (other.gameObject.tag == "mCP3") {
            blue3.EnterCheckPoint(checkPointId);
        }
        else if (other.gameObject.tag == "mCP4") {
            blue4.EnterCheckPoint(checkPointId);
        }
        else if (other.gameObject.tag == "mCP5") {
            blue5.EnterCheckPoint(checkPointId);
        }
        else if (other.gameObject.tag == "mCP6") {
            blue6.EnterCheckPoint(checkPointId);
        }
    }
}