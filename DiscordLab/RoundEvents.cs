using Newtonsoft.Json;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System;
using System.Collections.Generic;

namespace DiscordLab
{
    internal class RoundEvents : IEventHandlerRoundEnd, IEventHandlerRoundStart, IEventHandlerWaitingForPlayers, IEventHandlerTeamRespawn
    {
        private DiscordLab discordLab;

        public RoundEvents(DiscordLab discordLab) => this.discordLab = discordLab;

        public void OnRoundEnd(RoundEndEvent ev)
        {
            string msg = $"**Round ended after {ev.Round.Duration} minutes.**"
                + $"```Escaped D-class: {ev.Round.Stats.ClassDEscaped}/{ev.Round.Stats.ClassDStart}"
                + $"\nRescued Scientists: {ev.Round.Stats.ScientistsEscaped}/{ev.Round.Stats.ScientistsStart}"
                + $"\nContained SCPs: {ev.Round.Stats.SCPDead}/{ev.Round.Stats.SCPStart}"
                + $"\nKilled by SCPs: {ev.Round.Stats.SCPKills}"
                + $"\nWarhead status: {(ev.Round.Stats.WarheadDetonated == true ? "Detonated" : "Not detonated")}```";

            discordLab.TrySend(msg);
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            string msg = $"```fix\n-----Round started-----```";

            discordLab.TrySend(msg);
        }


        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            string msg = $"**{(ev.SpawnChaos == true ? "Facility incursion detected, intruders identified as members of hostile GOI Chaos Insurgency" : "Mobile TaskForce Epsilon-11 designated Nine-Tailed Fox has entered the facility.")}**";

            discordLab.TrySend(msg);
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            string msg = $"**Server is ready and waiting for players...**";

            discordLab.TrySend(msg);
        }
    }
}