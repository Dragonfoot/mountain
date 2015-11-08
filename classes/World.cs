using System;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World : Identity {
        [XmlArray("Areas")]
        public List<Area> Areas;
        [XmlIgnore]
        public ApplicationSettings settings;
        protected ListBox Console;
        protected TcpServer portListener;
        private CancellationTokenSource cancellationTokenSource;

        public World(ApplicationSettings appSettings) {
            InitializeSettings(appSettings);
            Areas = new List<Area>();
            portListener = new TcpServer(this, appSettings);
            portListener.StartServer(8090);
            string lastworld = settings.LastSavedWorld;
            if (lastworld.IsNullOrWhiteSpace()) {
                Load("default world");
            } else {
                Load(lastworld);
            }
         //   StartHeart(); // activate world
        }

        private void InitializeSettings(ApplicationSettings appSettings) {
            settings = appSettings;
            settings.Players.OnPlayerAdded += Players_OnPlayerAdded;
            settings.Players.OnPlayerRemoved += Players_OnPlayerRemoved;
        }

        void Players_OnPlayerRemoved(object myObject, Player player) {
            throw new NotImplementedException("Player removed");
        }

        void Players_OnPlayerAdded(object myObject, Player player) {
           // throw new NotImplementedException("Player added");
        }

        public void Reload() {
            throw new NotImplementedException("World Reload");
        }
        public void Clear() {
            throw new NotImplementedException("World Clear");
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
            Name = "Default World";
            base.ID = Guid.NewGuid();
            base.Description = "This world has been created by the Toetag Corporate Funding Group for your life's passionate pleasures. " +
                "Keep your new world growing with us. /n" +
                "Invest in Toetag Corporation's Life Insurance Policies and help make our gaming addition goals a viable solution. " +
                "Become a gold member of our growing centers of excellence, do the right thing, " +
                "donate your soul to our world class Gaming Society Center of Excellence. You could win big!/n" +
                "Join today. (Please sign our body donor card and be entered in our annual Grisly Corpse Competition Awards ceremony. " +
                "You could win a place on the top shelf of our Achievements of Horror vault that houses the very best souls of our societies " +
                "most fascinating players.)";
            this.CreateDefaultAdminArea();
          //  this.Save("defaultWorld");
        }

        private void CreateDefaultAdminArea() {
            Area area = new Area(); // empty stubs
            Room room = new Room();
            area.Rooms.Add(room);
            this.Areas.Add(area);
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
                    // do event ticks, 
                    // do schedule checks, 
                    // update time,
                    // update weather
                    // other stuff
                    // possibly sleep(30) to give functions time to complete. 
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
    }
}

