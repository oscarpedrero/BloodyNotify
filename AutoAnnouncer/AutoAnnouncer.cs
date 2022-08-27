using Notify.Helpers;
using ProjectM;
using Wetstone.API;

namespace Notify.AutoAnnouncer
{
    public  class AutoAnnouncerFunction
    {
        private static int __indexMessage;

        public static void OnTimedAutoAnnouncer()
        {
            var messages = DBHelper.getAutoAnnouncerMessages();

            if (messages.Count > 0)
            {
                if (messages.Count == 1)
                {
                    foreach (var line in messages[0].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(VWorld.Server.EntityManager, line);
                    }
                }
                else
                {
                    foreach (var line in messages[__indexMessage].MessageLines)
                    {
                        ServerChatUtils.SendSystemMessageToAllClients(VWorld.Server.EntityManager, line);
                    }

                    __indexMessage++;

                    if (__indexMessage >= messages.Count)
                    {
                        __indexMessage = 0;
                    }
                }
            }

            Plugin.Logger.LogWarning("Timer executed");
        }
    }
}
