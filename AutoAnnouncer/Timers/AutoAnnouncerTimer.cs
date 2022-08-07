using Notify.Helpers;
using ProjectM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Wetstone.API;

namespace Notify.AutoAnnouncer.Timers
{

    public class AutoAnnouncerTimer
    {
        private static int __indexMessage = 0;
        private static Timer aTimer;
        public static void Start()
        {
            aTimer = new Timer
            {
                Interval = DBHelper.getIntervalAutoAnnouncer()
            };

            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;

        }

        public static void Stop()
        {
            aTimer.Enabled = false;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var messages = DBHelper.getAutoAnnouncerMessages();

            if(messages.Count > 0)
            {
                if(messages.Count == 1)
                {
                    foreach (var line in messages[0].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(VWorld.Server.EntityManager, line);
                    }
                } else
                {
                    foreach(var line in messages[__indexMessage].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(VWorld.Server.EntityManager, line);
                    }

                    __indexMessage++;

                    if (__indexMessage >= messages.Count)
                    {
                        __indexMessage = 0;
                    }
                }
            } else
            {
                aTimer.Enabled = false;
            }


            Plugin.Logger.LogWarning("Timer executed");
        }

    }
}
