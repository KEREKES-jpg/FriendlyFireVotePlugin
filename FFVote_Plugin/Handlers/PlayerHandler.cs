using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFVote_Plugin.Handlers
{
    class PlayerHandler
    {
        public void OnPlayerJoined(VerifiedEventArgs ev)
        {
            if (Round.IsLobby)
            {
                string message = Plugin.Instance.Config.votingMessage;
                ev.Player.Broadcast(6, message);
            }
        }
    }
}
