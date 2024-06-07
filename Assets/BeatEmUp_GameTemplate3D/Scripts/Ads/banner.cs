using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        banners();
    }

    // Update is called once per frame
    void Update()
    {
        banners();
    }

    public void banners()
    {
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM,BannerType.SmartBanner);
    }
}
