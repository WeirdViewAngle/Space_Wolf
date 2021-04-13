using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HealthPosTrack : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position = new Vector3(gameObject.transform.position.x,
                                         Camera.main.transform.position.y + (ScreenUtils.ScreenBottom + 0.5f),
                                         gameObject.transform.position.z);
    }
}
