﻿using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Xml.Serialization;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;
using Mountain.classes.Items;
using Mountain.classes.mobs;
using Mountain.classes.collections;
using Mountain.classes.tcp;

namespace Mountain.classes {

    [Serializable]
    public class Room : Identity {
        [XmlIgnore] public ConcurrentBag<Mob> Mobs { get; set; }
        [XmlIgnore] public ConcurrentBag<Item> Items { get; set; }
        [XmlIgnore][NonSerialized()] public Players Players;
        [XmlIgnore] public PlayerEventQueue Messages;
        [XmlIgnore] public ApplicationSettings settings;
        [XmlIgnore] public Linkage Linkage { get; set; }
        public string shortDescription { get; set; }
        public roomType roomType { get; set; }
        public roomRestrictionType roomRestrictons { get; set; }
        public roomConditionType roomConditions { get; set; }
        public string Tag { get; set; }
        [XmlArray("Links")] public List<Exit> Exits { get; set; }

        public Room(ApplicationSettings appSettings, Area area) {
            InitializeRoom(appSettings);
            Name = "New Room";;
            Description = "This is a newly created room";
            Linkage = new Linkage(Name, area, this);
        }
        public Room(string name, ApplicationSettings appSettings, Area area) {
            InitializeRoom(appSettings);
            Name = name;
            Description = Name + " is a newly created room";
            Linkage = new Linkage(Name, area, this);
        }
        public Room(string name, string description, ApplicationSettings appSettings, Area area) {
            InitializeRoom(appSettings);
            Name = name;
            Description = description;
            Linkage = new Linkage(Name, area, this);
        }
        public Room() { // for serializer
        }

        public override string ToString() {
            return Name;
        }

        private void InitializeRoom(ApplicationSettings appSettings) {
            ClassType = classObjectType.room;
            settings = appSettings;
            Exits = new List<Exit>();
            Players = new Players();
            Mobs = new ConcurrentBag<Mob>();
            Items = new ConcurrentBag<Item>();
            Messages = new PlayerEventQueue();            
            Messages.OnEventReceived += Messages_OnPlayerEventReceived;
            Players.OnPlayerAdded += Players_OnPlayerAdded;
            Players.OnPlayerRemoved += Players_OnPlayerRemoved;
        }

        private void Players_OnPlayerAdded(object myObject, Connection player, string message = "") {
            string name = player.Account.Name;
            if (message == "") message = " just arrived.";
            foreach (Connection client in Players) {
                if (client != player) client.Send(player.Account.Name.Ansi(Style.white) + message.Ansi(Style.white).NewLine());
                else SendCommand(player, "look");
            }
        }

        private void Players_OnPlayerRemoved(object myObject, Connection player, string message = "") {
            foreach (Connection Player in Players) {
                Player.Send(player.Account.Name.Ansi(Style.white) + " goes to the " + message + ".".NewLine());
            }
        }

        private void SendCommand(Connection player, string command) {
            Task HandleMessage = new Task(() => player.Commands(player, command));
            HandleMessage.Start();
        }

        public string GetName() { return Name; }
        public string GetDesciption() { return Description; }
        public string GetExits() { return Functions.GetNames(Exits.ToArray()); }
        public string GetMobs() { return Functions.GetNames(Mobs.ToArray()); }
        public string GetPlayers() { return Functions.GetNames(Players.ToArray()); }
        public string GetOtherPlayers(string name) { return Functions.GetOtherNames(Players.ToArray(), name); }
        public string GetItems() { return Functions.GetNames(Items.ToArray()); }

        private void Messages_OnPlayerEventReceived(object myObject, Packet packet) {
            Packet message = Messages.Pop(); 
            if (message == null) message = packet;
            settings.SystemMessageQueue.Push("Room received: " + message);
        }        
        
        public void HeartBeat() {
            throw new NotImplementedException("Room beat");
        }

        public void AddExit(Exit exit) {
            exit.Owner = this;
            Exits.Add(exit);
        }

        public void AddMob(Mob mob) {
            Mobs.Add(mob);
            // a mob just arrived...
        }

        public void AddPlayer(Connection player) {
            Players.Add(player);
            player.Location.Room = this;
            player.Account.Location = new Linkage(Linkage.DoorLabel, Linkage.Area, Linkage.Room);
        }

        public void RemovePlayer(Connection player, string message) {
            Players.Remove(player.Account.Name, message);
        }

        public string SaveXML() { 
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(Room));
            TextWriter writer = new StringWriter();
            try {
                serializer.Serialize(writer, this, emptyNamepsaces);
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
                return e.ToString();
            }             
            return writer.ToString();
        }

        public string[] View() {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> view = new List<string>();
            view.Add(Name);
            view.Add("");
            view.Add(Description);
            view.Add("");
            if (Exits.Any()) { // add color coding's
                stringBuilder.Append("Exits: " + Functions.GetNames(Exits.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Mobs.Any()) {
                stringBuilder.Append("Mobs: " + Functions.GetNames(Mobs.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Players.Any()) {
                stringBuilder.Append("Players: " + Functions.GetNames(Players.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Items.Any()) {
                // items on floor; need to search for duplicates, pronouns, etc., and display them in friendly grammar form
                // You see (an) orange, 23 pumpkin seed(s), (a) hungry cat, Toetag('s) nose.
            }
            return view.ToArray();
        }

        protected void Save() {
            throw new NotImplementedException("Room save");
        }
        protected void Load() {
            throw new NotImplementedException("Room load");
        }
        
    }
}
