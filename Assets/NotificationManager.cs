using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

namespace Notification
{

    public class NotificationManager : MonoBehaviour
    {
        readonly string CHANEL_ID = "chennel_id";

        // Start is called before the first frame update
        private void Awake()
        {
            InitializeAndroidNotificationChannel();
        }

        void InitializeAndroidNotificationChannel()
        {
            AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
            {
                Id = "channel_id",
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SendPauseNotification();
                Debug.Log("paused");
            }
        }

        void SendPauseNotification()
        {
            AndroidNotification androidNotification = new AndroidNotification
            {
                Title = "Hello",
                Text = "Check this out",
                FireTime = System.DateTime.Now.AddSeconds(5f)
            };

            AndroidNotificationCenter.SendNotification(androidNotification, CHANEL_ID);

        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}