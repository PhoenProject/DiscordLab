using Newtonsoft.Json;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;

namespace DiscordLab
{
    internal class PlayerEvents : IEventHandlerPlayerJoin, IEventHandlerPlayerLeave, IEventHandlerConnect, IEventHandlerPlayerHurt, IEventHandlerPlayerDie, IEventHandlerCheckEscape, 
        IEventHandlerPocketDimensionEnter, IEventHandlerPocketDimensionExit, IEventHandlerPocketDimensionDie, IEventHandlerThrowGrenade, IEventHandlerLure, IEventHandlerContain106, IEventHandlerMedkitUse,
        IEventHandlerHandcuffed, IEventHandlerGeneratorUnlock, IEventHandler079LevelUp, IEventHandlerSpawn
    {
        private DiscordLab discordLab;
        public PlayerEvents(DiscordLab discordLab) => this.discordLab = discordLab;

        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            string msg = $"**{ev.Player.Name} ({ev.Player.SteamId} from ||{ev.Player.IpAddress}||) has joined the server**";

            discordLab.TrySend(msg);

            //discordLab.Info(DateTime.Now.ToString("HH:mm:ss"));
        }

        public void OnPlayerLeave(PlayerLeaveEvent ev)
        {
            string msg = $"{ev.Name} ({ev.SteamID}) left the server";
            discordLab.TrySend(msg);
        }

        public void OnConnect(ConnectEvent ev)
        {
            string msg = $"Incoming connection from {ev.Connection.IpAddress}";
            discordLab.TrySend(msg);
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if (ev.Player.Name == "Server") return;

            string msg;

            if (ev.Player.TeamRole.Team == ev.Attacker.TeamRole.Team && ev.Player.SteamId != ev.Attacker.SteamId) msg = $"**{ev.Attacker.TeamRole.Role} {ev.Attacker.Name} dealt {ev.Damage} damage using {ev.DamageType} to friendly {ev.Player.TeamRole.Role} {ev.Player.Name}**";
            else msg = $"{ev.Attacker.Name} -> {ev.Player.Name}  -> {ev.Damage} ({ev.DamageType})";

            discordLab.TrySend(msg);
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (ev.Player.Name == "Server") return;

            string msg;

            if (ev.Player.TeamRole.Team == ev.Killer.TeamRole.Team && ev.Player.SteamId != ev.Killer.SteamId) 
                msg = $"```autohotkey\nPlayer: {ev.Killer.TeamRole.Role} {ev.Killer.Name} ({ev.Killer.SteamId})\nTeamkilled: {ev.Player.TeamRole.Role} {ev.Player.Name} ({ev.Player.SteamId})\nUsing: {ev.DamageTypeVar}```";
            else if(ev.Player.IsHandcuffed() && ev.Player.SteamId != ev.Killer.SteamId)
                msg = $"**__player {ev.Killer.TeamRole.Role} {ev.Killer.Name} killed disarmed {ev.Player.TeamRole.Role} {ev.Player.Name} ({ev.Player.SteamId}) using: {ev.DamageTypeVar}__**";
            else msg = $"{ev.Killer.TeamRole.Role} {ev.Killer.Name} killed {ev.Player.TeamRole.Role} {ev.Player.Name} using {ev.DamageTypeVar}";

            discordLab.TrySend(msg);
        }

        public void OnCheckEscape(PlayerCheckEscapeEvent ev)
        {
            string msg = $"{ev.Player.Name} escaped as {ev.Player.TeamRole.Role}";

            discordLab.TrySend(msg);
        }

        public void OnPocketDimensionEnter(PlayerPocketDimensionEnterEvent ev)
        {
            string msg = $"{ev.Player.Name} entered the pocket dimension";

            discordLab.TrySend(msg);
        }

        public void OnPocketDimensionExit(PlayerPocketDimensionExitEvent ev)
        {
            string msg = $"{ev.Player.Name} escaped the pocket dimension";

            discordLab.TrySend(msg);
        }

        public void OnPocketDimensionDie(PlayerPocketDimensionDieEvent ev)
        {
            string msg = $"{ev.Player.Name} died to the pocket dimension";

            discordLab.TrySend(msg);
        }

        public void OnThrowGrenade(PlayerThrowGrenadeEvent ev)
        {
            string msg = $"{ev.Player.Name} threw a {ev.GrenadeType}";

            discordLab.TrySend(msg);
        }

        public void OnLure(PlayerLureEvent ev)
        {
            string msg = $"{ev.Player.Name} was sacraficed to recontain SCP-106";

            discordLab.TrySend(msg);
        }

        public void OnContain106(PlayerContain106Event ev)
        {
            string msg = $"{ev.Player.Name} started SCP-106 recontainment sequence";

            discordLab.TrySend(msg);
        }

        public void OnMedkitUse(PlayerMedkitUseEvent ev)
        {
            string msg = $"{ev.Player.Name} used a medkit and healed {ev.RecoverHealth}";

            discordLab.TrySend(msg);
        }

        public void OnHandcuffed(PlayerHandcuffedEvent ev)
        {
            string msg = $"{ev.Owner.Name} disarmed {ev.Player.Name}";

            discordLab.TrySend(msg);
        }

        public void OnGeneratorUnlock(PlayerGeneratorUnlockEvent ev)
        {
            string msg = $"{ev.Player.Name} unlocked generator {ev.Generator.Room}";

            discordLab.TrySend(msg);
        }

        public void On079LevelUp(Player079LevelUpEvent ev)
        {
            string msg = $"{ev.Player.Name} leveled up as SCP-079";

            discordLab.TrySend(msg);
        }

        public void OnSpawn(PlayerSpawnEvent ev)
        {
            string msg = $"{ev.Player.Name} spawned as {ev.Player.TeamRole.Role}";

            discordLab.TrySend(msg);
        }
    }
}