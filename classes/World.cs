using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    [Serializable] public class World : Identity {
        [XmlArray("Areas")] public List<Area> Areas;
        [XmlIgnore] public ApplicationSettings settings;
        [XmlIgnore] public TcpServerListener portListener;
        [XmlIgnore] public int Connections { get; private set; }
        protected ListBox Console;
        private CancellationTokenSource cancellationTokenSource;
        public int Port;

        public World(ApplicationSettings appSettings) {
            InitializeSettings(appSettings);
            Areas = new List<Area>();
            portListener = new TcpServerListener(this, appSettings);
            Port = 8090;
      //      portListener.StartServer(Port);
            string lastworld = settings.LastSavedWorld;
            if (lastworld.IsNullOrWhiteSpace()) Load(null);
            else Load(null);           
         //   StartHeart(); // activate world
        }

        public World() {
        }

        private void InitializeSettings(ApplicationSettings appSettings) {
            ClassType = classObjectType.world;
            settings = appSettings;
            settings.Players.OnPlayerAdded += Players_OnPlayerAdded;
            settings.Players.OnPlayerRemoved += Players_OnPlayerRemoved;
        }

        public void StartListen(int port = 8090) {
            portListener.StartServer(port);
        }

        void Players_OnPlayerRemoved(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player removed");
        }

        void Players_OnPlayerAdded(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player added");
        }

        public void Reload() {
          //  throw new NotImplementedException("World Reload");
        }

        public void Clear() {
           // throw new NotImplementedException("World Clear");
        }

        public void Shutdown() {
            settings.Players.Shutdown();
            StopHeart();
            portListener.StopServer();
        }

        public void Load(string world) { 
            if (!world.IsNullOrWhiteSpace()) {
            } else {
                CreateDefaultWorld();
            }
        }

        public void CreateDefaultWorld() {
            Name = "Mountain";
            ID = Guid.NewGuid();
            Description = "This world has been created by the Toetag Corporate Funding Group for your life's passionate pleasures. " +
                "Keep your new world growing with us. \r\n" +
                "Invest in Toetag Corporation's Life Insurance Policies and help make our gaming addition goals a viable solution. " +
                "Become a gold member of our growing centers of excellence, do the right thing, " +
                "donate your soul to our world class gaming society's Center of Excellence. You could win big!\r\n" +
                "Join today. (Please sign our body donor card and be entered in our annual Grisly Corpse Competition Awards ceremony. " +
                "You could win a place on the top shelf of our Achievements of Horror vault that houses the very best souls of our society's " +
                "most fascinating players.)\r\n";
            CreateDefaultAdminArea();
        }

        private void CreateDefaultAdminArea() {
            Areas.Add(Build.AdminArea(settings));
        }

        public void Save(string filename) {
            throw new NotImplementedException("World Save");
        }
       
        private void StartHeart() {
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            foreach (Area area in Areas) {
                area.StartHeart();
            }
            var task = Task.Factory.StartNew(() => {
                while (true) {
                    cancellationToken.ThrowIfCancellationRequested();
                    // event ticks, 
                    // schedule checks, 
                    // update time,
                    // update weather.. 
                }
            }, cancellationToken);
            foreach (Area area in Areas) {
                area.StopHeart();
            }           
        }

        private void StopHeart() {
            if (cancellationTokenSource != null) {
                cancellationTokenSource.Cancel();
            }
        }

        public Room GetRoomByName(string name) {
            foreach (Area area in Areas) {
                foreach (Room room in area.Rooms) {
                    if (room.Name == name) return room;                    
                }
            }
            return null;
        }
        public string GetAreaNameByRoomName(string name) {
            Room room = GetRoomByName(name);
            if (room == null) return null;
            return room.Location.Area.Name;
        }
    }
}

