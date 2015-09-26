using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class BaseObject {

        protected Guid id;
        protected string name;
        protected string description;

        public BaseObject() {
            this.name = "new object";
            this.description = "new description";
            this.id = Guid.Empty;
        }

    }
}
