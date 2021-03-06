﻿using System.Collections.Generic;
using System.Linq;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {
    
    public class RegisteredUsers : IEnumerable<Account> {        
        public List<Account> List { get; private set; }

        public RegisteredUsers() {
            List = new List<Account>();
        }

        public bool Exists(string name) {
            return List.Exists(player => player.Name == name);
        }

        public bool UpdatePassword(string name, string value) {
            if (Exists(name)) {
                List.First(player => player.Name == name).Password = value; 
                return true;
            }
            return false;
        }

        public bool UpdateAdministrator(string name, bool value) {
            if (Exists(name)) {
                List.First(player => player.Name == name).Administrator = value;
                return true;
            }
            return false;
        }

        public bool UpdateEmail(string name, string value) {
            if (Exists(name)) {
                List.First(player => player.Name == name).Email = value;
                return true;
            }
            return false;
        }

        public void Add(Account player) {
            List.Add(player);
        }

        public void Remove(string name) {
            int index = List.FindIndex(player => player.Name == name);
            if (index >= 0) List.RemoveAt(index);
        }

        public IEnumerator<Account> GetEnumerator() {
            return List.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}