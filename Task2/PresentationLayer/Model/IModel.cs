using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public interface IModel
    {
        public IServiceApi ServiceApi { get; set; }

        public void Add();
        public void Remove();
        public void Update();
    }
}
