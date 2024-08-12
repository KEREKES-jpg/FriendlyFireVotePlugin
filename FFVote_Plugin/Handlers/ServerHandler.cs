using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFVote_Plugin.Handlers
{
    class ServerHandler
    {
        public static List<Player> votingPlayers = new List<Player>();

        public void OnRoundStart()
        {
            HandleFriendlyFire();
        }

        private void HandleFriendlyFire()
        {
            if (votingPlayers.Count > Player.List.Count / 2)
            {
                string message = Plugin.Instance.Config.ffOffMessage;
                message.Replace("{voters}", votingPlayers.Count.ToString());
                message.Replace("{pCount}", (Player.List.Count / 2).ToString());
                Map.Broadcast(4, message);
                Server.FriendlyFire = false;
            }
            else
            {
                string message = Plugin.Instance.Config.ffOnMessage;
                message.Replace("{voters}", votingPlayers.Count.ToString());
                message.Replace("{pCount}", (Player.List.Count/2).ToString());
                Map.Broadcast(4, message);
                Server.FriendlyFire = true;
            }
            votingPlayers.Clear();
        }
    }
}
