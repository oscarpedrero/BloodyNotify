using BloodyNotify.DB;
using BloodyNotify.Patch;
using ProjectM;

namespace BloodyNotify.AutoAnnouncer
{
    public  class AutoAnnouncerFunction
    {
        private static int __indexMessage;

        public static void OnTimedAutoAnnouncer()
        {
            var messages = Database.getAutoAnnouncerMessages();

            if (messages.Count > 0)
            {
                if (messages.Count == 1)
                {
                    foreach (var line in messages[0].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(Plugin.SystemsCore.EntityManager, line);
                    }
                }
                else
                {
                    foreach (var line in messages[__indexMessage].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(Plugin.SystemsCore.EntityManager, line);
                    }

                    __indexMessage++;

                    if (__indexMessage >= messages.Count)
                    {
                        __indexMessage = 0;
                    }
                }
            }
        }

        public static void StartAutoAnnouncer()
        {
            static void AutoAnnouncerAction()
            {
                if (Database.EnabledFeatures[NotifyFeature.auto])
                {
                    OnTimedAutoAnnouncer();
                    ActionSchedulerPatch.RunActionOnceAfterDelay(AutoAnnouncerAction, Database.getIntervalAutoAnnouncer());
                }
            }

            ActionSchedulerPatch.RunActionOnceAfterDelay(AutoAnnouncerAction, Database.getIntervalAutoAnnouncer());
        }

    }
}
