using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectM;
using Notify.Helpers;

/**
 * 
 * Based in Code By syllabicat from VBloodKills (https://github.com/syllabicat/VBloodKills)
 * 
**/
namespace Notify.Utils
{
    public class VBloodKillers
    {
        
        public static Dictionary<string, HashSet<string>> vbloodKills = new();

        
        public static void AddKiller(string vblood, string killerCharacterName)
        {
            if (!vbloodKills.ContainsKey(vblood))
            {
                vbloodKills[vblood] = new HashSet<string>();
            }
            vbloodKills[vblood].Add(killerCharacterName);
        }
        
        public static void RemoveKillers(string vblood)
        {
            vbloodKills[vblood] = new HashSet<string>();
        }
        
        public static List<string> GetKillers(string vblood)
        {
            return vbloodKills[vblood].ToList();
        }

        public static void SendAnnouncementMessage(string vblood)
        {
            var message = GetAnnouncementMessage(vblood);
            if (message != null)
            {
                var usersOnline = PlayerUtils.GetAllUsersOnline();
                foreach (var user in usersOnline)
                {
                    var isUserIgnore = DBHelper.getVBloodNotifyIgnore(PlayerUtils.getCharacterName(user));
                    if (!isUserIgnore)
                    {
                        ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, PlayerUtils.getUserComponente(user), message);
                    }
                }
                RemoveKillers(vblood);
            }
            
        }

        public static string GetAnnouncementMessage(string vblood)
        {
            var killers = GetKillers(vblood);
            var vbloodLabel = DBHelper.getPrefabNameValue(vblood);
            var sbKillersLabel = new StringBuilder();
            if (killers.Count == 0) return null;
            if (killers.Count == 1)
            {
                sbKillersLabel.Append(FontColorChat.Yellow(killers[0]));
            }
            if (killers.Count == 2)
            {
                sbKillersLabel.Append($"{FontColorChat.Yellow(killers[0])} {DBHelper.getVBloodFinalConcatCharacters()} {FontColorChat.Yellow(killers[1])}");
            }
            if (killers.Count > 2)
            {
                for (int i = 0; i < killers.Count; i++)
                {
                    if (i == killers.Count - 1)
                    {
                        sbKillersLabel.Append($"{DBHelper.getVBloodFinalConcatCharacters()} {FontColorChat.Yellow(killers[i])}");
                    }
                    else
                    {
                        sbKillersLabel.Append($"{FontColorChat.Yellow(killers[i])}, ");
                    }
                }
            }

            var _message = DBHelper.getDefaultAnnounceValue("VBlood");
            _message = _message.Replace("#user#", $"{sbKillersLabel}");
            _message = _message.Replace("#vblood#", $"{FontColorChat.Red(vbloodLabel)}");
            return FontColorChat.Green($"{_message}");
        }
    }
}
